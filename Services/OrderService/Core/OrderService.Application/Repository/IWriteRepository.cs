using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Repository
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T model); // T neyse ekle
        Task<bool> AddRangeAsync(List<T> model); // hepsini ekle
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(int id); // idle ile remove
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
