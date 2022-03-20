using Storage.Entities;
using Storage.Interface;
using System.Windows.Input;
using TMK.Infrastructure.Command.Base;
using TMK.Screen.Main.ViewModels.Base;
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
        private bool CanShowTubesViewCommandExecute() => true;

        /// <summary>Логика выполнения Показать раздел труб</summary>
        private void OnShowTubesViewCommandExecuted()
        {

        }


        #endregion

        #region Command ShowBundlesViewCommand : Показать раздел пакетов


        /// <summary>Показать раздел пакетов</summary> 
        private ICommand _ShowBundlesViewCommand;

        /// <summary>Показать раздел пакетов</summary>

        public ICommand ShowBundlesViewCommand => _ShowBundlesViewCommand
            ??= new LambdaCommand(OnShowBundlesViewCommandExecuted, CanShowBundlesViewCommandExecute);


        /// <summary>Проверка возможности выполнения Показать раздел пакетов</summary>
        private bool CanShowBundlesViewCommandExecute() => true;

        /// <summary>Логика выполнения Показать раздел пакетов</summary>
        private void OnShowBundlesViewCommandExecuted()
        {

        }


        #endregion

        #endregion

        public MainWindowViewModel(IUserDialog userDialog, IRepository<SteelMark> steelMarkRepository, IRepository<Tube> pipesRepository, IRepository<Bundle> packagesRepository)
        {
            Title = "Тестовое задание";
            _UserDialog = userDialog;
            _SteelMarkRepository = steelMarkRepository;
            _TubesRepository = pipesRepository;
            _BundlesRepository = packagesRepository;
        }
    }
}
