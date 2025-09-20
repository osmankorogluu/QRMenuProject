using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
