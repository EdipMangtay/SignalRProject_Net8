using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);

        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            EntityLayer.Entities.Booking booking = new EntityLayer.Entities.Booking()
            {
                Mail = createBookingDto.Mail,
                Date = createBookingDto.Date,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone
            };
            _bookingService.TAdd(booking);
            return Ok("RezervasyonYapıldı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon Silindi");

        }
        [HttpPut]
        public IActionResult Updatebooking(UpdateBookingDto updateBookingDto)
        {
            EntityLayer.Entities.Booking booking = new EntityLayer.Entities.Booking()
            {
                Mail = updateBookingDto.Mail,
                BookingID = updateBookingDto.BookingID,
                Phone = updateBookingDto.Phone,
                PersonCount = updateBookingDto.PersonCount,
                Date = updateBookingDto.Date,
                Name = updateBookingDto.Name

            };
            _bookingService.TUpdate(booking);
            return Ok("Güncelleme işlemi yapıldı");
        }
        [HttpGet("{id}")]
        public IActionResult Getbooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);

        }

    }
}
