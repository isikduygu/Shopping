using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Abstraction.Services;
using OrderService.Application.Repository;
using OrderService.Persistance.Context;
using OrderService.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddOrderServicePersistance(this IServiceCollection services)
        {
            services.AddDbContext<OrderDbContext>(options => options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Singleton);

            services.AddSingleton<IOrderReadRepository, OrderReadRepositories>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepositories>();
            services.AddScoped<IOrderService, OrderService.Persistance.Services.OrderService>();
        }

    }
}
