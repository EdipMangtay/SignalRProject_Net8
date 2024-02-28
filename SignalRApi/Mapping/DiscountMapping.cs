using AutoMapper;
using SignalR.DtoLayer.DiscountDto;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();



        }

    }
}
