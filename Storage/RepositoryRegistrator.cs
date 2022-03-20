using Microsoft.Extensions.DependencyInjection;
using Storage.Entities;
using Storage.Interface;
using Storage.Repository;

namespace Storage
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoryInDb(this IServiceCollection services) => services
            .AddTransient<IRepository<Tube>, TubesRepository>()
            .AddTransient<IRepository<Bundle>, BundleRepository>()
            .AddTransient<IRepository<SteelMark>, SteelMarkRepository>()
        ;

    }

}
