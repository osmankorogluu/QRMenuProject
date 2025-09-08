using AutoMapper;
using QRMenu.EntityLayer.Entities;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;

namespace QRMenuAPI.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
        }
    }
}
