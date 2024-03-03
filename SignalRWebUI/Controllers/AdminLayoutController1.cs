using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class AdminLayoutController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
