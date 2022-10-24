using AuthApp.Application.Repositories;
using AuthApp.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Persistance.Repositories
{
    public class FileReadRepository : ReadRepository<AuthApp.Domain.Entitites.File>, IFileReadRepository
    {
        public FileReadRepository(AuthAppDbContext context) : base(context)
        {
        }
    }
}
