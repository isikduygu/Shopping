using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Features.Commands;

namespace OrderService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
         {
          _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
            return Ok(response);
        }
    }
}
