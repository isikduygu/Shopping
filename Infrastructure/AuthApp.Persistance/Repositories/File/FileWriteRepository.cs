using AuthApp.Application.Repositories;
using AuthApp.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Persistance.Repositories
{
    public class FileWriteRepository : WriteRepository<AuthApp.Domain.Entitites.File>, IFileWriteRepository
    {
        public FileWriteRepository(AuthAppDbContext context) : base(context)
        {
        }
    }
}
