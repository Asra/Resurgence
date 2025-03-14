using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

﻿namespace Server.MirDatabase
{
    public class SafeZoneInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key

        // Store X and Y separately (since EF Core does not support System.Drawing.Point)
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        public ushort Size { get; set; }
        public bool StartPoint { get; set; }

        // Foreign key for MapInfo
        public int MapInfoId { get; set; }

        [ForeignKey("MapInfoId")]
        public virtual MapInfo Info { get; set; }

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

        public SafeZoneInfo() { }

        public SafeZoneInfo(BinaryReader reader)
        {
            Location = new Point(reader.ReadInt32(), reader.ReadInt32());
            Size = reader.ReadUInt16();
            StartPoint = reader.ReadBoolean();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Location.X);
            writer.Write(Location.Y);
            writer.Write(Size);
            writer.Write(StartPoint);
        }

        public override string ToString()
        {
            return string.Format("Map: {0}- {1}", Functions.PointToString(Location), StartPoint);
        }
    }
}
