using ApplicationCore.Interfaces;
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
    }
}
