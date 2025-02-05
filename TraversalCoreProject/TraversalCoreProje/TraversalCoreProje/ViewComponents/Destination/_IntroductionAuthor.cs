using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Destination
{
    public class _IntroductionAuthor:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _IntroductionAuthor(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _destinationService.TGetDestinationWithGuide(id);
            return View(values);
        }
    }
}
