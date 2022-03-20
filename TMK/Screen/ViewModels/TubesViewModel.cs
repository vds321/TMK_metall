using Storage.Entities;
using Storage.Interface;
using System.Collections.ObjectModel;
using System.Linq;
using TMK.Screen.Models;
using TMK.Screen.ViewModels.Base;
using TMK.Service.Interface;
using TMK.Utils.Helpers;

namespace TMK.Screen.ViewModels
{
    public class TubesViewModel : TitledViewModel
    {
        private IUserDialog _UserDialog;
        private IRepository<Tube> _TubesRepository;

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


        public TubesViewModel(IUserDialog userDialog, IRepository<Tube> tubesRepository)
        {
            _UserDialog = userDialog;
            _TubesRepository = tubesRepository;
            var tubes = _TubesRepository.Items.ToList().OrderBy(x => x.Id);
            TubeModelsCollection = new ObservableCollection<TubeModel>();
            TubeModelsCollection.AddRange(tubes.Select(x => new TubeModel(x)).ToList());
        }
    }
}
