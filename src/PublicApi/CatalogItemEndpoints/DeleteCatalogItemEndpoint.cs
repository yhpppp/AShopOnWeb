using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace PublicApi.CatalogItemEndpoints
{
    public class DeleteCatalogItemEndpoint : IEndpoint<IResult, DeleteCatalogItemRequest, IRepository<CatalogItem>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapDelete("api/catalog-items/{catalogItemId}", async (int catalogItemId, IRepository<CatalogItem> repository) =>
            {
                return await HandleAsync(new DeleteCatalogItemRequest(catalogItemId), repository);
            }).WithTags("CatalogItemEndpoints").Produces<DeleteCatalogItemResponse>();
        }

        public async Task<IResult> HandleAsync(DeleteCatalogItemRequest request, IRepository<CatalogItem> repository)
        {
            var entity = await repository.GetByIdAsync(request.CatalogItemId);
            if (entity is null)
            {
                return Results.NotFound();
            }
            else
            {
                await repository.DeleteAsync(entity);
                return Results.Ok(new DeleteCatalogItemResponse());
            }
        }
    }
}
