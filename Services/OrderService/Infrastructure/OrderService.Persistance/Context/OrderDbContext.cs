
using Microsoft.EntityFrameworkCore;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Persistance.Context
{
    public class OrderDbContext : DbContext // DbContext EntityFrameworkCore paketinden yükledik
    {
        public OrderDbContext(DbContextOptions options) : base(options) // optionları base e gönderen constructer
        { }
        public DbSet<Order> Orders { get; set; } // Dbye karşılık gelen setler oluştursun verileri de order/product/customerdan alsn


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
