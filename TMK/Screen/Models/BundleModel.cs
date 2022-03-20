using Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TMK.Screen.ViewModels.Base;

namespace TMK.Screen.Models
{
    public class BundleModel : ViewModel
    {
        public int Id { get; }

        #region Номер

        private int _Number;

        ///<summary>Номер</summary>
        public int Number
        {
            get => _Number;
            set => Set(ref _Number, value);
        }

        #endregion

        #region Дата

        private DateTime _Date;

        ///<summary>Дата</summary>
        public DateTime Date
        {
            get => _Date;
            set => Set(ref _Date, value);
        }

        #endregion

        #region Трубы в пакете

        private List<Tube> _Tubes;

        ///<summary>Трубы в пакете</summary>
        public List<Tube> Tubes
        {
            get => _Tubes;
            set => Set(ref _Tubes, value);
        }

        #endregion

        public BundleModel(Bundle bundle)
        {
            Id = bundle.Id;
            Number = bundle.Number;
            Date = bundle.Date;
            Tubes = bundle.Tubes.ToList();
        }
    }
}
