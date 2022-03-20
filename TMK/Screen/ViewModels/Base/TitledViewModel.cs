namespace TMK.Screen.ViewModels.Base
{
    public abstract class TitledViewModel : ViewModel
    {
        #region Заголовок

        private string _Title;

        ///<summary>Заголовок</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion
    }
}
