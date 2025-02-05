using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProje.Areas.Admin.ViewComponents.Dashboard
{
    public class DashboardStatistics1:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public DashboardStatistics1(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        Context ent = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.d1 = ent.Destinations.Count();
            ViewBag.d2=_userManager.Users.Count();
            return View();
        }
    }
}
