namespace PublicApi.CatalogItemEndpoints
{
    public class ListPagedCatalogItemResponse
    {
        public List<CatalogItemDto> CatalogItems { get; set; } = new List<CatalogItemDto>();
        public int PageCount { get; set; }
    }
}
