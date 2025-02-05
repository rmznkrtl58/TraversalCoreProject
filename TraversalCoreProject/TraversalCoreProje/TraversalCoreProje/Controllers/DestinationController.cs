using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            ViewBag.k = "Rotalar";
            ViewBag.k2 = "Turlarımız";
            ViewBag.k3 = "Rotalar";
            var values = dm.TGetListAll();
            return View(values);
        }
        public IActionResult DestinationDetails(int id)
        {
            var values=dm.TGetById(id);
            ViewBag.k = "Rotalar";
            ViewBag.k2 = "Tur Detayları";
            ViewBag.k3 = "Rotalar";
            ViewBag.id = id;
            return View(values);
        }
    }
}
