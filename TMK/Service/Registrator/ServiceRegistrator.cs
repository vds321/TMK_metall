using Microsoft.Extensions.DependencyInjection;
using TMK.Service.Interface;

namespace TMK.Service.Registrator
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IUserDialog, UserDialogService>()
        ;
    }
}
