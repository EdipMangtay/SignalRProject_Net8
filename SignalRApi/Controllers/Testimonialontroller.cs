using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;
using System.Runtime.InteropServices;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Testimonialontroller : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public Testimonialontroller(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);
        }


        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                Name =createTestimonialDto.Name,
                Title = createTestimonialDto.Title,
                Comment = createTestimonialDto.Comment,
                ImgUrl = createTestimonialDto.ImgUrl,
                Status  =createTestimonialDto.Status
            });
            return Ok("Product Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
           // var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(_testimonialService.TGetByID(id));
            return Ok("Testimonial Kalktı");
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return Ok(values);

        }

        [HttpPut]

        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonial)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialID = updateTestimonial.TestimonialID,
                Name = updateTestimonial.Name,
                Title = updateTestimonial.Title,
                Comment = updateTestimonial.Comment,
                ImgUrl = updateTestimonial.ImgUrl,
                Status = updateTestimonial.Status
            });
            return Ok("Testimonial Güncellendi");

        }

    }

}
