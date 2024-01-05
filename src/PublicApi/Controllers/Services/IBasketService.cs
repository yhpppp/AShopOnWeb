using ApplicationCore.Entities.BasketAggregate;

namespace PublicApi.Controllers.Services
{
    public interface IBasketService
    {
        Task<Basket> AddItemToBasketAsync(int catalogItemId, int quantity = 1);
    }
}
