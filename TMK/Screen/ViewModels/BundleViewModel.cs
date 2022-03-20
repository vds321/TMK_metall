﻿using Storage.Entities;
using Storage.Interface;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TMK.Infrastructure.Command.Base;
using TMK.Screen.Models;
using TMK.Screen.ViewModels.Base;
using TMK.Service.Interface;
using TMK.Utils.Helpers;

namespace TMK.Screen.ViewModels
{
    public class BundleViewModel : TitledViewModel
    {
        private IUserDialog _UserDialog;
        private IRepository<Bundle> _BundlesRepository;

        #region Свойства

        #region Коллекция BundleModel

        private ObservableCollection<BundleModel> _BundleModelsCollection;

        ///<summary>Коллекция BundleModel</summary>
        public ObservableCollection<BundleModel> BundleModelsCollection
        {
            get => _BundleModelsCollection;
            set => Set(ref _BundleModelsCollection, value);
        }

        #endregion

        #region Выбранный пакет

        private BundleModel _SelectedItem;

        ///<summary>Выбранный пакет</summary>
        public BundleModel SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if (Set(ref _SelectedItem, value))
                {
                    TubeModelsCollection = new ObservableCollection<TubeModel>();
                    if (SelectedItem != null) TubeModelsCollection.AddRange(SelectedItem.Tubes.Select(item => new TubeModel(item)));
                    OnPropertyChanged(nameof(TubeModelsCollection));
                }
            }
        }

        #endregion

        #region Выбранная труба пакета

        private TubeModel _SelectedTube;

        ///<summary>Выбранная труба пакета</summary>
        public TubeModel SelectedTube
        {
            get => _SelectedTube;
            set => Set(ref _SelectedTube, value);
        }

        #endregion

        #region Коллекция труб в пакете

        private ObservableCollection<TubeModel> _TubeModelsCollection;

        ///<summary>Коллекция труб в пакете</summary>
        public ObservableCollection<TubeModel> TubeModelsCollection
        {
            get => _TubeModelsCollection;
            set => Set(ref _TubeModelsCollection, value);
        }

        #endregion

        #endregion


        #region Команды

        #region Command AddBundleCommand : Добавить пакет


        /// <summary>Добавить пакет</summary> 
        private ICommand _AddBundleCommand;

        /// <summary>Добавить пакет</summary>

        public ICommand AddBundleCommand => _AddBundleCommand
            ??= new LambdaCommand(OnAddBundleCommandExecuted, CanAddBundleCommandExecute);


        /// <summary>Проверка возможности выполнения Добавить пакет</summary>
        private bool CanAddBundleCommandExecute() => SelectedItem != null;

        /// <summary>Логика выполнения Добавить пакет</summary>
        private void OnAddBundleCommandExecuted()
        {

        }


        #endregion

        #region Command EditBundleCommand : Редактировать пакет


        /// <summary>Редактировать пакет</summary> 
        private ICommand _EditBundleCommand;

        /// <summary>Редактировать пакет</summary>

        public ICommand EditBundleCommand => _EditBundleCommand
            ??= new LambdaCommand(OnEditBundleCommandExecuted, CanEditBundleCommandExecute);


        /// <summary>Проверка возможности выполнения Редактировать пакет</summary>
        private bool CanEditBundleCommandExecute() => SelectedItem != null;

        /// <summary>Логика выполнения Редактировать пакет</summary>
        private void OnEditBundleCommandExecuted()
        {

        }


        #endregion

        #region Command RemoveBundleCommand : Удалить пакет


        /// <summary>Удалить пакет</summary> 
        private ICommand _RemoveBundleCommand;

        /// <summary>Удалить пакет</summary>

        public ICommand RemoveBundleCommand => _RemoveBundleCommand
            ??= new LambdaCommand(OnRemoveBundleCommandExecuted, CanRemoveBundleCommandExecute);


        /// <summary>Проверка возможности выполнения Удалить пакет</summary>
        private bool CanRemoveBundleCommandExecute() => SelectedItem != null;

        /// <summary>Логика выполнения Удалить пакет</summary>
        private void OnRemoveBundleCommandExecuted()
        {
            if (SelectedItem == null) return;
            var idToRemove = SelectedItem.Id;
            _BundlesRepository.Remove(idToRemove);
            BundleModelsCollection.Remove(SelectedItem);
            OnPropertyChanged(nameof(BundleModelsCollection));
        }


        #endregion

        #region Command RemoveTubeFromBundleCommand : Удаление трубы из пакета


        /// <summary>Удаление трубы из пакета</summary> 
        private ICommand _RemoveTubeFromBundleCommand;

        /// <summary>Удаление трубы из пакета</summary>

        public ICommand RemoveTubeFromBundleCommand => _RemoveTubeFromBundleCommand
            ??= new LambdaCommand(OnRemoveTubeFromBundleCommandExecuted, CanRemoveTubeFromBundleCommandExecute);


        /// <summary>Проверка возможности выполнения Удаление трубы из пакета</summary>
        private bool CanRemoveTubeFromBundleCommandExecute() => SelectedTube != null;

        /// <summary>Логика выполнения Удаление трубы из пакета</summary>
        private void OnRemoveTubeFromBundleCommandExecuted()
        {
            if (SelectedTube == null) return;


            OnPropertyChanged(nameof(TubeModelsCollection));
            OnPropertyChanged(nameof(BundleModelsCollection));
        }


        #endregion

        #endregion

        public BundleViewModel(IUserDialog userDialog, IRepository<Bundle> bundlesRepository)
        {
            _UserDialog = userDialog;
            _BundlesRepository = bundlesRepository;
            var bundles = _BundlesRepository.Items.ToList().OrderBy(x => x.Id);
            BundleModelsCollection = new ObservableCollection<BundleModel>();
            BundleModelsCollection.AddRange(bundles.Select(x => new BundleModel(x)).ToList());
        }
    }
}
