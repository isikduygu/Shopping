using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OrderService.Application.Repository;
using OrderService.Domain.Entities;
using OrderService.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Persistance.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntities
    {
        private readonly OrderDbContext _context;

        public WriteRepository(OrderDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;  // Bool ifade döndürmek için
        }

        public async Task<bool> AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
            return Remove(model); // üstteki removu burda cağırdık
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

    }
}
