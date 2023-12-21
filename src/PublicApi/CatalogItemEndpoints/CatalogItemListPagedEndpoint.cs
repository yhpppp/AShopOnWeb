using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;
using Infrastructure.Data;
using MinimalApi.Endpoint;

namespace PublicApi.CatalogItemEndpoints
{
    public class CatalogItemListPagedEndpoint : IEndpoint<IResult, ListPagedCatalogItemRequest, IRepository<CatalogItem>>
    {
        private readonly IMapper _mapper;

        public CatalogItemListPagedEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/catalog-items", async (int? pageSize, int? pageIndex, int? catalogBrandId, int? catalogTypeId, IRepository<CatalogItem> repository) =>
            {
                return await HandleAsync(new ListPagedCatalogItemRequest(pageSize, pageIndex, catalogBrandId, catalogTypeId), repository);
            }).WithTags("CatalogItemEndpoints").Produces<ListPagedCatalogItemResponse>();
        }
        
        public async Task<IResult> HandleAsync(ListPagedCatalogItemRequest request, IRepository<CatalogItem> repository)
        {
            // 过滤品牌、类型 && 分页
            var listSpec = new CatalogFilterPaginatedSpecification(
                skip: request.PageIndex * request.PageSize,
                take: request.PageSize,
                brandId: request.CatalogBrandId,
                typeId: request.CatalogTypeId);
            var list = await repository.ListAsync(listSpec);
            var response = new ListPagedCatalogItemResponse();
            response.CatalogItems.AddRange(list.Select(_mapper.Map<CatalogItemDto>));

            var filterSpec = new CatalogFilterSpecification(request.CatalogBrandId, request.CatalogTypeId);
            var totalItems = await repository.CountAsync(filterSpec);
            // 计算商品页总数
            if (request.PageSize > 0)
            {
                var count = Math.Ceiling((decimal)totalItems / request.PageSize);
                response.PageCount = int.Parse(count.ToString());
            }
            else
            {
                response.PageCount = totalItems > 0 ? 1 : 0;
            }
            return Results.Ok(response);
        }
    }
}
