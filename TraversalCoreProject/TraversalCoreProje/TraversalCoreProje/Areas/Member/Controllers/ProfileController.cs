using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Member.Models;

namespace TraversalCoreProje.Areas.Member.Controllers
{   //profil bilgilerini getirme:
	//area-member-models içerisine UserEditViewModel oluşturdum
	//gerisi aşağıda
	//Profil bilgilerini güncelleme:UserEditViewModel Üzerinden 
	//yapıyoruz gerisini biliyon zaten

	[Area("Member")]
	[Route("Member/[controller]/[action]")]//arealarda hata almamak için gerekli
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
			_userManager=userManager;
		}
		[HttpGet]
        public async Task<IActionResult> Index()
		{
            ViewBag.v1 = "Bilgiler";
            ViewBag.v2 = "Profil Bilgileri";
            ViewBag.v3 = "Bilgiler";
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel model = new UserEditViewModel()
			{
				mail = values.Email,
				surName=values.Surname,
				name = values.Name,
			};
			return View(model);
		}
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
			var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid) { 
            if (model.Image != null)//resim seçiliyse
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var newFileName = Guid.NewGuid() + extension;
                var fileLocation = resource + "/wwwroot/UserImages/" + newFileName;
                var stream = new FileStream(fileLocation, FileMode.Create);
                await model.Image.CopyToAsync(stream);
                //modelime bağlı Image'daki seçmiş olduğum dosyayı 
                //filelocation değişkenimdeki konuma kopyasını oluştur.
                findUser.ImageUrl = newFileName;
            }
            findUser.Surname = model.surName;
            findUser.Name = model.name;
            findUser.Email = model.mail;
            findUser.PasswordHash = _userManager.PasswordHasher.HashPassword(findUser, model.password);
            var result = await _userManager.UpdateAsync(findUser);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            else
            {
                foreach(var x in result.Errors)
                    {
                        ModelState.AddModelError(x.Code, x.Description);
                    }
            }
            }
            return View();
        }
    }
}
