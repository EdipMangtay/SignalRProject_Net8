using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using SignalR.DtoLayer.CategoryDto;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();

        }

    }
}
