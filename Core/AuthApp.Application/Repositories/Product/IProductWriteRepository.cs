using AuthApp.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Repositories
{
    public interface IProductWriteRepository : IWriteRepository<Product>
    {
    }
}
