using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
