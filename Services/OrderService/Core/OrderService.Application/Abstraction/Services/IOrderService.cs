using OrderService.Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Abstraction.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrder createOrder);
    }
}
