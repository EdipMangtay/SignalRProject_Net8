using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalRApi.EntityLayer.Entities;
using System.Reflection;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet] // listeleme için 
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll(); 
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About About = new About() // mapping yapabilmem için eklenen about kısmı 
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl
            };

            _aboutService.TAdd(About);
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value =_aboutService.TGetByID(id); 
            _aboutService.TDelete(value);
            return Ok("Hakkımda alanı silindi");

        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                Aboutid = updateAboutDto.Aboutid,
                ImageUrl = updateAboutDto.ImageUrl,
                Description = updateAboutDto.Description,
                Title = updateAboutDto.Title
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda alanı güncellendi");

        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
             var value = _aboutService.TGetByID(id);
            return Ok(value);

        }


    }
}
