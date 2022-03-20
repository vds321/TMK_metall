using TMK.Screen.ViewModels.Base;

namespace TMK.Screen.ViewModels
{
    public class TubesViewModel : TitledViewModel
    {
        public TubesViewModel()
        {
            Title = "Трубы";
            OnPropertyChanged(nameof(Title));
        }
    }
}
