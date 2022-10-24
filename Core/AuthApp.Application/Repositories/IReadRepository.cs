using AuthApp.Domain.Entitites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntities // Burda da T nin class olacağı garantisini verdik. Daha sonra BaseEntities yaptık o da bi class
    {
        IQueryable<T> GetAll(); // T yerine product, category vb yazılabilir hangisi yazılırsa onun hepsini getir.
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method); 
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method); // tek bir tane getir
        Task<T> GetByIdAsync(int id);
    }
}

// read işlemleri genelde 4 tanedir.  (select mantığı)
// IQueyable çoklu işlemlerde
// Son ikisi asenksron çalışacak
