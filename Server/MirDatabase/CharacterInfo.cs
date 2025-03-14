using System.Drawing;
﻿using Server.MirEnvir;
using Server.MirNetwork;
using Server.MirObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Server.Services;
using Microsoft.EntityFrameworkCore;
using Server.MirDatabase;

namespace Server.MirDatabase
{
    [Table("CharacterInfo")]
    public class CharacterInfo : DatabaseEntity
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
        public string Name { get; set; }
        public ushort Level { get; set; }
        public MirClass Class { get; set; }
        public MirGender Gender { get; set; }
        public byte Hair { get; set; }
        public int GuildIndex { get; set; } = -1;

        public string CreationIP { get; set; }
        public DateTime CreationDate { get; set; }

        public bool Banned { get; set; }
        public string BanReason { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }

        public bool ChatBanned { get; set; }
        public DateTime ChatBanExpiryDate { get; set; }

        public string LastIP { get; set; } = string.Empty;
        public DateTime LastLogoutDate { get; set; }
        public DateTime LastLoginDate { get; set; }

        public bool Deleted { get; set; }
        public DateTime DeleteDate { get; set; }

        //Marriage
        public int Married { get; set; } = 0;
        public DateTime MarriedDate { get; set; }

        //Mentor
        public int Mentor { get; set; } = 0;
        public DateTime MentorDate { get; set; }
        public bool IsMentor { get; set; }
        public long MentorExp { get; set; } = 0;

        //Location
        public int CurrentMapIndex { get; set; }
        public MirDirection Direction { get; set; }
        public int BindMapIndex { get; set; }

        [NotMapped]
        public Point BindLocation 
        { 
            get => new Point(BindLocationX, BindLocationY);
            set
            {
                BindLocationX = value.X;
                BindLocationY = value.Y;
            }
        }

        [NotMapped]
        public Point CurrentLocation 
        { 
            get => new Point(CurrentLocationX, CurrentLocationY);
            set
            {
                CurrentLocationX = value.X;
                CurrentLocationY = value.Y;
            }
        }

        // Add these properties to store in database
        public int BindLocationX { get; set; }
        public int BindLocationY { get; set; }
        public int CurrentLocationX { get; set; }
        public int CurrentLocationY { get; set; }

        public int HP { get; set; }
        public int MP { get; set; }
        public long Experience { get; set; }

        public AttackMode AMode { get; set; }
        public PetMode PMode { get; set; }
        public bool AllowGroup { get; set; }
        public bool AllowTrade { get; set; }
        public bool AllowObserve { get; set; }

        public int PKPoints { get; set; }

        public bool NewDay { get; set; }

        public bool Thrusting { get; set; }
        public bool HalfMoon { get; set; }
        public bool CrossHalfMoon { get; set; }
        public bool DoubleSlash { get; set; }
        public byte MentalState { get; set; }
        public byte MentalStateLvl { get; set; }

        public string InventoryJson { get; set; }
        public string EquipmentJson { get; set; }
        public string TradeJson { get; set; }
        public string QuestInventoryJson { get; set; }
        public string RefineJson { get; set; }

        // These are the in-memory representations used in code as EF core can't handle arrays of objects
        [NotMapped]
        public UserItem[] Inventory { get; set; } = new UserItem[46];
        [NotMapped]
        public UserItem[] Equipment { get; set; } = new UserItem[14];
        [NotMapped]
        public UserItem[] Trade { get; set; } = new UserItem[10];
        [NotMapped]
        public UserItem[] QuestInventory { get; set; } = new UserItem[40];
        [NotMapped]
        public UserItem[] Refine { get; set; } = new UserItem[16];

        
        public List<ItemRentalInformation> RentedItems { get; set; } = new List<ItemRentalInformation>();
        public List<ItemRentalInformation> RentedItemsToRemove { get; set; } = new List<ItemRentalInformation>();
        public bool HasRentedItem { get; set; }
        public UserItem CurrentRefine { get; set; }
        public long CollectTime { get; set; }
        public List<UserMagic> Magics { get; set; } = new List<UserMagic>();
        public List<PetInfo> Pets { get; set; } = new List<PetInfo>();
        public List<Buff> Buffs { get; set; } = new List<Buff>();
        [NotMapped]
        public List<Poison> Poisons { get; set; } = new List<Poison>();
        public List<MailInfo> Mail { get; set; } = new List<MailInfo>();
        public List<FriendInfo> Friends { get; set; } = new List<FriendInfo>();

