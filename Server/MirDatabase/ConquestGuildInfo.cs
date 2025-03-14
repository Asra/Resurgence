using Server.MirEnvir;
using Server.MirObjects;
using Server.MirObjects.Monsters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.MirDatabase
{
    [Table("ConquestGuildInfo")]
    public class ConquestGuildInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;

        public List<ConquestGuildArcherInfo> ArcherList { get; set; } = new List<ConquestGuildArcherInfo>();
        public List<ConquestGuildGateInfo> GateList { get; set; } = new List<ConquestGuildGateInfo>();
        public List<ConquestGuildWallInfo> WallList { get; set; } = new List<ConquestGuildWallInfo>();
        public List<ConquestGuildSiegeInfo> SiegeList { get; set; } = new List<ConquestGuildSiegeInfo>();
        public List<ConquestGuildFlagInfo> FlagList { get; set; } = new List<ConquestGuildFlagInfo>();

        [NotMapped]
        public Dictionary<ConquestGuildFlagInfo, Dictionary<GuildObject, int>> ControlPoints { get; set; } = new Dictionary<ConquestGuildFlagInfo, Dictionary<GuildObject, int>>();

        public int Owner { get; set; } = 0;
        public uint GoldStorage { get; set; }
        public int AttackerID { get; set; }
        public byte NPCRate { get; set; } = 0;

        [NotMapped]
        public ConquestInfo Info { get; set; }

        public bool NeedSave { get; set; } = false;

        public ConquestGuildInfo() { }

        public ConquestGuildInfo(BinaryReader reader)
        {
            Owner = reader.ReadInt32();

            var archerCount = reader.ReadInt32();
            for (int i = 0; i < archerCount; i++)
            {
                ArcherList.Add(new ConquestGuildArcherInfo(reader));
            }

            var gateCount = reader.ReadInt32();
            for (int i = 0; i < gateCount; i++)
            {
                GateList.Add(new ConquestGuildGateInfo(reader));
            }

            var wallCount = reader.ReadInt32();
            for (int i = 0; i < wallCount; i++)
            {
                WallList.Add(new ConquestGuildWallInfo(reader));
            }

            var siegeCount = reader.ReadInt32();
            for (int i = 0; i < siegeCount; i++)
            {
                SiegeList.Add(new ConquestGuildSiegeInfo(reader));
            }

            GoldStorage = reader.ReadUInt32();
            NPCRate = reader.ReadByte();
            AttackerID = reader.ReadInt32();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Owner);
            writer.Write(ArcherList.Count);
            for (int i = 0; i < ArcherList.Count; i++)
            {
                ArcherList[i].Save(writer);
            }

            writer.Write(GateList.Count);
            for (int i = 0; i < GateList.Count; i++)
            {
                GateList[i].Save(writer);
            }

            writer.Write(WallList.Count);
            for (int i = 0; i < WallList.Count; i++)
            {
                WallList[i].Save(writer);
            }

            writer.Write(SiegeList.Count);
            for (int i = 0; i < SiegeList.Count; i++)
            {
                SiegeList[i].Save(writer);
            }

            writer.Write(GoldStorage);
            writer.Write(NPCRate);
            writer.Write(AttackerID);
        }
    }

    [Table("ConquestGuildSiegeInfo")]   
    public class ConquestGuildSiegeInfo
    {
        [NotMapped]
        protected static Envir Envir
        {
            get { return Envir.Main; }
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;

        public int Index { get; set; }
        public int Health { get; set; }

        [NotMapped]
        public ConquestSiegeInfo Info { get; set; }
        [NotMapped]
        public ConquestObject Conquest { get; set; }
        [NotMapped]
        public Gate Gate { get; set; }

        public ConquestGuildSiegeInfo() { }

        public ConquestGuildSiegeInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();

            if (Envir.LoadVersion <= 84)
            {
                Health = (int)reader.ReadUInt32();
            }
            else
            {
                Health = reader.ReadInt32();
            }
        }
        public void Save(BinaryWriter writer)
        {
            //if (Gate != null) Health = Gate.HP; - needs adding
            writer.Write(Index);
            writer.Write(Health);
        }


        public void Spawn()
        {
            if (Gate != null) Gate.Despawn();

            MonsterInfo monsterInfo = Envir.GetMonsterInfo(Info.MobIndex);

            if (monsterInfo == null) return;
            if (monsterInfo.AI != 72) return;

            if (monsterInfo.AI == 72)
            {
                Gate = (Gate)MonsterObject.GetMonster(monsterInfo);
            }
            else if (monsterInfo.AI == 73)
            {
                //Gate = (GateWest)MonsterObject.GetMonster(monsterInfo);
            }

            if (Gate == null) return;

            Gate.Conquest = Conquest;
            Gate.GateIndex = Index;

            Gate.Spawn(Conquest.ConquestMap, Info.Location);

            if (Health == 0)
            {
                Gate.Die();
            }
            else
            {
                Gate.SetHP(Health);
            }

            Gate.CheckDirection();
        }

        public int GetRepairCost()
        {
            int cost = 0;

            if (Gate == null) return 0;

            if (Gate.Stats[Stat.HP] == Gate.HP) return cost;

            if (Info.RepairCost != 0)
            {
                cost = Info.RepairCost / (Gate.Stats[Stat.HP] / (Gate.Stats[Stat.HP] - Gate.HP));
            }

            return cost;
        }

        public void Repair()
        {
            if (Gate == null)
            {
                Spawn();
                return;
            }

            if (Gate.Dead)
            {
                Spawn();
            }
            else
            {
                Gate.HP = Gate.Stats[Stat.HP];
            }

            Gate.CheckDirection();
        }
    }

    [NotMapped]
    public class ConquestGuildFlagInfo
    {
        public int Index;

        public ConquestFlagInfo Info;

        public ConquestObject Conquest;
        public GuildObject Guild;

        public NPCObject Flag;

        public ConquestGuildFlagInfo() { }

        public void Spawn()
        {
            NPCInfo npcInfo = new NPCInfo
            {
                Name = Info.Name,
                FileName = Info.FileName,
                Location = Info.Location,
                Image = 1000
            };

            if (Conquest.Guild != null)
            {
                Guild = Conquest.Guild;
                npcInfo.Image = Guild.Info.FlagImage;
                npcInfo.Colour = Guild.Info.FlagColour;
            }

            Flag = new NPCObject(npcInfo)
            {
                CurrentMap = Conquest.ConquestMap
            };

            Flag.CurrentMap.AddObject(Flag);

            Flag.Spawned();
        }

        public void ChangeOwner(GuildObject guild)
        {
            Guild = guild;

            UpdateImage();
            UpdateColour();
        }

        public void UpdateImage()
        {
            if (Guild != null)
            {
                Flag.Info.Image = Guild.Info.FlagImage;

                Flag.Broadcast(Flag.GetUpdateInfo());
            }
        }

        public void UpdateColour()
        {
            if (Guild != null)
            {
                Flag.Info.Colour = Guild.Info.FlagColour;

                Flag.Broadcast(Flag.GetUpdateInfo());
            }
        }
    }

    [Table("ConquestGuildWallInfo")]
    public class ConquestGuildWallInfo
    {
        [NotMapped]
        protected static Envir Envir
        {
            get { return Envir.Main; }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Index { get; set; }
        public int Health { get; set; }

        [NotMapped]
        public ConquestWallInfo Info;

        [NotMapped]
        public ConquestObject Conquest;

        [NotMapped]
        public Wall Wall;


        public ConquestGuildWallInfo() { }
        public ConquestGuildWallInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();

            if (Envir.LoadVersion <= 84)
            {
                Health = (int)reader.ReadUInt32();
            }
            else
            {
                Health = reader.ReadInt32();
            }
        }

        public void Save(BinaryWriter writer)
        {
            if (Wall != null) Health = Wall.HP;
            writer.Write(Index);
            writer.Write(Wall.Health);
        }

        public void Spawn(bool repair)
        {
            if (Wall != null) Wall.Despawn();

            MonsterInfo monsterInfo = Envir.GetMonsterInfo(Info.MobIndex);

            if (monsterInfo == null) return;

            if (monsterInfo.AI != 82) return;

            Wall = (Wall)MonsterObject.GetMonster(monsterInfo);

            if (Wall == null) return;

            Wall.Conquest = Conquest;
            Wall.WallIndex = Index;

            Wall.Spawn(Conquest.ConquestMap, Info.Location);

            if (repair) Health = Wall.Stats[Stat.HP];

            if (Health == 0)
                Wall.Die();
            else
                Wall.SetHP(Health);

            Wall.CheckDirection();
        }

        public int GetRepairCost()
        {
            int cost = 0;

            if (Wall == null) return 0;

            if (Wall.Stats[Stat.HP] == Wall.HP) return cost;

            if (Info.RepairCost != 0)
            {
                cost = Info.RepairCost / (Wall.Stats[Stat.HP] / (Wall.Stats[Stat.HP] - Wall.HP));
            }

            return cost;
        }

        public void Repair()
        {
            if (Wall == null)
            {
                Spawn(true);
                return;
            }

            if (Wall.Dead)
                Spawn(true);
            else
                Wall.HP = Wall.Stats[Stat.HP];

            Wall.CheckDirection();
        }
    }

    [Table("ConquestGuildGateInfo")]
    public class ConquestGuildGateInfo
    {
        [NotMapped]
        protected static Envir Envir
        {
            get { return Envir.Main; }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Index { get; set; }
        public int Health { get; set; }

        [NotMapped]
        public ConquestGateInfo Info;
        [NotMapped]
        public ConquestObject Conquest;
        [NotMapped]
        public Gate Gate;


        public ConquestGuildGateInfo() { }

        public ConquestGuildGateInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();

            if (Envir.LoadVersion <= 84)
            {
                Health = (int)reader.ReadUInt32();
            }
            else
            {
                Health = reader.ReadInt32();
            }
        }

        public void Save(BinaryWriter writer)
        {
            if (Gate != null) Health = Gate.HP;
            writer.Write(Index);
            writer.Write(Health);
        }

        public void Spawn(bool repair)
        {
            if (Gate != null) Gate.Despawn();

            MonsterInfo monsterInfo = Envir.GetMonsterInfo(Info.MobIndex);

            if (monsterInfo == null) return;
            if (monsterInfo.AI != 81) return;

            Gate = (Gate)MonsterObject.GetMonster(monsterInfo);

            if (Gate == null) return;

            Gate.Conquest = Conquest;
            Gate.GateIndex = Index;

            Gate.Spawn(Conquest.ConquestMap, Info.Location);

            if (repair) Health = Gate.Stats[Stat.HP];

            if (Health == 0)
                Gate.Die();
            else
                Gate.SetHP(Health);

            Gate.CheckDirection();
        }

        public int GetRepairCost()
        {
            int cost = 0;

            if (Gate == null) return 0;

            if (Gate.Stats[Stat.HP] == Gate.HP) return cost;

            if (Info.RepairCost != 0)
            {
                cost = Info.RepairCost / (Gate.Stats[Stat.HP] / (Gate.Stats[Stat.HP] - Gate.HP));
            }

            return cost;
        }

        public void Repair()
        {
            if (Gate == null)
            {
                Spawn(true);
                return;
            }

            if (Gate.Dead)
            {
                Spawn(true);
            }
            else
            {
                Gate.HP = Gate.Stats[Stat.HP];
            }

            Gate.CheckDirection();
        }
    }

    [Table("ConquestGuildArcherInfo")]
    public class ConquestGuildArcherInfo
    {
        [NotMapped]
        protected static Envir Envir
        {
            get { return Envir.Main; }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;

        public int Index { get; set; }
        public bool Alive { get; set; }

        [NotMapped]
        public ConquestArcherInfo Info { get; set; }
        [NotMapped]
        public ConquestObject Conquest { get; set; }
        [NotMapped]
        public ConquestArcher ArcherMonster { get; set; }


        public ConquestGuildArcherInfo() { }

        public ConquestGuildArcherInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();
            Alive = reader.ReadBoolean();
        }

        public void Save(BinaryWriter writer)
        {
            if (ArcherMonster == null || ArcherMonster.Dead)
            {
                Alive = false;
            }
            else
            {
                Alive = true;
            }

            writer.Write(Index);
            writer.Write(Alive);
        }

        public void Spawn(bool Revive = false)
        {
            if (Revive) Alive = true;

            MonsterInfo monsterInfo = Envir.GetMonsterInfo(Info.MobIndex);

            if (monsterInfo == null) return;
            if (monsterInfo.AI != 80) return;

            ArcherMonster = (ConquestArcher)MonsterObject.GetMonster(monsterInfo);

            if (ArcherMonster == null) return;

            ArcherMonster.Conquest = Conquest;
            ArcherMonster.ArcherIndex = Index;

            if (Alive)
            {
                ArcherMonster.Spawn(Conquest.ConquestMap, Info.Location);
            }
            else
            {
                ArcherMonster.Spawn(Conquest.ConquestMap, Info.Location);
                ArcherMonster.Die();
                ArcherMonster.DeadTime = Envir.Time;
            }
        }

        public uint GetRepairCost()
        {
            uint cost = 0;

            if (ArcherMonster == null || ArcherMonster.Dead)
            {
                cost = Info.RepairCost;
            }

            return cost;
        }
    }
}
