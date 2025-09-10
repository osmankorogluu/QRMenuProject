using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.WiewComponents.LayoutComponents
{
    public class _LayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
