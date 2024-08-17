using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase 
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }
        [HttpGet("NotificationCountByFalse")]
        public IActionResult NotificationCountByFalse()
        {
            return Ok(_notificationService.TNotificationCountByFalse());
        }
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse()); // return ok ile notificationları döndürüyoruz
        }
        [HttpPost]
        public IActionResult CreateNotification(CreataNotificationDto creataNotificationDto)
        {
            Notification notification = new Notification
            {
                Type = creataNotificationDto.Type,
                Icon = creataNotificationDto.Icon,
                Description = creataNotificationDto.Description,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = false
            };
            _notificationService.TAdd(notification);
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpDelete]
       public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Silme işlemi başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            return Ok(_notificationService.TGetByID(id));
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification
            {
                NotificationID = updateNotificationDto.NotificationID,
                Type = updateNotificationDto.Type,
                Icon = updateNotificationDto.Icon,
                Description = updateNotificationDto.Description,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = updateNotificationDto.Status,
            };
            _notificationService.TUpdate(notification);
            return Ok("Güncelleme işlemi başarılı");
        }

    }
}
