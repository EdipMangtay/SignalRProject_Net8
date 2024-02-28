using AutoMapper;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class FeatureMapping :Profile
    {

        public FeatureMapping()
        {
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureDto>().ReverseMap();


        }

    }
}
