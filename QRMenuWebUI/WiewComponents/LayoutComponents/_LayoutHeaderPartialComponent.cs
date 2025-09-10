using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.WiewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
