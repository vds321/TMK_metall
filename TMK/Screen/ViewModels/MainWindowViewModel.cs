using Storage.Entities;
using Storage.Interface;
using System.Windows.Input;
using TMK.Infrastructure.Command.Base;
using TMK.Screen.ViewModels.Base;
using TMK.Service.Interface;

namespace TMK.Screen.ViewModels
{
    internal class MainWindowViewModel : TitledViewModel
    {
        private readonly IUserDialog _UserDialog;
        private readonly IRepository<SteelMark> _SteelMarkRepository;
        private readonly IRepository<Tube> _TubesRepository;
        private readonly IRepository<Bundle> _BundlesRepository;

        #region Свойства

        #region Выбор текущего окна

        private TitledViewModel _CurrentViewModel;

        ///<summary>Выбор текущего окна</summary>
        public TitledViewModel CurrentViewModel
        {
            get => _CurrentViewModel;
            set => Set(ref _CurrentViewModel, value);
        }

        #endregion

        #endregion

        #region Команды

        #region Command ShowTubesViewCommand : Показать раздел труб


        /// <summary>Показать раздел труб</summary> 
        private ICommand _ShowTubesViewCommand;

        /// <summary>Показать раздел труб</summary>

        public ICommand ShowTubesViewCommand => _ShowTubesViewCommand
            ??= new LambdaCommand(OnShowTubesViewCommandExecuted, CanShowTubesViewCommandExecute);


        /// <summary>Проверка возможности выполнения Показать раздел труб</summary>
        private bool CanShowTubesViewCommandExecute() => CurrentViewModel?.GetType() != typeof(TubesViewModel);

        /// <summary>Логика выполнения Показать раздел труб</summary>
        private void OnShowTubesViewCommandExecuted()
        {
            CurrentViewModel = new TubesViewModel(_UserDialog, _TubesRepository, _SteelMarkRepository, _BundlesRepository);
            OnPropertyChanged(nameof(CurrentViewModel));
        }


        #endregion

        #region Command ShowBundlesViewCommand : Показать раздел пакетов


        /// <summary>Показать раздел пакетов</summary> 
        private ICommand _ShowBundlesViewCommand;

        /// <summary>Показать раздел пакетов</summary>

        public ICommand ShowBundlesViewCommand => _ShowBundlesViewCommand
            ??= new LambdaCommand(OnShowBundlesViewCommandExecuted, CanShowBundlesViewCommandExecute);


        /// <summary>Проверка возможности выполнения Показать раздел пакетов</summary>
        private bool CanShowBundlesViewCommandExecute() => CurrentViewModel?.GetType() != typeof(BundleViewModel);

        /// <summary>Логика выполнения Показать раздел пакетов</summary>
        private void OnShowBundlesViewCommandExecuted()
        {
            CurrentViewModel = new BundleViewModel(_UserDialog, _BundlesRepository);
            OnPropertyChanged(nameof(CurrentViewModel));
        }


        #endregion

        #endregion

        public MainWindowViewModel(IUserDialog userDialog, IRepository<SteelMark> steelMarkRepository,
                                                           IRepository<Tube> pipesRepository,
                                                           IRepository<Bundle> packagesRepository)
        {
            Title = "Тестовое задание";
            _UserDialog = userDialog;
            _SteelMarkRepository = steelMarkRepository;
            _TubesRepository = pipesRepository;
            _BundlesRepository = packagesRepository;
        }
    }
}
