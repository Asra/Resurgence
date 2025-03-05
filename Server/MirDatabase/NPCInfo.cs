using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text.Json;
﻿using Server.MirEnvir;

namespace Server.MirDatabase
{
    public class NPCInfo
    {
        protected static Envir EditEnvir
        {
            get { return Envir.Edit; }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key

        public int Index { get; set; } 

        public string FileName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public int MapIndex { get; set; }

        // Store Location as X and Y (since EF Core does not support System.Drawing.Point)
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        public ushort Rate { get; set; } = 100;
        public ushort Image { get; set; }

        // Store Color as a string (Hex format)
        public string ColourHex { get; set; } = "#FFFFFF"; 

        public bool TimeVisible { get; set; } = false;
        public byte HourStart { get; set; } = 0;
        public byte MinuteStart { get; set; } = 0;
        public byte HourEnd { get; set; } = 0;
        public byte MinuteEnd { get; set; } = 1;
        public short MinLev { get; set; } = 0;
        public short MaxLev { get; set; } = 0;
        public string DayofWeek { get; set; } = "";
        public string ClassRequired { get; set; } = "";
        public bool Sabuk { get; set; } = false;
        public int FlagNeeded { get; set; } = 0;
        public int Conquest { get; set; }
        public bool ShowOnBigMap { get; set; }
        public int BigMapIcon { get; set; }
        public bool CanTeleportTo { get; set; }
        public bool ConquestVisible { get; set; } = true;

        // Store List<int> as JSON string
        public string CollectQuestIndexesJson
        {
            get => JsonSerializer.Serialize(CollectQuestIndexes);
            set => CollectQuestIndexes = string.IsNullOrEmpty(value)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(value);
        }

        [NotMapped] // Not stored in the database directly
        public List<int> CollectQuestIndexes { get; set; } = new List<int>();

        public string FinishQuestIndexesJson
        {
            get => JsonSerializer.Serialize(FinishQuestIndexes);
            set => FinishQuestIndexes = string.IsNullOrEmpty(value)
                ? new List<int>()
                : JsonSerializer.Deserialize<List<int>>(value);
        }

        [NotMapped]
        public List<int> FinishQuestIndexes { get; set; } = new List<int>();

        // NotMapped property to allow using System.Drawing.Point
        [NotMapped]
        public System.Drawing.Point Location
        {
            get => new System.Drawing.Point(LocationX, LocationY);
            set
            {
                LocationX = value.X;
                LocationY = value.Y;
            }
        }

        [NotMapped]
        public System.Drawing.Color Colour
        {
            get => ColorTranslator.FromHtml(ColourHex); // Convert from hex string to Color
            set => ColourHex = ColorTranslator.ToHtml(value); // Convert from Color to hex string
        }


        
        public NPCInfo() { }
        public NPCInfo(BinaryReader reader)
        {
            Index = reader.ReadInt32();
            MapIndex = reader.ReadInt32();

            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
                CollectQuestIndexes.Add(reader.ReadInt32());

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
                FinishQuestIndexes.Add(reader.ReadInt32());

            FileName = reader.ReadString();
            Name = reader.ReadString();

            Location = new Point(reader.ReadInt32(), reader.ReadInt32());

            if (Envir.LoadVersion >= 72)
            {
                Image = reader.ReadUInt16();
            }
            else
            {
                Image = reader.ReadByte();
            }
            
            Rate = reader.ReadUInt16();

            if (Envir.LoadVersion >= 64)
            {
                TimeVisible = reader.ReadBoolean();
                HourStart = reader.ReadByte();
                MinuteStart = reader.ReadByte();
                HourEnd = reader.ReadByte();
                MinuteEnd = reader.ReadByte();
                MinLev = reader.ReadInt16();
                MaxLev = reader.ReadInt16();
                DayofWeek = reader.ReadString();
                ClassRequired = reader.ReadString();
                if (Envir.LoadVersion >= 66)
                    Conquest = reader.ReadInt32();
                else
                    Sabuk = reader.ReadBoolean();
                FlagNeeded = reader.ReadInt32();
            }

            if (Envir.LoadVersion > 95)
            {
                ShowOnBigMap = reader.ReadBoolean();
                BigMapIcon = reader.ReadInt32();
            }
            if (Envir.LoadVersion > 96)
                CanTeleportTo = reader.ReadBoolean();

            if (Envir.LoadVersion >= 107)
            {
                ConquestVisible = reader.ReadBoolean();
            }
        }
        public void Save(BinaryWriter writer)
        {
            writer.Write(Index);
            writer.Write(MapIndex);

            writer.Write(CollectQuestIndexes.Count());
            for (int i = 0; i < CollectQuestIndexes.Count; i++)
                writer.Write(CollectQuestIndexes[i]);

            writer.Write(FinishQuestIndexes.Count());
            for (int i = 0; i < FinishQuestIndexes.Count; i++)
                writer.Write(FinishQuestIndexes[i]);

            writer.Write(FileName);
            writer.Write(Name);

            writer.Write(Location.X);
            writer.Write(Location.Y);
            writer.Write(Image);
            writer.Write(Rate);

            writer.Write(TimeVisible);
            writer.Write(HourStart);
            writer.Write(MinuteStart);
            writer.Write(HourEnd);
            writer.Write(MinuteEnd);
            writer.Write(MinLev);
            writer.Write(MaxLev);
            writer.Write(DayofWeek);
            writer.Write(ClassRequired);
            writer.Write(Conquest);
            writer.Write(FlagNeeded);

            writer.Write(ShowOnBigMap);
            writer.Write(BigMapIcon);
            writer.Write(CanTeleportTo);
            writer.Write(ConquestVisible);
        }

        public static void FromText(string text)
        {
            string[] data = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length < 6) return;

            NPCInfo info = new NPCInfo { Name = data[0] };

            int x, y;

            info.FileName = data[0];
            info.MapIndex = EditEnvir.MapInfoList.Where(d => d.FileName == data[1]).FirstOrDefault().Index;

            if (!int.TryParse(data[2], out x)) return;
            if (!int.TryParse(data[3], out y)) return;

            info.Location = new Point(x, y);

            info.Name = data[4];

            ushort image, rate;
            bool showOnBigMap, canTeleportTo, conquestVisible, timeVisible;
            int bigMapIcon;
            short minLev, maxLev;
            byte hourStart, minuteStart, hourEnd, minuteEnd;


            // Parse values into temporary variables first
            if (!ushort.TryParse(data[5], out image)) return;
            if (!ushort.TryParse(data[6], out rate)) return;

            if (!bool.TryParse(data[7], out showOnBigMap)) return;
            if (!int.TryParse(data[8], out bigMapIcon)) return;
            if (!bool.TryParse(data[9], out canTeleportTo)) return;
            if (!bool.TryParse(data[10], out conquestVisible)) return;
            if (!short.TryParse(data[11], out minLev)) return;
            if (!short.TryParse(data[12], out maxLev)) return;
            if (!bool.TryParse(data[13], out timeVisible)) return;
            if (!byte.TryParse(data[14], out hourStart)) return;
            if (!byte.TryParse(data[15], out minuteStart)) return;
            if (!byte.TryParse(data[16], out hourEnd)) return;
            if (!byte.TryParse(data[17], out minuteEnd)) return;

            // Assign parsed values to object properties
            info.Image = image;
            info.Rate = rate;
            info.ShowOnBigMap = showOnBigMap;
            info.BigMapIcon = bigMapIcon;
            info.CanTeleportTo = canTeleportTo;
            info.ConquestVisible = conquestVisible;
            info.MinLev = minLev;
            info.MaxLev = maxLev;
            info.TimeVisible = timeVisible;
            info.HourStart = hourStart;
            info.MinuteStart = minuteStart;
            info.HourEnd = hourEnd;
            info.MinuteEnd = minuteEnd;

            info.Index = ++EditEnvir.NPCIndex;
            EditEnvir.NPCInfoList.Add(info);
        }
        public string ToText()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17}",
                FileName, EditEnvir.MapInfoList.Where(d => d.Index == MapIndex).FirstOrDefault().FileName, Location.X, Location.Y, Name, Image, Rate, ShowOnBigMap, BigMapIcon, CanTeleportTo, ConquestVisible,
                MinLev, MaxLev, TimeVisible, HourStart, MinuteStart, HourEnd, MinuteEnd);
        }

        public override string ToString()
        {
            return string.Format("{0}:   {1}", FileName, Functions.PointToString(Location));
        }

        public string GameName
        {
            get
            {
                string s = Name;
                if (s.Contains("_"))
                {
                    string[] splitName = s.Split('_');
                    s = splitName[splitName.Length - 1];
                }
                return s;
            }
        }
    }
}
