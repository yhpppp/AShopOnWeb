using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using MinimalApi.Endpoint;
using System.Collections.Generic;

namespace PublicApi.CatalogTypeEndpoints
{
    public class CatalogTypeListEndpoint : IEndpoint<IResult, IRepository<CatalogType>>
    {
        private readonly IMapper _mapper;

        public CatalogTypeListEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/catalog-types", async (IRepository<CatalogType> repository) =>
            {
                return await HandleAsync(repository);
            }).WithTags("CatalogTypeEndpoints").Produces<ListCatalogTypesResponse>();
        }

        public async Task<IResult> HandleAsync(IRepository<CatalogType> repository)
        {
            var list = await repository.ListAsync();
            var response = new ListCatalogTypesResponse();
            response.CatalogTypes.AddRange(list.Select(_mapper.Map<CatalogTypeDto>));
            return Results.Ok(response);
        }
    }
}
