using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Repository
{
    public interface IReadRepository<T> : IRepository<T> where T : class // Burda da T nin class olacağı garantisini verdik. Daha sonra BaseEntities yaptık o da bi class
    {
        IQueryable<T> GetAll(); // T yerine product, category vb yazılabilir hangisi yazılırsa onun hepsini getir.
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method); // tek bir tane getir
        Task<T> GetByIdAsync(int id);
    }
}
