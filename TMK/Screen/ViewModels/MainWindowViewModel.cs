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
        private readonly IRepository<Pipe> _PipesRepository;
        private readonly IRepository<Package> _PackagesRepository;

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

        #region Command ShowPipesViewCommand : Показать раздел труб


        /// <summary>Показать раздел труб</summary> 
        private ICommand _ShowPipesViewCommand;

        /// <summary>Показать раздел труб</summary>

        public ICommand ShowPipesViewCommand => _ShowPipesViewCommand
            ??= new LambdaCommand(OnShowPipesViewCommandExecuted, CanShowPipesViewCommandExecute);


        /// <summary>Проверка возможности выполнения Показать раздел труб</summary>
        private bool CanShowPipesViewCommandExecute() => true;

        /// <summary>Логика выполнения Показать раздел труб</summary>
        private void OnShowPipesViewCommandExecuted()
        {

        }


        #endregion

        #region Command ShowPackagesViewCommand : Показать раздел пакетов


        /// <summary>Показать раздел пакетов</summary> 
        private ICommand _ShowPackagesViewCommand;

        /// <summary>Показать раздел пакетов</summary>

        public ICommand ShowPackagesViewCommand => _ShowPackagesViewCommand
            ??= new LambdaCommand(OnShowPackagesViewCommandExecuted, CanShowPackagesViewCommandExecute);


        /// <summary>Проверка возможности выполнения Показать раздел пакетов</summary>
        private bool CanShowPackagesViewCommandExecute() => true;

        /// <summary>Логика выполнения Показать раздел пакетов</summary>
        private void OnShowPackagesViewCommandExecuted()
        {

        }


        #endregion

        #endregion

        public MainWindowViewModel(IUserDialog userDialog, IRepository<SteelMark> steelMarkRepository, IRepository<Pipe> pipesRepository, IRepository<Package> packagesRepository)
        {
            Title = "Тестовое задание";
            _UserDialog = userDialog;
            _SteelMarkRepository = steelMarkRepository;
            _PipesRepository = pipesRepository;
            _PackagesRepository = packagesRepository;
        }
    }
}
