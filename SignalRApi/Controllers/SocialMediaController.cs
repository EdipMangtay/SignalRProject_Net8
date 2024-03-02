using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;
using System.Diagnostics.Contracts;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(value);

        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createsocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                Title = createsocialMediaDto.Title,
                Icon = createsocialMediaDto.Icon,
                Url  =createsocialMediaDto.Url

            }); ;

            return Ok("Social Media Eklendi");


        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(values);
            return Ok("Contact silindi");

        }

        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia (int id)
        {
            var values = _socialMediaService.TGetByID(id);
            return Ok(values);

        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMedia updateSocialMedia)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                SocialMediaID = updateSocialMedia.SocialMediaID,
                Title = updateSocialMedia.Title,
                Icon = updateSocialMedia.Icon,
                Url = updateSocialMedia.Url
            });
            return Ok("Contact Güncellendi");

        }
    }
}
