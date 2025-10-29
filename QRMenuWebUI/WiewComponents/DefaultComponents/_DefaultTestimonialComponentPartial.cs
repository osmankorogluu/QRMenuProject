using Microsoft.AspNetCore.Mvc;

namespace QRMenuWebUI.WiewComponents.DefaultComponents
{
    public class _DefaultTestimonialComponentPartial:ViewComponent  
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
    }

