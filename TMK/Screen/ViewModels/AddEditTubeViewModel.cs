using Storage.Entities;
using Storage.Interface;
using System.Collections.Generic;
using System.Linq;
using TMK.Screen.ViewModels.Base;

namespace TMK.Screen.ViewModels
{
    public class AddEditTubeViewModel : ViewModel
    {
        private readonly IRepository<SteelMark> _SteelMarkRepository;
        private readonly IRepository<Bundle> _BundleRepository;

        #region Заголовок окна

        private string _TitleWindow;

        ///<summary>Заголовок окна</summary>
        public string TitleWindow
        {
            get => _TitleWindow;
            set => Set(ref _TitleWindow, value);
        }

        #endregion

        #region Номер трубы

        private int _NumberTube;

        ///<summary>Номер трубы</summary>
        public int NumberTube
        {
            get => _NumberTube;
            set => Set(ref _NumberTube, value);
        }

        #endregion

        #region Размер трубы

        private double _SizeTube;

        ///<summary>Размер трубы</summary>
        public double SizeTube
        {
            get => _SizeTube;
            set => Set(ref _SizeTube, value);
        }

        #endregion

        #region Вес трубы

        private double _WeightTube;

        ///<summary>Вес трубы</summary>
        public double WeightTube
        {
            get => _WeightTube;
            set => Set(ref _WeightTube, value);
        }

        #endregion

        #region Марка стали

        private string _SteelMarkTube;

        ///<summary>Марка стали</summary>
        public string SteelMarkTube
        {
            get => _SteelMarkTube;
            set => Set(ref _SteelMarkTube, value);
        }

        #endregion

        #region Номер пакета

        private int? _BundleNumber;

        ///<summary>Номер пакета</summary>
        public int? BundleNumber
        {
            get => _BundleNumber;
            set => Set(ref _BundleNumber, value);
        }

        #endregion

        #region Качество трубы

        private bool _IsGoodQualityTube;

        ///<summary>Качество трубы</summary>
        public bool IsGoodQualityTube
        {
            get => _IsGoodQualityTube;
            set => Set(ref _IsGoodQualityTube, value);
        }

        #endregion

        public List<string> SteelMarks { get; }
        public List<int> Bundles { get; }

        public AddEditTubeViewModel(Tube tube, IRepository<SteelMark> steelMarkRepository, IRepository<Bundle> bundleRepository)
        {
            _SteelMarkRepository = steelMarkRepository;
            _BundleRepository = bundleRepository;
            IsGoodQualityTube = true;
            if (tube.Id != 0)
            {
                NumberTube = tube.Number;
                SizeTube = tube.Size;
                WeightTube = tube.Weight;
                SteelMarkTube = tube.SteelMark.Name;
                BundleNumber = tube.Bundle?.Number;
                IsGoodQualityTube = tube.IsGoodQuality;
            }
            OnPropertyChanged(nameof(IsGoodQualityTube));
            TitleWindow = tube.Id != 0 ? "Редактирование трубы" : "Добавление трубы";
            SteelMarks = new List<string>();
            SteelMarks = _SteelMarkRepository.Items.Select(x => x.Name).ToList();
            Bundles = new List<int>();
            Bundles = _BundleRepository.Items.Select(x => x.Number).OrderBy(x => x).ToList();
        }
    }

}
