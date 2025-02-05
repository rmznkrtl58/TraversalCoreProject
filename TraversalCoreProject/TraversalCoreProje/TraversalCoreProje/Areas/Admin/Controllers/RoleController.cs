using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        //Rolleri Listeleme
        public IActionResult Index()
        {
            var roleList = _roleManager.Roles.ToList();
            return View(roleList);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View ();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(CreateRoleViewModel c)
        {
            AppRole role = new AppRole()
            {
                Name = c.RoleName
            };
            var result=await _roleManager.CreateAsync(role);
            if (result.Succeeded) 
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var findRole = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(findRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var findRole = _roleManager.Roles.FirstOrDefault(x=>x.Id==id);
            UpdateRoleViewModel model = new UpdateRoleViewModel()
            {
                RoleId = findRole.Id,
                RoleName = findRole.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var findRole = _roleManager.Roles.FirstOrDefault(x => x.Id == model.RoleId);
            findRole.Name = model.RoleName;
            var result=await _roleManager.UpdateAsync(findRole);
            if (result.Succeeded) 
            { 
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult UserList()
        {
            var values=_userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var findUser = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userId"] = findUser.Id;
            var roles = _roleManager.Roles.ToList();
            //Bulunun kullanıcının rollerini getirme işlemi
            var userRoles =await _userManager.GetRolesAsync(findUser);
            List<RoleAssignViewModel>roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach(var x in roles)//roller içerisinden atama yap
            {
                RoleAssignViewModel model=new RoleAssignViewModel();
                model.RoleId = x.Id;
                model.RoleName = x.Name;
                model.RoleExist = userRoles.Contains(x.Name);
                //rollerdeki rol adı kullanıcının rollerinde mevcutsa true gelsin
                //mevcut değilse false gelsin
                roleAssignViewModels.Add(model);
            }
            return View(roleAssignViewModels);
        }
        [HttpPost]                     //birden fazla rol ataması yapmamdan dolayı
                                       //list şeklinde parametre yolluyorum
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> models)
        {
            var userId = (int)TempData["userId"];
            var findUser = _userManager.Users.FirstOrDefault(y => y.Id == userId);
            foreach(var x in models)
            {
                if (x.RoleExist)//rolleri seçiliyse true seçili değilse false
                {
                    await _userManager.AddToRoleAsync(findUser, x.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(findUser, x.RoleName);
                }
            }
            return RedirectToAction("UserList");
        }
    }
}
