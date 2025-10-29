using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
