using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTables : ControllerBase
    {   
        private readonly IMenutableService _menutableService;

        public MenuTables(IMenutableService menutableService)
        {
            _menutableService = menutableService;
        }
        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
          return Ok(_menutableService.TMenuTableCount());
        }
    }
}
