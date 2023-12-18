namespace PublicApi.CatalogTypeEndpoints
{
    public class ListCatalogTypesResponse
    {
        public List<CatalogTypeDto> CatalogTypes { get; set; } = new List<CatalogTypeDto>();
    }
}
