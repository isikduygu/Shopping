using MediatR;
using OrderService.Application.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderService _orderService;

        public CreateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _orderService.CreateOrderAsync(new()
            {
                CustomerIdentityId = request.CustomerIdentityId,
                CustomerName = request.CustomerName,
                Products = request.Products,
                AddressTitle = request.AddressTitle,
                AddressDescription = request.AddressDescription,
                AddressCity = request.AddressCity,
                TotalProductPrice = request.TotalProductPrice
            });
                return new();
        }
    }
}
