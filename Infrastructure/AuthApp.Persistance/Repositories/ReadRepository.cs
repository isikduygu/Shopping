using AuthApp.Application.Repositories;
using AuthApp.Domain.Entitites.Common;
using AuthApp.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntities
    {
        private readonly AuthAppDbContext _context; // IOC konteynırına eklemiştik ordan talep ediyoruz.

        public ReadRepository(AuthAppDbContext context)
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

// ReadRepository yi IReadRepositoryden türettik. Methodları da geldi.
