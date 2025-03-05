using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.MirEnvir;
using Server.MirObjects;

namespace Server.MirDatabase
{
    public class GuildInfo
    {
        [Key]
        public int GuildIndex { get; set; } = 0;

        public string Name { get; set; } = "";

        public byte Level { get; set; }
        public byte SparePoints { get; set; }
        public long Experience { get; set; }
        public uint Gold { get; set; }

        public int Votes { get; set; }
        public DateTime LastVoteAttempt { get; set; }
        public bool Voting { get; set; }

        public int Membercount { get; set; }

        // Navigation properties
        public virtual List<GuildRank> Ranks { get; set; } = new List<GuildRank>();
        
        [NotMapped] 
        public GuildStorageItem[] StoredItems { get; set; } = new GuildStorageItem[112];
        
        public virtual List<GuildBuff> BuffList { get; set; } = new List<GuildBuff>();
        public virtual List<String> Notice { get; set; } = new List<String>();

        [NotMapped]
        public long MaxExperience { get; set; }
        
        public int MemberCap { get; set; }

        public ushort FlagImage { get; set; } = 1000;
        
        public int FlagColourArgb { get; set; } = Color.White.ToArgb();
        
        [NotMapped]
        public Color FlagColour 
        { 
            get => Color.FromArgb(FlagColourArgb);
            set => FlagColourArgb = value.ToArgb();
        }

        public DateTime GTRent { get; set; } = DateTime.MinValue;
        public DateTime GTBegin { get; set; } = DateTime.MinValue;
        public int GTIndex { get; set; } = -1;
        public int GTKey { get; set; }
        public int GTPrice { get; set; }

        [NotMapped]
        public bool NeedSave { get; set; }

        [NotMapped]
        protected static Envir Envir => Envir.Main;

        [NotMapped]
        public bool HasGT => GTRent > DateTime.Now;

        public GuildInfo()
        {
        }

        public GuildInfo(PlayerObject owner, string name)
        {
            Name = name;

            var ownerRank = new GuildRank { Name = "Leader", Options = (GuildRankOptions)255, Index = 0 };
            var leader = new GuildMember { Name = owner.Info.Name, Player = owner, Id = owner.Info.Index, LastLogin = Envir.Now, Online = true };

            ownerRank.Members.Add(leader);
            Ranks.Add(ownerRank);

            Membercount++;
            NeedSave = true;

            if (Level < Settings.Guild_ExperienceList.Count)
            {
                MaxExperience = Settings.Guild_ExperienceList[Level];
            }

            if (Name == Settings.NewbieGuild)
            {
                MemberCap = Settings.NewbieGuildMaxSize;
                Level = 21;
            }
            else if(Level < Settings.Guild_MembercapList.Count)
            {
                MemberCap = Settings.Guild_MembercapList[Level];
            }

            FlagColour = Color.FromArgb(255, Envir.Random.Next(255), Envir.Random.Next(255), Envir.Random.Next(255));
        }

