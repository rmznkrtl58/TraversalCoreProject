
using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.ViewComponents.Member2Dashboard
{
    public class ContentCenterPartial:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public ContentCenterPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetListAll();
            return View(values);
        }
    }
}
