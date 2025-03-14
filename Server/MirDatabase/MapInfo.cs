using System.Drawing;
using Server.MirEnvir;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.MirDatabase
{
    [Table("MapInfo")]
    public class MapInfo
    {
        [NotMapped]
        protected static Envir Envir
        {
            get { return Envir.Main; }
        }
        [NotMapped]
        protected static Envir EditEnvir
        {
            get { return Envir.Edit; }
        }

        public int Index { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FileName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        
        public ushort MiniMap { get; set; }
        public ushort BigMap { get; set; }
        public ushort Music { get; set; }

        public LightSetting Light { get; set; }

        public byte MapDarkLight { get; set; }
        public byte MineIndex { get; set; }
        public byte GTIndex { get; set; }

        public bool NoTeleport { get; set; }
        public bool NoReconnect { get; set; }
        public bool NoRandom { get; set; }
        public bool NoEscape { get; set; }
        public bool NoRecall { get; set; }
        public bool NoDrug { get; set; }
        public bool NoPosition { get; set; }
        public bool NoFight { get; set; }
        public bool NoThrowItem { get; set; }
        public bool NoDropPlayer { get; set; }
        public bool NoDropMonster { get; set; }
        public bool NoNames { get; set; }
        public bool NoMount { get; set; }
        public bool NeedBridle { get; set; }
        public bool Fight { get; set; }
        public bool NeedHole { get; set; }
        public bool Fire { get; set; }
        public bool Lightning { get; set; }
        public bool NoTownTeleport { get; set; }
        public bool NoReincarnation { get; set; }
        public bool GT { get; set; }

        public string NoReconnectMap { get; set; } = string.Empty;
        public int FireDamage { get; set; }
        public int LightningDamage { get; set; }

        // Relationships - Use 'virtual' for Lazy Loading
        
        public virtual List<SafeZoneInfo> SafeZones { get; set; } = new List<SafeZoneInfo>();
        public virtual List<MovementInfo> Movements { get; set; } = new List<MovementInfo>();
        public virtual List<RespawnInfo> Respawns { get; set; } = new List<RespawnInfo>();
        public virtual List<NPCInfo> NPCs { get; set; } = new List<NPCInfo>();
        public virtual List<MineZone> MineZones { get; set; } = new List<MineZone>();

        
        [NotMapped]
        public List<Point> ActiveCoords { get; set; } = new List<Point>();

        public string ActiveCoordsJson
        {
            get => System.Text.Json.JsonSerializer.Serialize(ActiveCoords);
            set => ActiveCoords = string.IsNullOrEmpty(value) 
                ? new List<Point>() 
                : System.Text.Json.JsonSerializer.Deserialize<List<Point>>(value);
        }

        public WeatherSetting WeatherParticles { get; set; } = WeatherSetting.None;

        public MapInfo(){ }

        public MapInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();
            FileName = reader.ReadString();
            Title = reader.ReadString();
            MiniMap = reader.ReadUInt16();
            Light = (LightSetting)reader.ReadByte();

            BigMap = reader.ReadUInt16();

            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
                SafeZones.Add(new SafeZoneInfo(reader) { Info = this });

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
                Respawns.Add(new RespawnInfo(reader, Envir.LoadVersion, Envir.LoadCustomVersion));

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
                Movements.Add(new MovementInfo(reader));

            NoTeleport = reader.ReadBoolean();
            NoReconnect = reader.ReadBoolean();
            NoReconnectMap = reader.ReadString();

            NoRandom = reader.ReadBoolean();
            NoEscape = reader.ReadBoolean();
            NoRecall = reader.ReadBoolean();
            NoDrug = reader.ReadBoolean();
            NoPosition = reader.ReadBoolean();
            NoThrowItem = reader.ReadBoolean();
            NoDropPlayer = reader.ReadBoolean();
            NoDropMonster = reader.ReadBoolean();
            NoNames = reader.ReadBoolean();
            Fight = reader.ReadBoolean();
            Fire = reader.ReadBoolean();
            FireDamage = reader.ReadInt32();
            Lightning = reader.ReadBoolean();
            LightningDamage = reader.ReadInt32();
            MapDarkLight = reader.ReadByte();
            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
                MineZones.Add(new MineZone(reader));
            MineIndex = reader.ReadByte();
            NoMount = reader.ReadBoolean();
            NeedBridle = reader.ReadBoolean();
            NoFight = reader.ReadBoolean();
            Music = reader.ReadUInt16();

            if (Envir.LoadVersion < 78) return;
            NoTownTeleport = reader.ReadBoolean();
            if (Envir.LoadVersion < 79) return;
            NoReincarnation = reader.ReadBoolean();

            if (Envir.LoadVersion >= 110)
            {
                WeatherParticles = (WeatherSetting)reader.ReadUInt16();
            }

            if (Envir.LoadVersion >= 111)
            {
                GT = reader.ReadBoolean();
                GTIndex = reader.ReadByte();
            }
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Index);
            writer.Write(FileName);
            writer.Write(Title);
            writer.Write(MiniMap);
            writer.Write((byte)Light);
            writer.Write(BigMap);
            writer.Write(SafeZones.Count);

            for (int i = 0; i < SafeZones.Count; i++)
                SafeZones[i].Save(writer);

            writer.Write(Respawns.Count);
            for (int i = 0; i < Respawns.Count; i++)
                Respawns[i].Save(writer);

            writer.Write(Movements.Count);
            for (int i = 0; i < Movements.Count; i++)
                Movements[i].Save(writer);

            writer.Write(NoTeleport);
            writer.Write(NoReconnect);
            writer.Write(NoReconnectMap);
            writer.Write(NoRandom);
            writer.Write(NoEscape);
            writer.Write(NoRecall);
            writer.Write(NoDrug);
            writer.Write(NoPosition);
            writer.Write(NoThrowItem);
            writer.Write(NoDropPlayer);
            writer.Write(NoDropMonster);
            writer.Write(NoNames);
            writer.Write(Fight);
            writer.Write(Fire);
            writer.Write(FireDamage);
            writer.Write(Lightning);
            writer.Write(LightningDamage);
            writer.Write(MapDarkLight);
            writer.Write(MineZones.Count);
            for (int i = 0; i < MineZones.Count; i++)
                MineZones[i].Save(writer);
            writer.Write(MineIndex);

            writer.Write(NoMount);
            writer.Write(NeedBridle);

            writer.Write(NoFight);

            writer.Write(Music);
            writer.Write(NoTownTeleport);
            writer.Write(NoReincarnation);

            writer.Write((UInt16)WeatherParticles);

            writer.Write(GT);
            writer.Write(GTIndex);

        }


        public void CreateMap()
        {
            for (int j = 0; j < Envir.NPCInfoList.Count; j++)
            {
                if (Envir.NPCInfoList[j].MapIndex != Index) continue;

                NPCs.Add(Envir.NPCInfoList[j]);
            }

            Map map = new Map(this);

            if (!map.Load()) return;

            Envir.MapList.Add(map);

            for (int i = 0; i < SafeZones.Count; i++)
                if (SafeZones[i].StartPoint)
                    Envir.StartPoints.Add(SafeZones[i]);
        }

        public void CreateSafeZone()
        {
            SafeZones.Add(new SafeZoneInfo { Info = this });
        }

        public void CreateRespawnInfo()
        {
            Respawns.Add(new RespawnInfo { RespawnIndex = ++EditEnvir.RespawnIndex });
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Index, Title);
        }

        public void CreateNPCInfo()
        {
            NPCs.Add(new NPCInfo());
        }

        public void CreateMovementInfo()
        {
            Movements.Add(new MovementInfo());
        }

        public static void FromText(string text)
        {
            string[] data = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length < 8) return;

            MapInfo info = new MapInfo {FileName = data[0], Title = data[1]};

            ushort miniMap;
            LightSetting light;


            if (!ushort.TryParse(data[2], out miniMap)) return;

            if (!Enum.TryParse(data[3], out light)) return;
            int sziCount, miCount, riCount, npcCount;

            if (!int.TryParse(data[4], out sziCount)) return;
            if (!int.TryParse(data[5], out miCount)) return;
            if (!int.TryParse(data[6], out riCount)) return;
            if (!int.TryParse(data[7], out npcCount)) return;

            info.MiniMap = miniMap;
            info.Light = light;

            int start = 8;

            for (int i = 0; i < sziCount; i++)
            {
                SafeZoneInfo temp = new SafeZoneInfo { Info = info };
                int x, y;

                ushort size;
                bool startPoint;

                if (!int.TryParse(data[start + (i * 4)], out x)) return;
                if (!int.TryParse(data[start + 1 + (i * 4)], out y)) return;
                // Parse values into temporary variables first
                if (!ushort.TryParse(data[start + 2 + (i * 4)], out size)) return;
                if (!bool.TryParse(data[start + 3 + (i * 4)], out startPoint)) return;

                temp.Size = size;
                temp.StartPoint = startPoint;

                temp.Location = new Point(x, y);
                info.SafeZones.Add(temp);
            }
            start += sziCount * 4;



            for (int i = 0; i < miCount; i++)
            {
                MovementInfo temp = new MovementInfo();
                int x, y;

                if (!int.TryParse(data[start + (i * 5)], out x)) return;
                if (!int.TryParse(data[start + 1 + (i * 5)], out y)) return;
                temp.Source = new Point(x, y);

                int mapIndex;

                if (!int.TryParse(data[start + 2 + (i * 5)], out mapIndex)) return;

                if (!int.TryParse(data[start + 3 + (i * 5)], out x)) return;
                if (!int.TryParse(data[start + 4 + (i * 5)], out y)) return;
                temp.Destination = new Point(x, y);
                temp.MapIndex = mapIndex;

                info.Movements.Add(temp);
            }
            start += miCount * 5;


            for (int i = 0; i < riCount; i++)
            {
                RespawnInfo temp = new RespawnInfo();
                int monsterIndex, x, y, respawnIndex;
                ushort count, spread, delay, respawnTicks;
                byte direction;
                bool saveRespawnTime;

                if (!int.TryParse(data[start + (i * 7)], out monsterIndex)) return;
                if (!int.TryParse(data[start + 1 + (i * 7)], out x)) return;
                if (!int.TryParse(data[start + 2 + (i * 7)], out y)) return;
                if (!ushort.TryParse(data[start + 3 + (i * 7)], out count)) return;
                if (!ushort.TryParse(data[start + 4 + (i * 7)], out spread)) return;
                if (!ushort.TryParse(data[start + 5 + (i * 7)], out delay)) return;
                if (!byte.TryParse(data[start + 6 + (i * 7)], out direction)) return;
                if (!int.TryParse(data[start + 7 + (i * 7)], out respawnIndex)) return;
                if (!bool.TryParse(data[start + 8 + (i * 7)], out saveRespawnTime)) return;
                if (!ushort.TryParse(data[start + 9 + (i * 7)], out respawnTicks)) return;

                // Assign parsed values to object properties
                temp.MonsterIndex = monsterIndex;
                temp.Location = new Point(x, y);
                temp.Count = count;
                temp.Spread = spread;
                temp.Delay = delay;
                temp.Direction = direction;
                temp.RespawnIndex = respawnIndex;
                temp.SaveRespawnTime = saveRespawnTime;
                temp.RespawnTicks = respawnTicks;

                info.Respawns.Add(temp);
            }
            start += riCount * 7;


            for (int i = 0; i < npcCount; i++)
            {
                NPCInfo temp = new NPCInfo { FileName = data[start + (i * 6)], Name = data[start + 1 + (i * 6)] };
                int x, y;

                if (!int.TryParse(data[start + 2 + (i * 6)], out x)) return;
                if (!int.TryParse(data[start + 3 + (i * 6)], out y)) return;

                temp.Location = new Point(x, y);

                ushort rate, image;

                if (!ushort.TryParse(data[start + 4 + (i * 6)], out rate)) return;
                if (!ushort.TryParse(data[start + 5 + (i * 6)], out image)) return;

                temp.Rate = rate;
                temp.Image = image;

                info.NPCs.Add(temp);
            }



            info.Index = ++EditEnvir.MapIndex;
            EditEnvir.MapInfoList.Add(info);
        }
    }
}
