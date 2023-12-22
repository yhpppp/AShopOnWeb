using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using MinimalApi.Endpoint;

namespace PublicApi.CatalogItemEndpoints
{
    public class CreateCatalogItemEndpoint : IEndpoint<IResult, CreateCatalogItemRequest, IRepository<CatalogItem>>
    {
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("api/catalog-items", async (CreateCatalogItemRequest result, IRepository<CatalogItem> repository) =>
            {
                return await HandleAsync(result, repository);
            }).WithTags("CatalogItemEndpoints").Produces<CreateCatalogItemResponse>();
        }

        public async Task<IResult> HandleAsync(CreateCatalogItemRequest request, IRepository<CatalogItem> repository)
        {
            var spec = new CatalogItemSpecification(request.Name);
            var ExistngCount = await repository.CountAsync(spec);
            if (ExistngCount > 0) { throw new DuplicateException($"A CatalogItem with name {request.Name} already exists"); }

            var newEntity = new CatalogItem(
                catalogBrandId: request.CatalogBrandId,
                catalogTypeId: request.CatalogTypeId,
                name: request.Name,
                description: request.Description,
                price: request.Price,
                pictureUrl: request.PictureUrl);
            newEntity = await repository.AddAsync(newEntity);

            var dto = new CatalogItemDto
            {
                Id = newEntity.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                PictureUrl = request.PictureUrl,
                CatalogBrandId = request.CatalogBrandId,
                CatalogTypeId = request.CatalogTypeId,
            };

            var response = new CreateCatalogItemResponse();
            response.CatalogItem = dto;
            return Results.Created($"api/catalog-items/{dto.Id}", response);
        }
    }
}
