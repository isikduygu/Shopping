using Application.BasketService.Interfaces.Repositories;
using Infrastructure.Persistance.BasketService.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.BasketService
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json")
                  .Build();
            services.AddSingleton<IConnectionMultiplexer>(c => {
                var configuration = ConfigurationOptions.Parse(config.GetConnectionString("Redis"),
                true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddScoped<IBasketAsyncRepository, BasketAsyncRepository>();
        }
    }
}
