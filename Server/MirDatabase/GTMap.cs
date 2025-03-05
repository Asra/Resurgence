using Server.MirEnvir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Library.MirDatabase
{
    [Table("GTMaps")]
    public class GTMap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Primary Key
        public int Index { get; set; }
        public int Key { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Leader { get; set; }
        public string Leader2 { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Days { get; set; }
        public int Begin { get; set; }

        [NotMapped]
        public virtual List<Map> Maps { get; set; } = new List<Map>();

        public GTMap()
        {
        }

        public GTMap(BinaryReader reader)
        {
            Index = reader.ReadInt32();
            Key = reader.ReadInt32();
            Name = reader.ReadString();
            Owner = reader.ReadString();
            Leader = reader.ReadString();
            Leader2 = reader.ReadString();
            Price = reader.ReadInt32();
            Days = reader.ReadInt32();
            Begin = reader.ReadInt32();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Index);
            writer.Write(Key);
            writer.Write(Name);
            writer.Write(Owner);
            writer.Write(Leader);
            writer.Write(Leader2);
            writer.Write(Price);
            writer.Write(Days);
            writer.Write(Begin);
        }

        public ClientGTMap ToClientGTMap()
        {
            ClientGTMap result = new ClientGTMap
            {
                index = Index,
                Name = Name,
                Owner = Owner,
                Leader = Leader,
                Leader2 = Leader2,
                price = Price,
                days = Days,
                begin = Begin,
            };
            return result;
        }
    }
}
