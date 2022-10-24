using AuthApp.Application.Repositories;
using AuthApp.Domain.Entitites;
using AuthApp.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Persistance.Repositories
{
    public class ProductReadRepositories : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepositories(AuthAppDbContext context) : base(context)
        {
        }
    }
}
