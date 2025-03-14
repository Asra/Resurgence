using Server.MirEnvir;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.MirDatabase
{
    [Table("IntelligentCreatureInfo")]
    public class IntelligentCreatureInfo
    {
        [NotMapped]
        protected static Envir Envir
        {
            get { return Envir.Main; }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public static List<IntelligentCreatureInfo> Creatures { get; set; } = new List<IntelligentCreatureInfo>();

        public IntelligentCreatureType PetType { get; set; }

        public int Icon{ get; set; }
        public int MinimalFullness { get; set; } = 1000;

        public bool MousePickupEnabled { get; set; } = false;
        public int MousePickupRange { get; set; } = 0;
        public bool AutoPickupEnabled { get; set; } = false;
        public int AutoPickupRange { get; set; } = 0;
        public bool SemiAutoPickupEnabled { get; set; } = false;
        public int SemiAutoPickupRange { get; set; } = 0;

        public bool CanProduceBlackStone { get; set; } = false;

        static IntelligentCreatureInfo()
        {
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.BabyPig, Icon = 500, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 3, MinimalFullness = 4000 };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.Chick, Icon = 501, MousePickupEnabled = true, MousePickupRange = 11, AutoPickupEnabled = true, AutoPickupRange = 7, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 7, CanProduceBlackStone = true };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.Kitten, Icon = 502, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 3, MinimalFullness = 6000 };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.BabySkeleton, Icon = 503, MousePickupEnabled = true, MousePickupRange = 11, AutoPickupEnabled = true, AutoPickupRange = 7, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 7, CanProduceBlackStone = true };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.Baekdon, Icon = 504, MousePickupEnabled = true, MousePickupRange = 11, AutoPickupEnabled = true, AutoPickupRange = 7, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 7, CanProduceBlackStone = true };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.Wimaen, Icon = 505, MousePickupEnabled = true, MousePickupRange = 7, AutoPickupEnabled = true, AutoPickupRange = 5, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 5, MinimalFullness = 5000 };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.BlackKitten, Icon = 506, MousePickupEnabled = true, MousePickupRange = 7, AutoPickupEnabled = true, AutoPickupRange = 5, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 5, MinimalFullness = 5000 };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.BabyDragon, Icon = 507, MousePickupEnabled = true, MousePickupRange = 7, AutoPickupEnabled = true, AutoPickupRange = 5, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 5, MinimalFullness = 7000 };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.OlympicFlame, Icon = 508, MousePickupEnabled = true, MousePickupRange = 11, AutoPickupEnabled = true, AutoPickupRange = 11, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 11, CanProduceBlackStone = true };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.BabySnowMan, Icon = 509, MousePickupEnabled = true, MousePickupRange = 11, AutoPickupEnabled = true, AutoPickupRange = 11, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 11, CanProduceBlackStone = true };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.Frog, Icon = 510, MousePickupEnabled = true, MousePickupRange = 11, AutoPickupEnabled = true, AutoPickupRange = 11, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 11, CanProduceBlackStone = true };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.BabyMonkey, Icon = 511, MousePickupEnabled = true, MousePickupRange = 11, AutoPickupEnabled = true, AutoPickupRange = 11, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 11, CanProduceBlackStone = true };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.AngryBird, Icon = 512, MousePickupEnabled = true, MousePickupRange = 11, AutoPickupEnabled = true, AutoPickupRange = 11, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 11, CanProduceBlackStone = true };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.Foxey, Icon = 513, MousePickupEnabled = true, MousePickupRange = 11, AutoPickupEnabled = true, AutoPickupRange = 11, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 11, CanProduceBlackStone = true };
            new IntelligentCreatureInfo { PetType = IntelligentCreatureType.MedicalRat, Icon = 514, MousePickupEnabled = true, MousePickupRange = 11, AutoPickupEnabled = true, AutoPickupRange = 11, SemiAutoPickupEnabled = true, SemiAutoPickupRange = 11, CanProduceBlackStone = true };
        }

        public IntelligentCreatureInfo()
        {
            Creatures.Add(this);
        }

        public static IntelligentCreatureInfo GetCreatureInfo(IntelligentCreatureType petType)
        {
            for (int i = 0; i < Creatures.Count; i++)
            {
                IntelligentCreatureInfo info = Creatures[i];
                if (info.PetType != petType) continue;
                return info;
            }
            return null;
        }
    }

    [Table("UserIntelligentCreature")]
    public class UserIntelligentCreature
    {
        [NotMapped]
        protected static Envir Envir
        {
            get { return Envir.Main; }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public IntelligentCreatureType PetType { get; set; }
        public IntelligentCreatureInfo Info { get; set; }
        public IntelligentCreatureItemFilter Filter { get; set; }

        public IntelligentCreaturePickupMode petMode { get; set; } = IntelligentCreaturePickupMode.SemiAutomatic;

        public string CustomName { get; set; }
        public int Fullness { get; set; }
        public int SlotIndex { get; set; }
        public DateTime Expire { get; set; }
        public long BlackstoneTime { get; set; } = 0;
        public long MaintainFoodTime { get; set; } = 0;

        public UserIntelligentCreature() { }

        public UserIntelligentCreature(IntelligentCreatureType creatureType, int slot, byte effect = 0)
        {
            PetType = creatureType;
            Info = IntelligentCreatureInfo.GetCreatureInfo(PetType);
            CustomName = Envir.Main.GetMonsterInfo(64, (byte)PetType)?.Name ?? PetType.ToString();
            Fullness = 7500;//starts at 75% food
            SlotIndex = slot;

            if (effect > 0) Expire = Envir.Now.AddDays(effect);//effect holds the amount in days
            else Expire = DateTime.MinValue;//permanent

            BlackstoneTime = 0;
            MaintainFoodTime = 0;

            Filter = new IntelligentCreatureItemFilter();
        }

        public UserIntelligentCreature(BinaryReader reader, int version, int customVersion)
        {
            PetType = (IntelligentCreatureType)reader.ReadByte();
            Info = IntelligentCreatureInfo.GetCreatureInfo(PetType);

            CustomName = reader.ReadString();
            Fullness = reader.ReadInt32();
            SlotIndex = reader.ReadInt32();

            var expireTime = reader.ReadInt64();

            if (expireTime == -9999)
            {
                Expire = DateTime.MinValue;
            }
            else
            {
                Expire = Envir.Now.AddSeconds(expireTime);
            }

            BlackstoneTime = reader.ReadInt64();

            petMode = (IntelligentCreaturePickupMode)reader.ReadByte();

            Filter = new IntelligentCreatureItemFilter(reader);
            if (version > 48)
            {
                Filter.PickupGrade = (ItemGrade)reader.ReadByte();

                MaintainFoodTime = reader.ReadInt64();//maintain food buff
            }
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write((byte)PetType);

            writer.Write(CustomName);
            writer.Write(Fullness);
            writer.Write(SlotIndex);

            if (Expire == DateTime.MinValue)
            {
                writer.Write((long)-9999);
            }
            else
            {
                writer.Write((long)(Expire - Envir.Now).TotalSeconds);
            }

            writer.Write(BlackstoneTime);

            writer.Write((byte)petMode);

            Filter.Save(writer);
            writer.Write((byte)Filter.PickupGrade);//since Envir.Version 49

            writer.Write(MaintainFoodTime);//maintain food buff

        }

        public Packet GetInfo()
        {
            return new ServerPackets.NewIntelligentCreature
            {
                Creature = CreateClientIntelligentCreature()
            };
        }

        public ClientIntelligentCreature CreateClientIntelligentCreature()
        {
            return new ClientIntelligentCreature
            {
                PetType = PetType,
                Icon = Info.Icon,
                CustomName = CustomName,
                Fullness = Fullness,
                SlotIndex = SlotIndex,
                Expire = Expire,
                BlackstoneTime = BlackstoneTime,
                MaintainFoodTime = MaintainFoodTime,

                petMode = petMode,

                CreatureRules = new IntelligentCreatureRules
                {
                    MinimalFullness = Info.MinimalFullness,
                    MousePickupEnabled = Info.MousePickupEnabled,
                    MousePickupRange = Info.MousePickupRange,
                    AutoPickupEnabled = Info.AutoPickupEnabled,
                    AutoPickupRange = Info.AutoPickupRange,
                    SemiAutoPickupEnabled = Info.SemiAutoPickupEnabled,
                    SemiAutoPickupRange = Info.SemiAutoPickupRange,
                    CanProduceBlackStone = Info.CanProduceBlackStone
                },

                Filter = Filter
            };
        }
    }
}
