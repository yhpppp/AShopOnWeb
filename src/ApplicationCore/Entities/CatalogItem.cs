using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class CatalogItem : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Decimal Price { get; private set; }
        public string PictureUrl { get; private set; }
        public int CatalogBrandId { get; private set; }
        public CatalogBrand? CatalogBrand { get; private set; }
        public int CatalogTypeId { get; private set; }
        public CatalogType? CatalogType { get; private set; }

        public CatalogItem(int catalogBrandId, int catalogTypeId, string name, string description, decimal price, string pictureUrl)
        {
            CatalogBrandId = catalogBrandId;
            CatalogTypeId = catalogTypeId;
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
        }

        public void UpdateType(int catalogTypeId)
        {
            Guard.Against.Zero(catalogTypeId, nameof(catalogTypeId));
            CatalogTypeId = CatalogTypeId;
        }

        public void UpdateBrand(int catalogBrandId)
        {
            Guard.Against.Zero(catalogBrandId, nameof(catalogBrandId));
            CatalogBrandId = CatalogBrandId;
        }
        public void UpdateDetails(CatalogItemDetails details)
        {
            Guard.Against.NullOrEmpty(details.Name, nameof(details.Name));
            Guard.Against.NullOrEmpty(details.Description, nameof(details.Description));
            Guard.Against.NegativeOrZero(Price, nameof(details.Price));

            Name = details.Name;
            Description = details.Description;
            Price = details.Price;
        }

        public readonly record struct CatalogItemDetails
        {
            public string? Name { get; }


            public string? Description { get; }
            public decimal Price { get; }
            public CatalogItemDetails(string? name, string? description, decimal price)
            {
                Name = name;
                Description = description;
                Price = price;
            }
        }
    }
}
