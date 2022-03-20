using Microsoft.Extensions.DependencyInjection;
using TMK.Screen.ViewModels;

namespace TMK.Service.Registrator
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
        ;

    }
}
