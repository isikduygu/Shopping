using Microsoft.EntityFrameworkCore; // postgresql kullanabilmek için 
using AuthApp.Persistance.Context;
using Microsoft.Extensions.DependencyInjection; // IServiceCollectionını kullanmak için
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthApp.Application.Repositories;
using AuthApp.Persistance.Repositories;
using AuthApp.Domain.Entitites.Identity;
using AuthApp.Application.Abstraction;
using System.Configuration;

namespace AuthApp.Persistance
{
    public static class ServiceRegistration // static because of extension function 
    {
        public static void AddPersistanceServices(this IServiceCollection services) 
        {
            // services.AddSingleton<IProductService, ProductService>();
            services.AddDbContext<AuthAppDbContext>(options => options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Singleton);
            services.AddIdentity<AppUser,AppRole>( options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }
                ).AddEntityFrameworkStores<AuthAppDbContext>();
            services.AddSingleton<IProductReadRepository, ProductReadRepositories>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepositories>();

            services.AddSingleton<IFileReadRepository, FileReadRepository>();
            services.AddSingleton<IFileWriteRepository, FileWriteRepository>();

            services.AddSingleton<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddSingleton<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

            services.AddSingleton<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddSingleton<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();

        }
    }
}

// Identity için 3 işlem yaptık
// AppUser ve AppRole entityleri oluşturduk bunları identity paketinin bize sağlamış olduğu base classlardan türettik
// AuthAppDbContexte bildiriide bulundum
// Service registrationdan da ıoc containera gönderdik daha sonra migrate ettik.
// identity paketi bize hazır servisler sunduğu için repository patterna girmiyoruz.
