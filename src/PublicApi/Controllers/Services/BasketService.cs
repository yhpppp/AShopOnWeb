
using ApplicationCore.Entities;
using ApplicationCore.Entities.BasketAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;

namespace PublicApi.Controllers.Services
{
    public class BasketService : IBasketService
    {
        private readonly IRepository<Basket> _basketRepository;
        private readonly IRepository<CatalogItem> _catalogItemRepository;

        public BasketService(IRepository<Basket> basketRepository, IRepository<CatalogItem> catalogItemRepository)
        {
            _basketRepository = basketRepository;
            _catalogItemRepository = catalogItemRepository;
        }

        public async Task<Basket> AddItemToBasketAsync(int catalogItemId, int quantity)
        {
            // Get user id by current user token
            var testUser = "8849";
            var spec = new BasketWithItemsSpecification(testUser);
            var basket = await _basketRepository.FirstOrDefaultAsync(spec);

            if (basket is null)
            {
                basket = new Basket(testUser);
                await _basketRepository.AddAsync(basket);
            }

            var catalogItemSpec = new CatalogItemSpecification(catalogItemId);
            var ci = await _catalogItemRepository.FirstOrDefaultAsync(catalogItemSpec);
      
            basket.AddItem(catalogItemId, ci.Price, quantity);
            await _basketRepository.UpdateAsync(basket);
            return basket;

        }
    }
}
