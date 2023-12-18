using ApplicationCore.Entities;
using AutoMapper;
using PublicApi.CatalogBrandEndpoints;
using PublicApi.CatalogTypeEndpoints;

namespace PublicApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogBrand, CatalogBrandDto>().ForMember(dto => dto.Name, options => options.MapFrom(m => m.Brand));
            CreateMap<CatalogType, CatalogTypeDto>().ForMember(dto => dto.Name, options => options.MapFrom(m => m.Type));
        }
    }
}
