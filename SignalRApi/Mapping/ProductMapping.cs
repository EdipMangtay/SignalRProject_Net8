using AutoMapper;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ProductMapping: Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();

        }
    }
}
