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
            return Ok(_notificationService.TGetAllNotificationByFalse()); // false statüsünde olan notificationları döndürür
        }

        [HttpPost]
        public IActionResult CreateNotification(CreataNotificationDto creataNotificationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Notification notification = new Notification
            {
                Type = creataNotificationDto.Type,
                Icon = creataNotificationDto.Icon,
                Description = creataNotificationDto.Description,
                Date = DateTime.Now, // Sadece gün ve saat bilgisi
                Status = false
            };

            _notificationService.TAdd(notification);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            if (value == null)
            {
                return NotFound("Silinecek bildirim bulunamadı.");
            }

            _notificationService.TDelete(value);
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var notification = _notificationService.TGetByID(id);
            if (notification == null)
            {
                return NotFound("Bildirim bulunamadı.");
            }

            return Ok(notification);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNotification(int id, UpdateNotificationDto updateNotificationDto)
        {
            if (id != updateNotificationDto.NotificationID)
            {
                return BadRequest("Bildirim ID uyuşmazlığı.");
            }

            var existingNotification = _notificationService.TGetByID(id);
            if (existingNotification == null)
            {
                return NotFound("Güncellenecek bildirim bulunamadı.");
            }

            // Mevcut bildirim güncelleniyor
            existingNotification.Type = updateNotificationDto.Type;
            existingNotification.Icon = updateNotificationDto.Icon;
            existingNotification.Description = updateNotificationDto.Description;
            existingNotification.Date = DateTime.Now; // Güncellenme tarihi
            existingNotification.Status = updateNotificationDto.Status;

            _notificationService.TUpdate(existingNotification);
            return Ok("Güncelleme işlemi başarılı");
        }
        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Bildirim durumu false olarak değiştirildi.");
        }
        [HttpGet("NotificationStatusChangeToTrue")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Bildirim durumu True olarak değiştirildi.");
        }


    }
}
