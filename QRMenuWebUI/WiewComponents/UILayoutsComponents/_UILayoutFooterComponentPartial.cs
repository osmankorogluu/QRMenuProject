using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.WiewComponents.UILayoutsComponents
{
    public class _UILayoutFooterComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