        public List<UserIntelligentCreature> IntelligentCreatures { get; set; } = new List<UserIntelligentCreature>();
        public int PearlCount { get; set; }

        public List<QuestProgressInfo> CurrentQuests { get; set; } = new List<QuestProgressInfo>();
        public List<int> CompletedQuests { get; set; } = new List<int>();

        public bool[] Flags { get; set; } = new bool[Globals.FlagIndexCount];


        public AccountInfo AccountInfo { get; set; }
        public PlayerObject Player { get; set; }
        public MountInfo Mount { get; set; }

        [NotMapped]
        public Dictionary<int, int> GSpurchases { get; set; } = new Dictionary<int, int>();

        [NotMapped]
        public int[] Rank = new int[2];//dont save this in db!(and dont send it to clients :p)
        
        public int MaximumHeroCount { get; set; } = 1;
        private string _heroesJson { get; set; }

        [NotMapped]
        public HeroInfo[] Heroes
        {
            get => string.IsNullOrEmpty(_heroesJson) 
                ? new HeroInfo[MaximumHeroCount] 
                : System.Text.Json.JsonSerializer.Deserialize<HeroInfo[]>(_heroesJson);
            set => _heroesJson = System.Text.Json.JsonSerializer.Serialize(value);
        }
        public int CurrentHeroIndex { get; set; }
        public bool HeroSpawned { get; set; }
        public HeroBehaviour HeroBehaviour { get; set; }

        public CharacterInfo() { }

        public CharacterInfo(ClientPackets.NewCharacter p, MirConnection c)
        {
            AccountInfo = c.Account;
            Name = p.Name;
            Class = p.Class;
            Gender = p.Gender;
            Heroes = new HeroInfo[MaximumHeroCount];

            CreationIP = c.IPAddress;
            CreationDate = Envir.Now;
        }

        public CharacterInfo(BinaryReader reader, int version, int customVersion)
        {
            Load(reader, version, customVersion);            
        }

