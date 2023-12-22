namespace PublicApi.CatalogItemEndpoints
{
    public class DeleteCatalogItemRequest
    {
        public int CatalogItemId { get; init; }

        public DeleteCatalogItemRequest(int catalogItemId)
        {
            CatalogItemId = catalogItemId;
        }
    }
}
