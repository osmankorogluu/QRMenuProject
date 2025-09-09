using AutoMapper;
using QRMenu.EntityLayer.Entities;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;

namespace QRMenuAPI.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetFeatureDto>().ReverseMap();
            CreateMap<Product, UpdateFeatureDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();
        }
    }
}
