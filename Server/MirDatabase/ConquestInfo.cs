using System.Drawing;
﻿using Server.MirEnvir;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Server.MirDatabase
{
    [Table("ConquestInfo")]
    public class ConquestInfo
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Index { get; set; }
        public bool FullMap { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        [NotMapped]
        public Point Location
        {
            get => new Point(LocationX, LocationY);
            set
            {
                LocationX = value.X;
                LocationY = value.Y;
            }
        }
        public ushort Size { get; set; }
        public string Name { get; set; }
        public int MapIndex { get; set; }
        public int PalaceIndex { get; set; }

        public List<int> ExtraMaps { get; set; } = new List<int>();
        public List<ConquestArcherInfo> ConquestGuards { get; set; } = new List<ConquestArcherInfo>();
        public List<ConquestGateInfo> ConquestGates { get; set; } = new List<ConquestGateInfo>();
        public List<ConquestWallInfo> ConquestWalls { get; set; } = new List<ConquestWallInfo>();
        public List<ConquestSiegeInfo> ConquestSieges { get; set; } = new List<ConquestSiegeInfo>();
        public List<ConquestFlagInfo> ConquestFlags { get; set; } = new List<ConquestFlagInfo>();

        public int GuardIndex { get; set; }
        public int GateIndex { get; set; }
        public int WallIndex { get; set; }
        public int SiegeIndex { get; set; }
        public int FlagIndex { get; set; }

        public byte StartHour { get; set; } = 0;
        public int WarLength { get; set; } = 60;

        public ConquestType Type { get; set; } = ConquestType.Request;
        public ConquestGame Game { get; set; } = ConquestGame.CapturePalace;

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        //King of the hill
        public int KingLocationX { get; set; }
        public int KingLocationY { get; set; }

        [NotMapped]
        public Point KingLocation
        {
            get => new Point(KingLocationX, KingLocationY);
            set
            {
                KingLocationX = value.X;
                KingLocationY = value.Y;
            }
        }

        public ushort KingSize { get; set; }

        //Control points
        public List<ConquestFlagInfo> ControlPoints { get; set; } = new List<ConquestFlagInfo>();
        public int ControlPointIndex { get; set; }

        public ConquestInfo() { }

        public ConquestInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();

            if (Envir.LoadVersion > 73)
            {
                FullMap = reader.ReadBoolean();
            }

            Location = new Point(reader.ReadInt32(), reader.ReadInt32());
            Size = reader.ReadUInt16();
            Name = reader.ReadString();
            MapIndex = reader.ReadInt32();
            PalaceIndex = reader.ReadInt32();
            GuardIndex = reader.ReadInt32();
            GateIndex = reader.ReadInt32();
            WallIndex = reader.ReadInt32();
            SiegeIndex = reader.ReadInt32();

            if (Envir.LoadVersion > 72)
            {
                FlagIndex = reader.ReadInt32();
            }

            var counter = reader.ReadInt32();
            for (int i = 0; i < counter; i++)
            {
                ConquestGuards.Add(new ConquestArcherInfo(reader));
            }

            counter = reader.ReadInt32();
            for (int i = 0; i < counter; i++)
            {
                ExtraMaps.Add(reader.ReadInt32());
            }

            counter = reader.ReadInt32();
            for (int i = 0; i < counter; i++)
            {
                ConquestGates.Add(new ConquestGateInfo(reader));
            }

            counter = reader.ReadInt32();
            for (int i = 0; i < counter; i++)
            {
                ConquestWalls.Add(new ConquestWallInfo(reader));
            }

            counter = reader.ReadInt32();
            for (int i = 0; i < counter; i++)
            {
                ConquestSieges.Add(new ConquestSiegeInfo(reader));
            }

            if (Envir.LoadVersion > 72)
            {
                counter = reader.ReadInt32();
                for (int i = 0; i < counter; i++)
                {
                    ConquestFlags.Add(new ConquestFlagInfo(reader));
                }
            }

            StartHour = reader.ReadByte();
            WarLength = reader.ReadInt32();
            Type = (ConquestType)reader.ReadByte();
            Game = (ConquestGame)reader.ReadByte();

            Monday = reader.ReadBoolean();
            Tuesday = reader.ReadBoolean();
            Wednesday = reader.ReadBoolean();
            Thursday = reader.ReadBoolean();
            Friday = reader.ReadBoolean();
            Saturday = reader.ReadBoolean();
            Sunday = reader.ReadBoolean();

            KingLocation = new Point(reader.ReadInt32(), reader.ReadInt32());
            KingSize = reader.ReadUInt16();

            if (Envir.LoadVersion > 74)
            {
                ControlPointIndex = reader.ReadInt32();
                counter = reader.ReadInt32();
                for (int i = 0; i < counter; i++)
                {
                    ControlPoints.Add(new ConquestFlagInfo(reader));
                }
            }
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Index);
            writer.Write(FullMap);
            writer.Write(Location.X);
            writer.Write(Location.Y);
            writer.Write(Size);
            writer.Write(Name);
            writer.Write(MapIndex);
            writer.Write(PalaceIndex);
            writer.Write(GuardIndex);
            writer.Write(GateIndex);
            writer.Write(WallIndex);
            writer.Write(SiegeIndex);
            writer.Write(FlagIndex);

            writer.Write(ConquestGuards.Count);
            for (int i = 0; i < ConquestGuards.Count; i++)
            {
                ConquestGuards[i].Save(writer);
            }

            writer.Write(ExtraMaps.Count);
            for (int i = 0; i < ExtraMaps.Count; i++)
            {
                writer.Write(ExtraMaps[i]);
            }

            writer.Write(ConquestGates.Count);
            for (int i = 0; i < ConquestGates.Count; i++)
            {
                ConquestGates[i].Save(writer);
            }

            writer.Write(ConquestWalls.Count);
            for (int i = 0; i < ConquestWalls.Count; i++)
            {
                ConquestWalls[i].Save(writer);
            }

            writer.Write(ConquestSieges.Count);
            for (int i = 0; i < ConquestSieges.Count; i++)
            {
                ConquestSieges[i].Save(writer);
            }

            writer.Write(ConquestFlags.Count);
            for (int i = 0; i < ConquestFlags.Count; i++)
            {
                ConquestFlags[i].Save(writer);
            }

            writer.Write(StartHour);
            writer.Write(WarLength);
            writer.Write((byte)Type);
            writer.Write((byte)Game);

            writer.Write(Monday);
            writer.Write(Tuesday);
            writer.Write(Wednesday);
            writer.Write(Thursday);
            writer.Write(Friday);
            writer.Write(Saturday);
            writer.Write(Sunday);

            writer.Write(KingLocation.X);
            writer.Write(KingLocation.Y);
            writer.Write(KingSize);

            writer.Write(ControlPointIndex);
            writer.Write(ControlPoints.Count);
            for (int i = 0; i < ControlPoints.Count; i++)
            {
                ControlPoints[i].Save(writer);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}- {1}", Index, Name);
        }
    }

    [Table("ConquestSiegeInfo")]
    public class ConquestSiegeInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Index { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        [NotMapped]
        public Point Location
        {
            get => new Point(LocationX, LocationY);
            set
            {
                LocationX = value.X;
                LocationY = value.Y;
            }
        }

        public int MobIndex { get; set; }
        public string Name { get; set; }
        public int RepairCost { get; set; }

        public ConquestSiegeInfo() { }

        public ConquestSiegeInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();
            Location = new Point(reader.ReadInt32(), reader.ReadInt32());
            MobIndex = reader.ReadInt32();
            Name = reader.ReadString();

            if (Envir.LoadVersion <= 84)
            {
                RepairCost = (int)reader.ReadUInt32();
            }
            else
            {
                RepairCost = reader.ReadInt32();
            }
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Index);
            writer.Write(Location.X);
            writer.Write(Location.Y);
            writer.Write(MobIndex);
            writer.Write(Name);
            writer.Write(RepairCost);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} ({2})", Index, Name, Location);
        }
    }

    [Table("ConquestWallInfo")]
    public class ConquestWallInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Index { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        [NotMapped]
        public Point Location
        {
            get => new Point(LocationX, LocationY);
            set
            {
                LocationX = value.X;
                LocationY = value.Y;
            }
        }

        public int MobIndex { get; set; }
        public string Name { get; set; }
        public int RepairCost { get; set; }

        public ConquestWallInfo() { }

        public ConquestWallInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();
            Location = new Point(reader.ReadInt32(), reader.ReadInt32());
            MobIndex = reader.ReadInt32();
            Name = reader.ReadString();

            if (Envir.LoadVersion <= 84)
            {
                RepairCost = (int)reader.ReadUInt32();
            }
            else
            {
                RepairCost = reader.ReadInt32();
            }
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Index);
            writer.Write(Location.X);
            writer.Write(Location.Y);
            writer.Write(MobIndex);
            writer.Write(Name);
            writer.Write(RepairCost);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} ({2})", Index, Name, Location);
        }
    }

    [Table("ConquestGateInfo")]
    public class ConquestGateInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Index { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        [NotMapped]
        public Point Location
        {
            get => new Point(LocationX, LocationY);
            set
            {
                LocationX = value.X;
                LocationY = value.Y;
            }
        }

        public int MobIndex { get; set; }
        public string Name { get; set; }
        public int RepairCost { get; set; }

        public ConquestGateInfo() { }

        public ConquestGateInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();
            Location = new Point(reader.ReadInt32(), reader.ReadInt32());
            MobIndex = reader.ReadInt32();
            Name = reader.ReadString();

            if (Envir.LoadVersion <= 84)
            {
                RepairCost = (int)reader.ReadUInt32();
            }
            else
            {
                RepairCost = reader.ReadInt32();
            }
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Index);
            writer.Write(Location.X);
            writer.Write(Location.Y);
            writer.Write(MobIndex);
            writer.Write(Name);
            writer.Write(RepairCost);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} ({2})", Index, Name, Location);
        }
    }

    [Table("ConquestArcherInfo")]
    public class ConquestArcherInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Index { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        [NotMapped]
        public Point Location
        {
            get => new Point(LocationX, LocationY);
            set
            {
                LocationX = value.X;
                LocationY = value.Y;
            }
        }
        public int MobIndex { get; set; }
        public string Name { get; set; }
        public uint RepairCost { get; set; }

        public ConquestArcherInfo() { }

        public ConquestArcherInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();
            Location = new Point(reader.ReadInt32(), reader.ReadInt32());
            MobIndex = reader.ReadInt32();
            Name = reader.ReadString();
            RepairCost = reader.ReadUInt32();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Index);
            writer.Write(Location.X);
            writer.Write(Location.Y);
            writer.Write(MobIndex);
            writer.Write(Name);
            writer.Write(RepairCost);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} ({2})", Index, Name, Location);
        }
    }

    [Table("ConquestFlagInfo")]
    public class ConquestFlagInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Index { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        [NotMapped]
        public Point Location
        {
            get => new Point(LocationX, LocationY);
            set
            {
                LocationX = value.X;
                LocationY = value.Y;
            }
        }

        public string Name { get; set; }
        public string FileName { get; set; } = string.Empty;

        public ConquestFlagInfo() { }

        public ConquestFlagInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();
            Location = new Point(reader.ReadInt32(), reader.ReadInt32());
            Name = reader.ReadString();
            FileName = reader.ReadString();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Index);
            writer.Write(Location.X);
            writer.Write(Location.Y);
            writer.Write(Name);
            writer.Write(FileName);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} ({2})", Index, Name, Location);
        }
    }
}
