using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.ViewComponents.MemberDashboard
{
    public class GuideList:ViewComponent
    {
        GuideManager gm = new GuideManager(new EfGuideDal());
        public IViewComponentResult Invoke()
        {
            var values = gm.TGetListAll();
            return View(values);
        }
    }
}
