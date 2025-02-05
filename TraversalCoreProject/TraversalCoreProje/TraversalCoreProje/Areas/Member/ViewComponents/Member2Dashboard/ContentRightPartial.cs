using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.ViewComponents.Member2Dashboard
{
    public class ContentRightPartial:ViewComponent
    {
        private readonly IGuideService _guideService;

        public ContentRightPartial(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _guideService.TGetLast5GuideList();
            return View(values);
        }
    }
}
