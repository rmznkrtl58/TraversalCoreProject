using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Statistics:ViewComponent
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            ViewBag.i = dm.TGetListAll().Count;
            return View();
        }
    }
}
