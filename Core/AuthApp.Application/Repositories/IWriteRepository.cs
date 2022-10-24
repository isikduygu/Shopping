using AuthApp.Domain.Entitites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntities
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
// Ekleme silme operasyonları yapma
// Bool olmasının nedeni başarılıysa true değilse false göndersin diye
// Çoklu işlemlerde List
