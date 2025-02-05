using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;
        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        public IActionResult Index()
        {
            var values=_guideService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide g)
        {
            GuideValidator gv = new GuideValidator();
            ValidationResult validationResult = gv.Validate(g); ;
            if (validationResult.IsValid)
            {
                g.Status = true;
                g.TwitterUrl = "https://twitter.com";
                g.InstagramUrl = "https://www.instagram.com";
                _guideService.AddToTable(g);
                return RedirectToAction("Index","Guide");
            }
            else
            {
                foreach(var x in validationResult.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var findGuide=_guideService.TGetById(id);
            return View(findGuide);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide g)
        {
            g.Status = true;
            _guideService.UpdateTheTable(g);
            return RedirectToAction("Index");
        }
    }
}