        public GuildInfo(BinaryReader reader)
        {
            int customversion = Envir.LoadCustomVersion;
            int version = reader.ReadInt32();
            GuildIndex = version;

            if (version == int.MaxValue)
            {
                version = reader.ReadInt32();
                customversion = reader.ReadInt32();
                GuildIndex = reader.ReadInt32();
            }
            else
            {
                version = Envir.LoadVersion;
                NeedSave = true;
            }

            Name = reader.ReadString();
            Level = reader.ReadByte();
            SparePoints = reader.ReadByte();
            Experience = reader.ReadInt64();
            Gold = reader.ReadUInt32();
            Votes = reader.ReadInt32();
            LastVoteAttempt = DateTime.FromBinary(reader.ReadInt64());
            Voting = reader.ReadBoolean();

            int rankCount = reader.ReadInt32();
            Membercount = 0;

            for (int i = 0; i < rankCount; i++)
            {
                int index = i;
                Ranks.Add(new GuildRank(reader, true) { Index = index });
                Membercount += Ranks[i].Members.Count;
            }

            int itemCount = reader.ReadInt32();
            for (int j = 0; j < itemCount; j++)
            {
                if (!reader.ReadBoolean()) continue;

                GuildStorageItem Guilditem = new GuildStorageItem()
                {
                    Item = new UserItem(reader, version, customversion),
                    UserId = reader.ReadInt64()
                };

                if (Envir.BindItem(Guilditem.Item) && j < StoredItems.Length)
                    StoredItems[j] = Guilditem;
            }

            int buffCount = reader.ReadInt32();
            if (version < 61)
            {
                for (int j = 0; j < buffCount; j++)
                    new GuildBuffOld(reader);
            }
            else
            {
                for (int j = 0; j < buffCount; j++)
                {
                    BuffList.Add(new GuildBuff(reader));
                }
            }

            for (int j = 0; j < BuffList.Count; j++)
            {
                BuffList[j].Info = Envir.FindGuildBuffInfo(BuffList[j].Id);
            }

            int noticeCount = reader.ReadInt32();
            for (int j = 0; j < noticeCount; j++)
            {
                Notice.Add(reader.ReadString());
            }

            if (Level < Settings.Guild_ExperienceList.Count)
            {
                MaxExperience = Settings.Guild_ExperienceList[Level];
            }

            if (Name == Settings.NewbieGuild)
            {
                MemberCap = Settings.NewbieGuildMaxSize;
            }
            else if (Level < Settings.Guild_MembercapList.Count)
            {
                MemberCap = Settings.Guild_MembercapList[Level];
            }

            if (version > 72)
            {
                FlagImage = reader.ReadUInt16();
                FlagColour = Color.FromArgb(reader.ReadInt32());
            }

            if (version > 110)
            {
                GTRent = DateTime.FromBinary(reader.ReadInt64());
                GTIndex = reader.ReadInt32();
                GTKey = reader.ReadInt32();
                GTPrice = reader.ReadInt32();
                GTBegin = DateTime.FromBinary(reader.ReadInt64());
            }
        }

        public void Save(BinaryWriter writer)
        {
            int temp = int.MaxValue;
            writer.Write(temp);
            writer.Write(Envir.Version);
            writer.Write(Envir.CustomVersion);

            int rankCount = 0;
            for (int i = Ranks.Count - 1; i >= 0; i--)
            {
                if (Ranks[i].Members.Count > 0)
                {
                    rankCount++;
                }
            }

            writer.Write(GuildIndex);
            writer.Write(Name);
            writer.Write(Level);
            writer.Write(SparePoints);
            writer.Write(Experience);
            writer.Write(Gold);
            writer.Write(Votes);
            writer.Write(LastVoteAttempt.ToBinary());
            writer.Write(Voting);

            writer.Write(rankCount);
            for (int i = 0; i < Ranks.Count; i++)
            {
                if (Ranks[i].Members.Count > 0)
                {
                    Ranks[i].Save(writer, true);
                }
            }

            writer.Write(StoredItems.Length);
            for (int i = 0; i < StoredItems.Length; i++)
            {
                writer.Write(StoredItems[i] != null);
                if (StoredItems[i] != null)
                {
                    StoredItems[i].Item.Save(writer);
                    writer.Write(StoredItems[i].UserId);
                }
            }

            writer.Write(BuffList.Count);
            for (int i = 0; i < BuffList.Count; i++)
            {
                BuffList[i].Save(writer);
            }

            writer.Write(Notice.Count);
            for (int i = 0; i < Notice.Count; i++)
            {
                writer.Write(Notice[i]);
            }

            writer.Write(FlagImage);
            writer.Write(FlagColour.ToArgb());

            writer.Write(GTRent.ToBinary());
            writer.Write(GTIndex);
            writer.Write(GTKey);
            writer.Write(GTPrice);
            writer.Write(GTBegin.ToBinary());
        }
    }

    public class GuildNotice
    {
        [Key]
        public int Id { get; set; }
        
        public int GuildInfoId { get; set; }
        public string Content { get; set; } = "";
        
        [ForeignKey("GuildInfoId")]
        public virtual GuildInfo Guild { get; set; }
    }
}
