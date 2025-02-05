using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            ViewBag.k = "Ekip Arkadaşlarımız";
            ViewBag.k2 = "Rehberler";
            ViewBag.k3 = "Ekip Arkadaşlarımız";
            var values = _guideService.TGetListAll();
            return View(values);
        }
    }
}