        public virtual void Load(BinaryReader reader, int version, int customVersion)
        {
            Index = reader.ReadInt32();
            Name = reader.ReadString();

            if (version < 62)
            {
                Level = (ushort)reader.ReadByte();
            }
            else
            {
                Level = reader.ReadUInt16();
            }

            Class = (MirClass)reader.ReadByte();
            Gender = (MirGender)reader.ReadByte();
            Hair = reader.ReadByte();

            CreationIP = reader.ReadString();
            CreationDate = DateTime.FromBinary(reader.ReadInt64());

            Banned = reader.ReadBoolean();
            BanReason = reader.ReadString();
            ExpiryDate = DateTime.FromBinary(reader.ReadInt64());

            LastIP = reader.ReadString();
            LastLogoutDate = DateTime.FromBinary(reader.ReadInt64());

            if (version > 81)
            {
                LastLoginDate = DateTime.FromBinary(reader.ReadInt64());
            }

            Deleted = reader.ReadBoolean();
            DeleteDate = DateTime.FromBinary(reader.ReadInt64());

            CurrentMapIndex = reader.ReadInt32();
            CurrentLocation = new Point(reader.ReadInt32(), reader.ReadInt32());
            Direction = (MirDirection)reader.ReadByte();
            BindMapIndex = reader.ReadInt32();
            BindLocation = new Point(reader.ReadInt32(), reader.ReadInt32());

            if (version <= 84)
            {
                HP = reader.ReadUInt16();
                MP = reader.ReadUInt16();
            }
            else
            {
                HP = reader.ReadInt32();
                MP = reader.ReadInt32();
            }

            Experience = reader.ReadInt64();

            AMode = (AttackMode)reader.ReadByte();
            PMode = (PetMode)reader.ReadByte();

            if (version > 34)
            {
                PKPoints = reader.ReadInt32();
            }

            int count = reader.ReadInt32();

            var inventory = Inventory;
            Array.Resize(ref inventory, count);
            Inventory = inventory;

            for (int i = 0; i < count; i++)
            {
                if (!reader.ReadBoolean()) continue;
                UserItem item = new UserItem(reader, version, customVersion);
                if (Envir.BindItem(item) && i < Inventory.Length)
                {
                    Inventory[i] = item;
                }
            }

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                if (!reader.ReadBoolean()) continue;
                UserItem item = new UserItem(reader, version, customVersion);
                if (Envir.BindItem(item) && i < Equipment.Length)
                {
                    Equipment[i] = item;
                }
            }

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                if (!reader.ReadBoolean()) continue;
                UserItem item = new UserItem(reader, version, customVersion);
                if (Envir.BindItem(item) && i < QuestInventory.Length)
                {
                    QuestInventory[i] = item;
                }
            }

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                UserMagic magic = new UserMagic(reader, version, customVersion);
                if (magic.Info == null) continue;

                magic.CastTime = int.MinValue;
                Magics.Add(magic);
            }

            Thrusting = reader.ReadBoolean();
            HalfMoon = reader.ReadBoolean();
            CrossHalfMoon = reader.ReadBoolean();
            DoubleSlash = reader.ReadBoolean();

            MentalState = reader.ReadByte();

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Pets.Add(new PetInfo(reader, version, customVersion));
            }

            AllowGroup = reader.ReadBoolean();

            for (int i = 0; i < Globals.FlagIndexCount; i++)
            {
                Flags[i] = reader.ReadBoolean();
            }

            GuildIndex = reader.ReadInt32();

            AllowTrade = reader.ReadBoolean();
            if (version > 104)
                AllowObserve = reader.ReadBoolean();

            count = reader.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                QuestProgressInfo quest = new QuestProgressInfo(reader, version, customVersion);
                if (Envir.BindQuest(quest))
                {
                    CurrentQuests.Add(quest);
                }
            }

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Buff buff = new Buff(reader, version, customVersion);

                Buffs.Add(buff);
            }

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Mail.Add(new MailInfo(reader, version, customVersion));
            }

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                UserIntelligentCreature creature = new UserIntelligentCreature(reader, version, customVersion);
                if (creature.Info == null) continue;
                IntelligentCreatures.Add(creature);
            }

            if (version == 45)
            {
                var old1 = (IntelligentCreatureType)reader.ReadByte();
                var old2 = reader.ReadBoolean();
            }

            PearlCount = reader.ReadInt32();

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                CompletedQuests.Add(reader.ReadInt32());
            }

            if (reader.ReadBoolean())
            {
                CurrentRefine = new UserItem(reader, version, customVersion);
            }

            if (CurrentRefine != null)
            {
                Envir.BindItem(CurrentRefine);
            }

            CollectTime = reader.ReadInt64();
            CollectTime += Envir.Time;

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                Friends.Add(new FriendInfo(reader, version, customVersion));
            }

            if (version > 75)
            {
                count = reader.ReadInt32();
                for (var i = 0; i < count; i++)
                {
                    RentedItems.Add(new ItemRentalInformation(reader, version, customVersion));
                }

                HasRentedItem = reader.ReadBoolean();
            }

            Married = reader.ReadInt32();
            MarriedDate = DateTime.FromBinary(reader.ReadInt64());
            Mentor = reader.ReadInt32();
            MentorDate = DateTime.FromBinary(reader.ReadInt64());
            IsMentor = reader.ReadBoolean();
            MentorExp = reader.ReadInt64();

            if (version >= 63)
            {
                int logCount = reader.ReadInt32();

                for (int i = 0; i < logCount; i++)
                {
                    GSpurchases.Add(reader.ReadInt32(), reader.ReadInt32());
                }
            }

            if (version > 98)
            {
                MaximumHeroCount = reader.ReadInt32();
                Heroes = new HeroInfo[MaximumHeroCount];
                if (version > 102)
                {
                    for (int i = 0; i < MaximumHeroCount; i++)
                    {
                        int heroIndex = reader.ReadInt32();
                        if (heroIndex > 0)
                            Heroes[i] = Envir.GetHeroInfo(heroIndex);
                    }
                }
                else
                {
                    for (int i = 0; i < MaximumHeroCount; i++)
                        Heroes[i] = new HeroInfo(reader, version, customVersion);
                }

                if (version < 104) reader.ReadInt32();
                CurrentHeroIndex = reader.ReadInt32();
                HeroSpawned = reader.ReadBoolean();
            }
            else Heroes = new HeroInfo[MaximumHeroCount];

            if (version > 100)
                HeroBehaviour = (HeroBehaviour)reader.ReadByte();
        }

        public virtual void Save(BinaryWriter writer)
        {
            writer.Write(Index);
            writer.Write(Name);
            writer.Write(Level);
            writer.Write((byte) Class);
            writer.Write((byte) Gender);
            writer.Write(Hair);

            writer.Write(CreationIP);
            writer.Write(CreationDate.ToBinary());

            writer.Write(Banned);
            writer.Write(BanReason);
            writer.Write(ExpiryDate.ToBinary());

            writer.Write(LastIP);
            writer.Write(LastLogoutDate.ToBinary());
            writer.Write(LastLoginDate.ToBinary());

            writer.Write(Deleted);
            writer.Write(DeleteDate.ToBinary());

            writer.Write(CurrentMapIndex);
            writer.Write(CurrentLocation.X);
            writer.Write(CurrentLocation.Y);
            writer.Write((byte)Direction);
            writer.Write(BindMapIndex);
            writer.Write(BindLocation.X);
            writer.Write(BindLocation.Y);

            writer.Write(HP);
            writer.Write(MP);
            writer.Write(Experience);

            writer.Write((byte) AMode);
            writer.Write((byte) PMode);

            writer.Write(PKPoints);

            writer.Write(Inventory.Length);
            for (int i = 0; i < Inventory.Length; i++)
            {
                writer.Write(Inventory[i] != null);
                if (Inventory[i] == null) continue;

                Inventory[i].Save(writer);
            }

            writer.Write(Equipment.Length);
            for (int i = 0; i < Equipment.Length; i++)
            {
                writer.Write(Equipment[i] != null);
                if (Equipment[i] == null) continue;

                Equipment[i].Save(writer);
            }

            writer.Write(QuestInventory.Length);
            for (int i = 0; i < QuestInventory.Length; i++)
            {
                writer.Write(QuestInventory[i] != null);
                if (QuestInventory[i] == null) continue;

                QuestInventory[i].Save(writer);
            }

            writer.Write(Magics.Count);
            for (int i = 0; i < Magics.Count; i++)
            {
                Magics[i].Save(writer);
            }

            writer.Write(Thrusting);
            writer.Write(HalfMoon);
            writer.Write(CrossHalfMoon);
            writer.Write(DoubleSlash);
            writer.Write(MentalState);

            writer.Write(Pets.Count);
            for (int i = 0; i < Pets.Count; i++)
            {
                Pets[i].Save(writer);
            }

            writer.Write(AllowGroup);

            for (int i = 0; i < Flags.Length; i++)
            {
                writer.Write(Flags[i]);
            }

            writer.Write(GuildIndex);

            writer.Write(AllowTrade);
            writer.Write(AllowObserve);

            writer.Write(CurrentQuests.Count);
            for (int i = 0; i < CurrentQuests.Count; i++)
            {
                CurrentQuests[i].Save(writer);
            }

            writer.Write(Buffs.Count);
            for (int i = 0; i < Buffs.Count; i++)
            {
                Buffs[i].Save(writer);
            }

            writer.Write(Mail.Count);
            for (int i = 0; i < Mail.Count; i++)
            {
                Mail[i].Save(writer);
            }

            writer.Write(IntelligentCreatures.Count);
            for (int i = 0; i < IntelligentCreatures.Count; i++)
            {
                IntelligentCreatures[i].Save(writer);
            }

            writer.Write(PearlCount);

            writer.Write(CompletedQuests.Count);
            for (int i = 0; i < CompletedQuests.Count; i++)
            {
                writer.Write(CompletedQuests[i]);
            }


            writer.Write(CurrentRefine != null);
            if (CurrentRefine != null)
            {
                CurrentRefine.Save(writer);
            }

            if ((CollectTime - Envir.Time) < 0)
            {
                CollectTime = 0;
            }
            else
            {
                CollectTime -= Envir.Time;
            }

            writer.Write(CollectTime);

            writer.Write(Friends.Count);
            for (int i = 0; i < Friends.Count; i++)
            {
                if (Friends[i].Info == null) continue;
                Friends[i].Save(writer);
            }

            writer.Write(RentedItems.Count);
            foreach (var rentedItemInformation in RentedItems)
            {
                rentedItemInformation.Save(writer);
            }

            writer.Write(HasRentedItem);

            writer.Write(Married);
            writer.Write(MarriedDate.ToBinary());
            writer.Write(Mentor);
            writer.Write(MentorDate.ToBinary());
            writer.Write(IsMentor);
            writer.Write(MentorExp);

            writer.Write(GSpurchases.Count);

            foreach (var item in GSpurchases)
            {
                writer.Write(item.Key);
                writer.Write(item.Value);
            }

            writer.Write(MaximumHeroCount);
            for (int i = 0; i < Heroes.Length; i++)
                writer.Write(Heroes[i] != null ? Heroes[i].Index : 0);            
            writer.Write(CurrentHeroIndex);
            writer.Write(HeroSpawned);
            writer.Write((byte)HeroBehaviour);
        }

        public SelectInfo ToSelectInfo()
        {
            return new SelectInfo
                {
                    Index = Index,
                    Name = Name,
                    Level = Level,
                    Class = Class,
                    Gender = Gender,
                    LastAccess = LastLogoutDate
                };
        }

        public bool CheckHasIntelligentCreature(IntelligentCreatureType petType)
        {
            for (int i = 0; i < IntelligentCreatures.Count; i++)
            {
                if (IntelligentCreatures[i].PetType == petType) return true;
            }

            return false;
        }
        public virtual int ResizeInventory()
        {
            if (Inventory.Length >= 86) return Inventory.Length;

            var tempInventory = Inventory;

            if (tempInventory.Length == 46)
            {
                Array.Resize(ref tempInventory, tempInventory.Length + 8);
            }
            else
            {
                Array.Resize(ref tempInventory, tempInventory.Length + 4);
            }

            Inventory = tempInventory;

            return Inventory.Length;
        }
    }

    [Table("PetInfo")]
    public class PetInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MonsterIndex { get; set; }
        public int HP { get; set; }
        public uint Experience { get; set; }
        public byte Level { get; set; }
        public byte MaxPetLevel { get; set; }

        public long TameTime { get; set; }

        public PetInfo() { }

        public PetInfo(MonsterObject ob)
        {
            MonsterIndex = ob.Info.Index;
            HP = ob.HP;
            Experience = ob.PetExperience;
            Level = ob.PetLevel;
            MaxPetLevel = ob.MaxPetLevel;
        }

        public PetInfo(BinaryReader reader, int version, int customVersion)
        {
            MonsterIndex = reader.ReadInt32();
            if (MonsterIndex == 271) MonsterIndex = 275;

            if (version <= 84)
            {
                HP = (int)reader.ReadUInt32();
            }
            else
            {
                HP = reader.ReadInt32();
            }

            Experience = reader.ReadUInt32();
            Level = reader.ReadByte();
            MaxPetLevel = reader.ReadByte();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(MonsterIndex);
            writer.Write(HP);
            writer.Write(Experience);
            writer.Write(Level);
            writer.Write(MaxPetLevel);
        }
    }

    [Table("MountInfo")]
    public class MountInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [NotMapped]
        public HumanObject Player { get; set; }
        public short MountType { get; set; } = -1;

        public bool CanRide
        {
            get { return HasMount && Slots[(int)MountSlot.Saddle] != null; }
        }
        public bool CanMapRide
        {
            get { return HasMount && !Player.CurrentMap.Info.NoMount; }
        }
        public bool CanDungeonRide
        {
            get { return HasMount && CanMapRide && (!Player.CurrentMap.Info.NeedBridle || Slots[(int)MountSlot.Reins] != null); }
        }
        public bool CanAttack
        {
            get { return HasMount && Slots[(int)MountSlot.Bells] != null || !RidingMount; }
        }
        public bool SlowLoyalty
        {
            get { return HasMount && Slots[(int)MountSlot.Ribbon] != null; }
        }

        public bool HasMount
        {
            get { return Player.Info.Equipment[(int)EquipmentSlot.Mount] != null; }
        }

        private bool RidingMount
        {
            get { return Player.RidingMount; }
            set { Player.RidingMount = value; }
        }

        public UserItem[] Slots
        {
            get { return Player.Info.Equipment[(int)EquipmentSlot.Mount].Slots; }
        }

        public MountInfo() { }

        public MountInfo(HumanObject ob)
        {
            Player = ob;
        }
    }

    [Table("FriendInfo")]
    public class FriendInfo
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

        private CharacterInfo _Info;
        public CharacterInfo Info
        {
            get 
            {
                if (_Info == null)
                {
                    _Info = Envir.AccountService.GetCharacterByIndex(Index);
                }

                return _Info;
            }
        }

        public bool Blocked { get; set; }
        public string Memo { get; set; }

        public FriendInfo() { }

        public FriendInfo(CharacterInfo info, bool blocked) 
        {
            Index = info.Index;
            Blocked = blocked;
            Memo = "";
        }

        public FriendInfo(BinaryReader reader, int version, int customVersion)
        {
            Index = reader.ReadInt32();
            Blocked = reader.ReadBoolean();
            Memo = reader.ReadString();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Index);
            writer.Write(Blocked);
            writer.Write(Memo);
        }

        public ClientFriend CreateClientFriend()
        {
            return new ClientFriend()
            {
                Index = Index,
                Name = Info.Name,
                Blocked = Blocked,
                Memo = Memo,
                Online = Info.Player != null && Info.Player.Node != null
            };
        }
    }

    public class CharacterService : CacheService<CharacterInfo>
    {
        // Return the correct DbSet from your GameDbContext.
        protected override DbSet<CharacterInfo> GetDbSet(GameDbContext context)
        {
            return context.CharacterInfos;
        }

        // Override the Create method to handle the AccountInfo relationship
        public override void Create(CharacterInfo character)
        {
            using (var context = new GameDbContext())
            {
                // If the character has an AccountInfo reference
                if (character.AccountInfo != null)
                {
                    // Check if the account already exists in the database
                    var existingAccount = context.AccountInfos.Find(character.AccountInfo.Id);
                    if (existingAccount != null)
                    {
                        // Use the existing account reference instead of creating a new one
                        character.AccountInfo = existingAccount;
                    }
                }
                
                GetDbSet(context).Add(character);
                context.SaveChanges();
            }
            _cache.Add(character);
        }
    }
}
