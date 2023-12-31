﻿namespace PublicApi.CatalogItemEndpoints
{
    public class CreateCatalogItemRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int CatalogBrandId { get; set; }
        public int CatalogTypeId { get; set; }
    }
}