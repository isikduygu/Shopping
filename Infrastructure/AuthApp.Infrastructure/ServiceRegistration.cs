using AuthApp.Application.Abstraction;
using AuthApp.Application.Abstraction.Storage;
using AuthApp.Infrastructure.Enums;
using AuthApp.Infrastructure.Services.Storage;
using AuthApp.Infrastructure.Services.Storage.Azure;
using AuthApp.Infrastructure.Services.Storage.Local;
using AuthApp.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Infrastructure
{
    public static class ServiceRegistration // static because of extension function 
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenHandler, TokenHandler>();
            services.AddScoped<IStorageService, StorageService>();

        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:

                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
