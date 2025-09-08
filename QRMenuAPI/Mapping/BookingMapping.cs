using AutoMapper;
using QRMenu.EntityLayer.Entities;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;

namespace QRMenuAPI.Mapping
{
    public class BookingMapping: Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, GetBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();

        }
    }
}
