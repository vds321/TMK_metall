using Storage.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.Entities
{
    [Table("steel_mark")]
    public class SteelMark : Entity
    {
        [Column("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
