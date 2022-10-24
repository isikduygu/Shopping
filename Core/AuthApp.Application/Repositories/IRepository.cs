using AuthApp.Domain.Entitites.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntities
    {
        DbSet<T> Table { get; }
    }
}

// Repository pattern SOLID prensiplerinden The Single Responsibility Principle aykırı. Çünkü readler de writelarda
// aynı class içersinde oluyor. The signle prensibine uymuyor. Bunun için IReadRepositry, IWriteRepository diye
// ayırıyoruz. Bunlar IRepositoryden türüyecekler. IRepositoryi common gibi düşünebiliriz.

// Normalde DbSet<Entity> tanımlamamız gerekli. Ama biz tek entity değil bütün entityler olsun istiyoruz.Ve class olsun.
// Repository pattern mantığı da tüm hepsinin birlikte olması. Bu yüzden T atıyoruz. Ama bu T enum vs. olabilir bunun kesin
// class olacağını where ile bildiriyoruz. Bu generic repositorydir.

// Table'ı sadece get ediyoruz set etmemize gerek yok.
