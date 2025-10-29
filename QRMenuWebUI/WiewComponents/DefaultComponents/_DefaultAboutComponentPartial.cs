using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.WiewComponents.DefaultComponents
{
    public class _DefaultAboutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
    }

