using AutoMapper;
using QRMenu.EntityLayer.Entities;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;

namespace QRMenuAPI.Mapping
{
    public class SocailMediaMapping:Profile
    {
        public SocailMediaMapping()
        {
            CreateMap<SocialMedia, ResultSocailMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocailMediaDto>().ReverseMap();
        }
    }
}
