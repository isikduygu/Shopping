
using OrderService.Application.Repository;
using OrderService.Domain.Entities;
using OrderService.Persistance.Context;
using OrderService.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Persistance.Repositories
{
    public class OrderWriteRepositories : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepositories(OrderDbContext context) : base(context)
        {
        }
    }
}
