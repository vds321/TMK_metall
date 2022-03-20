using Storage.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.Entities
{
    [Table("bundle")]
    public class Bundle : Entity
    {
        /// <summary>
        /// Номер пакета
        /// </summary>
        [Column("number")]
        public int Number { get; set; }

        /// <summary>
        /// Дата пакета
        /// </summary>
        [Column("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Список труб в пакете
        /// </summary>
        public virtual ICollection<Pipe> Pipes { get; set; }

        public override string ToString()
        {
            return $"Пакет {Number}, Дата {Date}, Труб в пакете: {Pipes?.Count}";
        }
    }

}
