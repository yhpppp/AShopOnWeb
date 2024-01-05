using ApplicationCore.Entities.BasketAggregate;
using Microsoft.AspNetCore.Mvc;
using PublicApi.Controllers.Services;

namespace PublicApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpPost("add-item-basket")]
        public async Task<Basket> AddBasketItem(int catalogItemId)
        {

            return await _basketService.AddItemToBasketAsync(catalogItemId);
        }
    }
}
