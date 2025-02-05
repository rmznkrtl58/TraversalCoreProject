using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
