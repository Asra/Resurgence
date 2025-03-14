using System.Drawing;
﻿using Server.MirEnvir;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.MirDatabase
{
    [Table("MovementInfos")]
    public class MovementInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MapIndex { get; set; }

        public int SourceX { get; set; }
        public int SourceY { get; set; }
        public int DestinationX { get; set; }
        public int DestinationY { get; set; }

        public bool NeedHole { get; set; }
        public bool NeedMove { get; set; }
        public bool ShowOnBigMap { get; set; }

        public int ConquestIndex { get; set; }
        public int Icon { get; set; }

        [NotMapped]
        public System.Drawing.Point Source
        {
            get => new System.Drawing.Point(SourceX, SourceY);
            set
            {
                SourceX = value.X;
                SourceY = value.Y;
            }
        }

        [NotMapped]
        public System.Drawing.Point Destination
        {
            get => new System.Drawing.Point(DestinationX, DestinationY);
            set
            {
                DestinationX = value.X;
                DestinationY = value.Y;
            }
        }

        public MovementInfo() { }

        public MovementInfo(BinaryReader reader)
        {
            MapIndex = reader.ReadInt32();
            Source = new Point(reader.ReadInt32(), reader.ReadInt32());
            Destination = new Point(reader.ReadInt32(), reader.ReadInt32());

            NeedHole = reader.ReadBoolean();
            NeedMove = reader.ReadBoolean();

            if (Envir.LoadVersion < 69) return;
            ConquestIndex = reader.ReadInt32();

            if (Envir.LoadVersion < 95) return;
            ShowOnBigMap = reader.ReadBoolean();
            Icon = reader.ReadInt32();
        }
        public void Save(BinaryWriter writer)
        {
            writer.Write(MapIndex);
            writer.Write(Source.X);
            writer.Write(Source.Y);
            writer.Write(Destination.X);
            writer.Write(Destination.Y);
            writer.Write(NeedHole);
            writer.Write(NeedMove);
            writer.Write(ConquestIndex);
            writer.Write(ShowOnBigMap);
            writer.Write(Icon);
        }


        public override string ToString()
        {
            return string.Format("{0} -> Map :{1} - {2}", Source, MapIndex, Destination);
        }
    }
}
