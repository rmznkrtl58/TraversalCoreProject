using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProje.Areas.Member.ViewComponents.Member2Dashboard
{
    public class ContentLeftPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {   //solide aykırı ilerde düzelecek
            using (var ent=new Context() )
            {
                var values = ent.About2s.ToList();
                return View(values);
            }
        }
    }
}
