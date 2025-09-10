using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.WiewComponents.LayoutComponents
{
    public class _LayoutFooterComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
