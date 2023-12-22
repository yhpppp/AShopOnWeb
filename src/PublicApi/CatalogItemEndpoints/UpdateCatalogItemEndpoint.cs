using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace PublicApi.CatalogItemEndpoints
{
    public class UpdateCatalogItemEndpoint : IEndpoint<IResult, UpdateCatalogItemRequest, IRepository<CatalogItem>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPut("api/catalog-items", async (UpdateCatalogItemRequest request, IRepository<CatalogItem> repository) =>
            {
                return await HandleAsync(request, repository);
            }).WithTags("CatalogItemEndpoints").Produces<UpdateCatalogItemResponse>();
        }

        public async Task<IResult> HandleAsync(UpdateCatalogItemRequest request, IRepository<CatalogItem> repository)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity is null) { return Results.NotFound(); }

            CatalogItem.CatalogItemDetails details = new(name: request.Name, description: request.Description, price: request.Price);
            entity.UpdateDetails(details);
            entity.UpdateBrand(request.CatalogBrandId);
            entity.UpdateType(request.CatalogTypeId);

            await repository.UpdateAsync(entity);

            var dto = new CatalogItemDto { Id = entity.Id, Name = request.Name, Description = request.Description, Price = request.Price, CatalogBrandId = request.CatalogBrandId, CatalogTypeId = request.CatalogTypeId };
            var response =  new UpdateCatalogItemResponse();
            response.CatalogItem = dto;
            return Results.Ok(response);
        }
    }
}
