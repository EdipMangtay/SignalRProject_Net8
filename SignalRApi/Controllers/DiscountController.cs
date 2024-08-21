using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;
using System.Runtime.CompilerServices;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {


        private readonly IDiscoutService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscoutService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map < List <ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);

        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new EntityLayer.Entities.Discount()
            {
                Description = createDiscountDto.Description,
                Title = createDiscountDto.Title,
                Amount = createDiscountDto.Amount,
                ImageUrl = createDiscountDto.ImageUrl,
                Status = false

            });

            return Ok("Kategori Eklendi");


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var values = _discountService.TGetByID(id);
            _discountService.TDelete(values);
            return Ok("indirim Bilgisi silindi");

        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var values = _discountService.TGetByID(id);
            return Ok(values);

        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new EntityLayer.Entities.Discount()
            {
                DiscountID = updateDiscountDto.DiscountID,
                Amount = updateDiscountDto.Amount,
                ImageUrl = updateDiscountDto.ImageUrl,
                Description = updateDiscountDto.Description,
                Title  = updateDiscountDto.Title,
                Status = false

            });
            return Ok("indirim Güncellendi");

        }
		[HttpGet("ChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			_discountService.TChangeStatusToTrue(id);
			return Ok("Ürün İndirimi Aktif Hale Getirildi");
		}

		[HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);
			return Ok("Ürün İndirimi Pasif Hale Getirildi");
		}

		//[HttpGet("GetListByStatusTrue")]
		//public IActionResult GetListByStatusTrue()
		//{
		//	return Ok(_discountService.TGetListByStatusTrue());
		//}
	}
}