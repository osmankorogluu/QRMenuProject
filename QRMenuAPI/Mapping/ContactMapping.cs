using AutoMapper;
using QRMenu.EntityLayer.Entities;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;

namespace QRMenuAPI.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
            CreateMap<Contact, UpdateResultDto>().ReverseMap();
        }
    }
}
