using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Storage;
using Storage.Context;
using System;

namespace TMK.Data
{
    public static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration Configuration) => services
            .AddDbContext<TmkDB>(options =>
            {
                var type = Configuration["Type"];
                switch (type)
                {
                    case null: throw new InvalidOperationException("Не определен тип БД");
                    default: throw new InvalidOperationException($"Тип подключения {type} не поддерживается");
                    case "InMemory":
                        options.UseInMemoryDatabase("tmk.db");
                        break;
                }

            })
            .AddTransient<DbInitializer>()
            .AddRepositoryInDb()
            ;
    }
}
