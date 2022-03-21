using Storage.Entities;
using System;
using TMK.Screen.ViewModels.Base;

namespace TMK.Screen.ViewModels
{
    public class AddEditBundleViewModel : ViewModel
    {
        #region Заголовок окна

        private string _TitleWindow;

        ///<summary>Заголовок окна</summary>
        public string TitleWindow
        {
            get => _TitleWindow;
            set => Set(ref _TitleWindow, value);
        }

        #endregion

        #region Номер пакета

        private int _Number;

        ///<summary>Номер пакета</summary>
        public int Number
        {
            get => _Number;
            set => Set(ref _Number, value);
        }

        #endregion

        #region Дата пакета

        private DateTime _Date;

        ///<summary>Дата пакета</summary>
        public DateTime Date
        {
            get => _Date;
            set => Set(ref _Date, value);
        }

        #endregion


        public AddEditBundleViewModel(Bundle bundle)
        {
            Date = DateTime.Now;
            if (bundle.Id != 0)
            {
                Number = bundle.Number;
                Date = bundle.Date;
            }

            TitleWindow = bundle.Id != 0 ? "Редактирование пакета" : "Добавление пакета";
        }
    }
}
