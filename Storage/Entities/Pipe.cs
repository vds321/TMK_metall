using Storage.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.Entities
{
    [Table("pipe")]
    public class Pipe : Entity
    {

        /// <summary>
        /// Номер трубы
        /// </summary>
        [Column("number")]
        public int Number { get; set; }

        /// <summary>
        /// Качество трубы
        /// </summary>
        [Column("isGood")]
        public bool IsGoodQuality { get; set; }

        /// <summary>
        /// Вес трубы
        /// </summary>
        [Column("weight")]
        public double Weight { get; set; }

        /// <summary>
        /// Размер трубы
        /// </summary>
        [Column("pipe_size")]
        public double Size { get; set; }

        public virtual Bundle Bundle { get; set; }

        public virtual SteelMark SteelMark { get; set; }
        public override string ToString()
        {
            return $"Труба: {Number}, {IsGoodQuality}, {Weight}, {Size}, {SteelMark.Name}, Пакет: {Bundle?.Number}";
        }
    }

}
