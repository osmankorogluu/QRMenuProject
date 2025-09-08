using AutoMapper;
using QRMenu.EntityLayer.Entities;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.CategoryDto;

namespace QRMenuAPI.Mapping
{
    public class CategoryMapping: Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

        }
    }
}
