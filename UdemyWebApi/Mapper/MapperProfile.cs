using AutoMapper;
using System.ComponentModel;
using UdemyWebApi.DTOs.CategoryDTOs;
using UdemyWebApi.Entities;
namespace UdemyWebApi.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category,CategoryCreateDto>();
            CreateMap<Category,CategoryCreateDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,CategoryGetDto>();
            CreateMap<Category, CategoryGetDto>().ReverseMap();
        }
    }
}
