using AutoMapper;
using SuperStore.API.Models;
using SuperStore.Models.Entities;

namespace SuperStore.API.Mappings
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, UpsertProductDto>();
            CreateMap<UpsertProductDto, Product>();
        }
    }
}
