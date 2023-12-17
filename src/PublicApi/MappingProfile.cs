using ApplicationCore.Entities;
using AutoMapper;
using PublicApi.CatalogBrandEndpoints;

namespace PublicApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogBrand, CatalogBrandDto>().ForMember(dto => dto.Name, options => options.MapFrom(m => m.Brand));
        }
    }
}
