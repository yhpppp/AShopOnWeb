using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using MinimalApi.Endpoint;

namespace PublicApi.CatalogItemEndpoints
{
    public class CatalogItemListPagedEndpoint : IEndpoint<IResult, IRepository<CatalogItem>>
    {
        private readonly IMapper _mapper;

        public CatalogItemListPagedEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/catalog-items", async (IRepository<CatalogItem> repository) =>
            {
                return await HandleAsync(repository);
            }).WithTags("CatalogItemEndpoints").Produces<ListPagedCatalogItemResponse>();
        }

        public async Task<IResult> HandleAsync(IRepository<CatalogItem> repository)
        {
            var list = await repository.ListAsync();
            var response = new ListPagedCatalogItemResponse();
            response.CatalogItems.AddRange(list.Select(_mapper.Map<CatalogItemDto>));
            return Results.Ok(response);
        }
    }
}
