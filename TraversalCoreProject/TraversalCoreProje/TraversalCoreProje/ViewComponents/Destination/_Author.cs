using BusinessLogicLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace TraversalCoreProje.ViewComponents.Destination
{
    public class _Author:ViewComponent
    {   //şimdilik solide aykırı yazıyorum ilerde refactoring kullanacağım
        private readonly IDestinationService _destinationService;

        public _Author(IDestinationService destinationService)
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
