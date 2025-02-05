using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public DashboardController(UserManager<AppUser> userManager)
        { 
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {

            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = findUser.Name + " " + findUser.Surname;
            ViewBag.userImage = findUser.ImageUrl;
            return View();
        }
        public IActionResult MemberDashboard()
        {
            ViewBag.v1 = "Bilgiler";
            ViewBag.v2 = "Dashboard";
            ViewBag.v3 = "Bilgiler";
            return View();
        }
    }
}
