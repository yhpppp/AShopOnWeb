using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace PublicApi.CatalogItemEndpoints
{
    public class CatalogItemGetByIdEndpoint : IEndpoint<IResult, GetByIdCatalogItemRequest, IRepository<CatalogItem>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/catalog-items/{catalogItemId}", async (int catalogItemId, IRepository<CatalogItem> repository) =>
           {
               return await HandleAsync(new GetByIdCatalogItemRequest(catalogItemId), repository);
           }).WithTags("CatalogItemEndpoints").Produces<GetByIdCatalogItemResponse>();
        }

        public async Task<IResult> HandleAsync(GetByIdCatalogItemRequest request, IRepository<CatalogItem> repository)
        {
            var entity = await repository.GetByIdAsync(request.CatalogItemId);
            if (entity == null)
            {
                return Results.NotFound();
            }
            else
            {
                var response = new GetByIdCatalogItemResponse();
                response.CatalogItem = new CatalogItemDto
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    PictureUrl = entity.PictureUrl,
                    Price = entity.Price,
                    CatalogBrandId = entity.CatalogBrandId,
                    CatalogTypeId = entity.CatalogTypeId,
                };
                return Results.Ok(response);
            }
        }
    }
}
