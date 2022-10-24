using Application.BasketService.Interfaces.Repositories;
using Domain.BasketService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseApiController
    {
        private readonly IBasketAsyncRepository _basketRepository;

        public BasketController(IBasketAsyncRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id)); // return empty basket if null
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await _basketRepository.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasket(string Id)
        {
            var isDeleted = await _basketRepository.DeleteBasketAsync(Id);
        }
    }
}
