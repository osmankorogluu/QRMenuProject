using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.WiewComponents.LayoutComponents
{
    public class _LayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
  