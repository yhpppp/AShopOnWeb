using System.ComponentModel.DataAnnotations;

namespace PublicApi.CatalogItemEndpoints
{
    public class UpdateCatalogItemRequest
    {
        [Range(0,10000)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0.01,10000)]
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int CatalogBrandId { get; set; }
        public int CatalogTypeId { get; set; }
    }
}