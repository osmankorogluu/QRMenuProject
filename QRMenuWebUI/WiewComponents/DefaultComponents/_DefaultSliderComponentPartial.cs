using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.WiewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
    }

