using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.ViewComponents.Dashboard
{
    public class Destination1:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
