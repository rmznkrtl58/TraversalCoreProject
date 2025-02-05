using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{

    //[Route("Admin/[controller]/[action]/")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DestinationController : Controller
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = dm.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination d)
        {
            d.Status = true;
            dm.AddToTable(d);
            return RedirectToAction("Index","Destination");
        }
        public IActionResult DeleteDestination(int id)
        {
            var findDestination=dm.TGetById(id);
            findDestination.Status = false;
            dm.UpdateTheTable(findDestination);
            return RedirectToAction("Index","Destination");
        }
        [HttpGet]
        public IActionResult EditDestination(int id)
        {
            var findDestination=dm.TGetById(id);
            return View(findDestination);
        }
        [HttpPost]
        public IActionResult EditDestination(Destination d)
        {
            d.Status=true;
            dm.UpdateTheTable(d);
            return RedirectToAction("Index", "Destination");
        }
    }
}
