using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProje.Areas.Member.Controllers
{
   
    [Area("Member")]
    [Route("Member/[controller]/[action]")]//arealarda hata almamak için gerekli
    public class DestinationController : Controller
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        public IActionResult Index(string searchData)
        {
            ViewData["stringValue"]= searchData;
            var findData = from x in dm.TGetListAll() select x;
            if (!string.IsNullOrEmpty(searchData))//searchData parametrem boş değilse
            {
                findData = findData.Where(a => a.City.Contains(searchData)).ToList();
            }
            ViewBag.v1 = "Tüm Rotalar";
            ViewBag.v2 = "Rotalar";
            ViewBag.v3 = "Tüm Rotalar";
            var values=dm.TGetListAll();
            return View(findData.ToList());
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}
