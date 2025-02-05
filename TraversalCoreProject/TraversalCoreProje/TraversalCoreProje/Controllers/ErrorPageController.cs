using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
