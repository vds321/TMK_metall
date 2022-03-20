using Storage.Entities;
using System.Windows.Media;
using TMK.Screen.ViewModels.Base;

namespace TMK.Screen.Models
{
    public class TubeModel : ViewModel
    {
        public int Id { get; }

        private readonly Color _transparentColor = Colors.Transparent;
        private readonly Color _redColor = Colors.Red;

        #region Свойства

        #region Номер

        private int _Number;

        ///<summary>Номер</summary>
        public int Number
        {
            get => _Number;
            set => Set(ref _Number, value);
        }

        #endregion

        #region Вес

        private double _Weight;

        ///<summary>Вес</summary>
        public double Weight
        {
            get => _Weight;
            set => Set(ref _Weight, value);
        }

        #endregion

        #region Размер

        private double _Size;

        ///<summary>Размер</summary>
        public double Size
        {
            get => _Size;
            set => Set(ref _Size, value);
        }

        #endregion

        #region Качество

        private bool _Quality;

        ///<summary>Качество</summary>
        public bool Quality
        {
            get => _Quality;
            set
            {
                Set(ref _Quality, value);
                OnPropertyChanged(nameof(TubeTextColor));
            }
        }

        #endregion

        #region Пакет

        private Bundle _Bundle;

        ///<summary>Пакет</summary>
        public Bundle Bundle
        {
            get => _Bundle;
            set => Set(ref _Bundle, value);
        }

        #endregion

        #region Марка стали

        private SteelMark _SteelMark;

        ///<summary>Марка стали</summary>
        public SteelMark SteelMark
        {
            get => _SteelMark;
            set => Set(ref _SteelMark, value);
        }

        #endregion

        #endregion


        public TubeModel(Tube tube)
        {
            Id = tube.Id;
            Number = tube.Number;
            Quality = tube.IsGoodQuality;
            Size = tube.Size;
            Weight = tube.Weight;
            Bundle = tube.Bundle;
            SteelMark = tube.SteelMark;
        }

        public Color TubeTextColor => Quality ? _transparentColor : _redColor;

    }
}
