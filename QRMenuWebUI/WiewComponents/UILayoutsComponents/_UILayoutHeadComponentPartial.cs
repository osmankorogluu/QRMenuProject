using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.WiewComponents.UILayoutsComponents
{
    public class _UILayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
