using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

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
		[HttpGet] // listeleme için 
		public IActionResult MenuTableList()
		{
			var values = _menutableService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTable)
		{
			MenuTable MenuTable = new MenuTable()  
			{
				Name = createMenuTable.Name,
				Status = false
			};

			_menutableService.TAdd(MenuTable);
			return Ok("Masa başarılı bir şekilde eklendi");

		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menutableService.TGetByID(id);
			_menutableService.TDelete(value);
			return Ok("MenuTable alanı silindi");

		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTable)
		{
			MenuTable MenuTable = new MenuTable() // mapping yapabilmem için eklenen about kısmı 
			{
				Name = updateMenuTable.Name,
				Status = false,
				MenuTableID = updateMenuTable.MenuTableID
			};
			_menutableService.TUpdate(MenuTable);
			return Ok("Masa alanı güncellendi");

		}
		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menutableService.TGetByID(id);
			return Ok(value);

		}
	}
}
