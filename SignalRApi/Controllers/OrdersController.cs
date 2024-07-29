using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;   //burada IOrderService interface'ini kullanarak OrderManager class'ını çağırdık

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount()); 
           // burada OrderManager class'ındaki TotalOrderCount methodunu çağırdık
        }
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
            // burada OrderManager class'ındaki ActiveOrderCount methodunu çağırdık
        }
        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
            // burada OrderManager class'ındaki LastOrderPrice methodunu çağırdık
        }
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            return Ok(_orderService.TodayTotalPrice()); // burada OrderManager class'ındaki TodayTotalPrice methodunu çağırdık
            // burada OrderManager class'ındaki TodayTotalPrice methodunu çağırdık
        }
        
    }
}
