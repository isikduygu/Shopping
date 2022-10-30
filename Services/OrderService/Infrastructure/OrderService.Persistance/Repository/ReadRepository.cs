using Microsoft.EntityFrameworkCore;
using OrderService.Application.Repository;
using OrderService.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Persistance.Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly OrderDbContext _context; // IOC konteynırına eklemiştik ordan talep ediyoruz.

        public ReadRepository(OrderDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); // normalde _context.Products? istiyor biz T yazmamız için Set kullanmalıyız.

        public IQueryable<T> GetAll()
            => Table;   // Table zaten hepsini içeriyor.

        public async Task<T> GetByIdAsync(int id)
            // => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));  bu kısımda id kullanabilmek için basenetitye çevirdik.
            => await Table.FindAsync(id);
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
            => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            => Table.Where(method);
    }
}
