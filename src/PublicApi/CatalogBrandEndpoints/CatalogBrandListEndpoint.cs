using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using MinimalApi.Endpoint;
using PublicApi.CatalogBrandEndpoints;

namespace PublicApi.CatalogBrandEndpoint
{
    public class CatalogBrandListEndpoint : IEndpoint<IResult, IRepository<CatalogBrand>>
    {
        private readonly IMapper _mapper;

        public CatalogBrandListEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/catalog-brands", async (IRepository<CatalogBrand> repository) =>
            {
                return await HandleAsync(repository);
            }).Produces<ListCatalogBrandsResponse>().WithTags("CatalogBrandEndpoints");
        }

        public async Task<IResult> HandleAsync(IRepository<CatalogBrand> repository)
        {
            var list = await repository.ListAsync();
            var response = new ListCatalogBrandsResponse();
            response.CatalogBrands.AddRange(list.Select(_mapper.Map<CatalogBrandDto>));
            return Results.Ok(response);
        }
    }
}
