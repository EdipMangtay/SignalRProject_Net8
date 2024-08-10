using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() // This method is called when the view component is invoked
        {
            return View();
        }
    }
}
