namespace PublicApi.CatalogItemEndpoints
{
    public class GetByIdCatalogItemRequest
    {
        public int CatalogItemId { get; init; }

        public GetByIdCatalogItemRequest(int catalogItemId)
        {
            CatalogItemId = catalogItemId;
        }
    }
}
