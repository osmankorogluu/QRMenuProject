using AutoMapper;
using QRMenu.EntityLayer.Entities;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;

namespace QRMenuAPI.Mapping
{
    public class FeatureMapping:Profile

    {
        public FeatureMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        }
    }
}
