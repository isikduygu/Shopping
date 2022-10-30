using OrderService.Application.Abstraction.Services;
using OrderService.Application.DTO_s;
using OrderService.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Persistance.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;

        public OrderService(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task CreateOrderAsync(CreateOrder createOrder)
        {
            var orderCode = (new Random().NextDouble() * 10000).ToString();
            orderCode = orderCode.Substring(orderCode.IndexOf(".") + 1, orderCode.Length - orderCode.IndexOf(".") - 1);

            await _orderWriteRepository.AddAsync(new()
            {
                CustomerIdentityId = createOrder.CustomerIdentityId,
                CustomerName = createOrder.CustomerName,
                AddressTitle = createOrder.AddressTitle,
                AddressCity =  createOrder.AddressCity,
                AddressDescription = createOrder.AddressDescription,
                TotalProductPrice = createOrder.TotalProductPrice,
                Products = createOrder.Products,
                OrderCode = orderCode

            });
            await _orderWriteRepository.SaveAsync();
        }
    }
}
