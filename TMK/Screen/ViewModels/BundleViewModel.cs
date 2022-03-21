using Storage.Entities;
using Storage.Interface;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TMK.Infrastructure.Command.Base;
using TMK.Screen.Models;
using TMK.Screen.ViewModels.Base;
using TMK.Screen.Views;
using TMK.Service.Interface;
using TMK.Utils.Helpers;

namespace TMK.Screen.ViewModels
{
    public class BundleViewModel : TitledViewModel
    {
        private IUserDialog _UserDialog;
        private readonly IRepository<Bundle> _BundlesRepository;

        #region Свойства

        #region Коллекция BundleModel

        private ObservableCollection<BundleModel> _BundleModelsCollection;

        ///<summary>Коллекция BundleModel</summary>
        public ObservableCollection<BundleModel> BundleModelsCollection
        {
            get => _BundleModelsCollection;
            set
            {
                Set(ref _BundleModelsCollection, value);
                OnPropertyChanged(nameof(TubeModelsCollection));
            }
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
        private bool CanAddBundleCommandExecute() => true;

        /// <summary>Логика выполнения Добавить пакет</summary>
        private void OnAddBundleCommandExecuted()
        {
            var bundle = new Bundle();
            var model = new AddEditBundleViewModel(bundle);
            var window = new AddEditBundleView()
            {
                DataContext = model,
                Owner = App.CurrentWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                ResizeMode = ResizeMode.NoResize
            };
            if (window.ShowDialog() != true) return;
            bundle.Number = model.Number;
            bundle.Date = model.Date;
            bundle.Tubes = new List<Tube>();
            var newBundle = _BundlesRepository.Add(bundle);
            BundleModelsCollection.Add(new BundleModel(newBundle));
            OnPropertyChanged(nameof(BundleModelsCollection));
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
            if (SelectedItem == null) return;
            var idBundle = SelectedItem.Id;
            var bundle = _BundlesRepository.Get(idBundle);
            var model = new AddEditBundleViewModel(bundle);
            var window = new AddEditBundleView()
            {
                DataContext = model,
                Owner = App.CurrentWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                ResizeMode = ResizeMode.NoResize
            };
            if (window.ShowDialog() != true) return;
            bundle.Number = model.Number;
            bundle.Date = model.Date;
            _BundlesRepository.Update(bundle);
            BundleModelsCollection.Clear();
            BundleModelsCollection.AddRange(_BundlesRepository.Items.ToList()
                .OrderBy(x => x.Id)
                .Select(x => new BundleModel(x)).ToList());
            OnPropertyChanged(nameof(BundleModelsCollection));
            SelectedItem = BundleModelsCollection.FirstOrDefault(x => x.Id == idBundle);
            OnPropertyChanged(nameof(SelectedItem));
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
            var idTube = SelectedTube.Id;
            var idBundle = SelectedItem.Id;
            var bundle = _BundlesRepository.Get(idBundle);
            var tube = _BundlesRepository.Get(idBundle).Tubes.FirstOrDefault(x => x.Id == idTube);

            bundle.Tubes.Remove(tube);
            _BundlesRepository.Update(bundle);

            TubeModelsCollection.Remove(SelectedTube);
            BundleModelsCollection.Clear();
            BundleModelsCollection.AddRange(_BundlesRepository.Items.ToList()
                .OrderBy(x => x.Id)
                .Select(x => new BundleModel(x)).ToList());
            OnPropertyChanged(nameof(BundleModelsCollection));
            SelectedItem = BundleModelsCollection.FirstOrDefault(x => x.Id == idBundle);
            OnPropertyChanged(nameof(SelectedItem));
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
