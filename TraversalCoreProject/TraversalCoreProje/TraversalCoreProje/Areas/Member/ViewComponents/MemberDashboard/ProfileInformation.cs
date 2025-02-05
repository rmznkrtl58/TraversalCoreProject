using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.ViewComponents.MemberDashboard
{
    public class ProfileInformation:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()//async işlemler kullanıyorsan
                                              //InvokeAsync Çağırmalısın
        {
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.membername = findUser.Name + " " + findUser.Surname;
            ViewBag.email = findUser.Email;
            ViewBag.phone = findUser.PhoneNumber;
            return View();
        }
    }
}
