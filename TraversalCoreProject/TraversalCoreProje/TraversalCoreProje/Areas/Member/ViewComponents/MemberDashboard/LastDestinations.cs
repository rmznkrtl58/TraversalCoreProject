using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.ViewComponents.MemberDashboard
{
    public class LastDestinations:ViewComponent
    {
        private readonly IDestinationService _destinationService;
        public LastDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetLast4DestinationList();
            return View(values);
        }
    }
}
