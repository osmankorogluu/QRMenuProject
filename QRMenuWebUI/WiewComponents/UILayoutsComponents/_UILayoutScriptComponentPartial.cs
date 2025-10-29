using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.WiewComponents.UILayoutsComponents
{
    public class _UILayoutScriptComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
