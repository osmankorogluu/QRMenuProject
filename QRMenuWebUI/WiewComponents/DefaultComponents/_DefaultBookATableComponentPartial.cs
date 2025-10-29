using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.WiewComponents.DefaultComponents
{
    public class _DefaultBookATableComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
    
}
