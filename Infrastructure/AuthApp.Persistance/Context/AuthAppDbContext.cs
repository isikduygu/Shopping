using AuthApp.Domain.Entitites;
using AuthApp.Domain.Entitites.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Persistance.Context
{
    public class AuthAppDbContext : IdentityDbContext<AppUser, AppRole, string> // DbContext EntityFrameworkCore paketinden yükledik
    {
        public AuthAppDbContext(DbContextOptions options) : base(options) // optionları base e gönderen constructer
        { }
        public DbSet<Product> Products { get; set; }

        // public DbSet<Order> Orders { get; set; } Dbye karşılık gelen setler oluştursun verileri de order/product/customerdan alsn
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Domain.Entitites.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}

// DBsetleri IOC konteynıra eklemek lazımki heryerden erişilebilsin buda AuthAppde
// Bir şey göndermek için de serviceregisteration kullanuyorduk.