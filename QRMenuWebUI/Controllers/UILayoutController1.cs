using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.Controllers
{
    public class UILayoutController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
