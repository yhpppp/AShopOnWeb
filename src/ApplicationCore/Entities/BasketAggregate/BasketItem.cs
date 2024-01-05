using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.BasketAggregate
{
    public class BasketItem : BaseEntity
    {
        public decimal UnitPrice { get; private set; }

        public int Quantity { get; private set; }
        public int CatalogItemId { get; private set; }
        public int BasketId { get; private set; }
        public BasketItem(int catalogItemId, decimal unitPrice, int quantity)
        {
            CatalogItemId = catalogItemId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);
            this.Quantity += quantity;
        }
    }
}
