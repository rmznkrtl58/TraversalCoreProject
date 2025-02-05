using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ContactUsController : Controller
    {
        IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values=_contactUsService.TGetListAll();
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var findMessage= _contactUsService.TGetById(id);
            return View(findMessage);
        }
    }
}
