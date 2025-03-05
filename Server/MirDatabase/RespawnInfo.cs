using System.Drawing;
using Server.MirEnvir;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.MirDatabase
{
    [Table("RespawnInfo")]
    public class RespawnInfo
    {
        protected static Envir Envir
        {
            get { return Envir.Main; }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment primary key
        public int Id { get; set; }

        public int RespawnIndex { get; set; }
        public int MonsterIndex { get; set; }

        // Store Location as X and Y (since EF Core does not support System.Drawing.Point)
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        public ushort Count { get; set; }
        public ushort Spread { get; set; }
        public ushort Delay { get; set; }
        public ushort RandomDelay { get; set; }
        public byte Direction { get; set; }

        public string RoutePath { get; set; } = string.Empty;
        public bool SaveRespawnTime { get; set; } = false;
        public ushort RespawnTicks { get; set; } // Leave 0 if not using this system

        public int MapInfoId { get; set; }  // Ensure this matches MapInfo.Id

        [ForeignKey("MapInfoId")]
        public virtual MapInfo Map { get; set; }

        // Constructor
        public RespawnInfo() { }

        // Method to get location as a Point object if needed
        [NotMapped] // Exclude from EF Core mapping
        public System.Drawing.Point Location
        {
            get => new System.Drawing.Point(LocationX, LocationY);
            set
            {
                LocationX = value.X;
                LocationY = value.Y;
            }
        }

        public RespawnInfo(BinaryReader reader, int Version, int Customversion)
        {
            MonsterIndex = reader.ReadInt32();

            Location = new Point(reader.ReadInt32(), reader.ReadInt32());

            Count = reader.ReadUInt16();
            Spread = reader.ReadUInt16();

            Delay = reader.ReadUInt16();
            Direction = reader.ReadByte();

            RoutePath = reader.ReadString();

            if (Version > 67)
            {
                RandomDelay = reader.ReadUInt16();
                RespawnIndex = reader.ReadInt32();
                SaveRespawnTime = reader.ReadBoolean();
                RespawnTicks = reader.ReadUInt16();
            }
            else
            {
                RespawnIndex = ++Envir.RespawnIndex;
            }
        }

        public static RespawnInfo FromText(string text)
        {
            string[] data = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length < 7) return null;

            RespawnInfo info = new RespawnInfo();

            int x, y, monsterIndex, respawnIndex;
            ushort count, spread, delay, randomDelay, respawnTicks;
            byte direction;
            bool saveRespawnTime;

            if (!int.TryParse(data[0], out monsterIndex)) return null;
            if (!int.TryParse(data[1], out x)) return null;
            if (!int.TryParse(data[2], out y)) return null;
            if (!ushort.TryParse(data[3], out count)) return null;
            if (!ushort.TryParse(data[4], out spread)) return null;
            if (!ushort.TryParse(data[5], out delay)) return null;
            if (!byte.TryParse(data[6], out direction)) return null;
            if (!ushort.TryParse(data[7], out randomDelay)) return null;
            if (!int.TryParse(data[8], out respawnIndex)) return null;
            if (!bool.TryParse(data[9], out saveRespawnTime)) return null;
            if (!ushort.TryParse(data[10], out respawnTicks)) return null;

            // Assign parsed values to the object properties
            info.MonsterIndex = monsterIndex;
            info.Location = new Point(x, y);
            info.Count = count;
            info.Spread = spread;
            info.Delay = delay;
            info.Direction = direction;
            info.RandomDelay = randomDelay;
            info.RespawnIndex = respawnIndex;
            info.SaveRespawnTime = saveRespawnTime;
            info.RespawnTicks = respawnTicks;

            return info;
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(MonsterIndex);

            writer.Write(Location.X);
            writer.Write(Location.Y);
            writer.Write(Count);
            writer.Write(Spread);

            writer.Write(Delay);
            writer.Write(Direction);

            writer.Write(RoutePath);

            writer.Write(RandomDelay);
            writer.Write(RespawnIndex);
            writer.Write(SaveRespawnTime);
            writer.Write(RespawnTicks);
        }

        public override string ToString()
        {
            return string.Format("Monster: {0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9}", MonsterIndex, Functions.PointToString(Location), Count, Spread, Delay, Direction, RandomDelay, RespawnIndex, SaveRespawnTime, RespawnTicks);
        }
    }

    public class RouteInfo
    {
        public Point Location;
        public int Delay;

        public static RouteInfo FromText(string text)
        {
            string[] data = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length < 2) return null;

            RouteInfo info = new RouteInfo();

            int x, y;

            if (!int.TryParse(data[0], out x)) return null;
            if (!int.TryParse(data[1], out y)) return null;

            info.Location = new Point(x, y);

            if (data.Length <= 2) return info;

            return !int.TryParse(data[2], out info.Delay) ? info : info;
        }
    }
}
