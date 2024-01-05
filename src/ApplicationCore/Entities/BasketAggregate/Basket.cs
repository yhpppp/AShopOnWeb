using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.BasketAggregate
{
    public class Basket : BaseEntity, IAggregateRoot
    {
        public string BuyerId { get; private set; }
        private List<BasketItem> _items = new();
        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();
        public Basket(string buyerId)
        {
            BuyerId = buyerId;
            var test = new List<string>();
            var test2 = test.AsReadOnly();
        }

        public void AddItem(int catalogItemId, decimal unitPrice, int quantity)
        {
            if (Items.Any(i => i.CatalogItemId == catalogItemId))
            {
                var existingItem = Items.First(i => i.CatalogItemId == catalogItemId);
                existingItem.AddQuantity(quantity);
                return;
            }

            _items.Add(new(catalogItemId, unitPrice, quantity));

        }
    }
}
