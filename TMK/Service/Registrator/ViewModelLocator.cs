using Microsoft.Extensions.DependencyInjection;
using TMK.Screen.ViewModels;

namespace TMK.Service.Registrator
{
    internal class ViewModelLocator
    {
        public static MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();

    }
}
