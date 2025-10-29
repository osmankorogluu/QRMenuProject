using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.WiewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
    }

