﻿using Storage.Entities;
using Storage.Interface;
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
    public class TubesViewModel : TitledViewModel
    {
        private IUserDialog _UserDialog;
        private IRepository<Tube> _TubesRepository;
        private readonly IRepository<SteelMark> _SteelMarkRepository;
        private readonly IRepository<Bundle> _BundleRepository;

        #region Свойства

        #region Коллекция TupeModel

        private ObservableCollection<TubeModel> _TubeModelsCollection;

        ///<summary>Коллекция TupeModel</summary>
        public ObservableCollection<TubeModel> TubeModelsCollection
        {
            get => _TubeModelsCollection;
            set => Set(ref _TubeModelsCollection, value);
        }

        #endregion

        #region Выбранный элемент

        private TubeModel _SelectedItem;

        ///<summary>Выбранный элемент</summary>
        public TubeModel SelectedItem
        {
            get => _SelectedItem;
            set => Set(ref _SelectedItem, value);
        }

        #endregion

        #endregion


        #region Команды

        #region Command AddTubeCommand : Добавить трубу


        /// <summary>Добавить трубу</summary> 
        private ICommand _AddTubeCommand;

        /// <summary>Добавить трубу</summary>

        public ICommand AddTubeCommand => _AddTubeCommand
            ??= new LambdaCommand(OnAddTubeCommandExecuted, CanAddTubeCommandExecute);


        /// <summary>Проверка возможности выполнения Добавить трубу</summary>
        private bool CanAddTubeCommandExecute() => true;

        /// <summary>Логика выполнения Добавить трубу</summary>
        private void OnAddTubeCommandExecuted()
        {
            var tube = new Tube();
            var model = new AddEditTubeViewModel(tube, _SteelMarkRepository, _BundleRepository);
            var window = new AddEditTubeView()
            {
                DataContext = model,
                Owner = App.CurrentWindow,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            if (window.ShowDialog() != true) return;
            tube.Number = model.NumberTube;
            tube.Size = model.SizeTube;
            tube.Weight = model.WeightTube;
            tube.SteelMark = _SteelMarkRepository.Items.FirstOrDefault(x => x.Name == model.SteelMarkTube);
            tube.Bundle = _BundleRepository.Items.FirstOrDefault(x => x.Number == model.BundleNumber);
            tube.IsGoodQuality = model.IsGoodQualityTube;
            var newTube = _TubesRepository.Add(tube);
            TubeModelsCollection.Add(new TubeModel(newTube));
            OnPropertyChanged(nameof(TubeModelsCollection));
        }


        #endregion

        #region Command EditTubeCommand : Редактировать трубу


        /// <summary>Редактировать трубу</summary> 
        private ICommand _EditTubeCommand;

        /// <summary>Редактировать трубу</summary>

        public ICommand EditTubeCommand => _EditTubeCommand
            ??= new LambdaCommand(OnEditTubeCommandExecuted, CanEditTubeCommandExecute);


        /// <summary>Проверка возможности выполнения Редактировать трубу</summary>
        private bool CanEditTubeCommandExecute() => SelectedItem != null;

        /// <summary>Логика выполнения Редактировать трубу</summary>
        private void OnEditTubeCommandExecuted()
        {

        }


        #endregion

        #region Command RemoveTubeCommand : Удалить трубу


        /// <summary>Удалить трубу</summary> 
        private ICommand _RemoveTubeCommand;

        /// <summary>Удалить трубу</summary>

        public ICommand RemoveTubeCommand => _RemoveTubeCommand
            ??= new LambdaCommand(OnRemoveTubeCommandExecuted, CanRemoveTubeCommandExecute);


        /// <summary>Проверка возможности выполнения Удалить трубу</summary>
        private bool CanRemoveTubeCommandExecute() => SelectedItem != null;

        /// <summary>Логика выполнения Удалить трубу</summary>
        private void OnRemoveTubeCommandExecuted()
        {
            if (SelectedItem == null) return;
            var idToRemove = SelectedItem.Id;
            _TubesRepository.Remove(idToRemove);
            TubeModelsCollection.Remove(SelectedItem);
            OnPropertyChanged(nameof(TubeModelsCollection));
        }


        #endregion

        #endregion

        public TubesViewModel(IUserDialog userDialog, IRepository<Tube> tubesRepository,
                                                      IRepository<SteelMark> steelMarkRepository,
                                                      IRepository<Bundle> bundleRepository)
        {
            _UserDialog = userDialog;
            _TubesRepository = tubesRepository;
            _SteelMarkRepository = steelMarkRepository;
            _BundleRepository = bundleRepository;
            var tubes = _TubesRepository.Items.ToList().OrderBy(x => x.Id);
            TubeModelsCollection = new ObservableCollection<TubeModel>();
            TubeModelsCollection.AddRange(tubes.Select(x => new TubeModel(x)).ToList());
        }
    }
}
