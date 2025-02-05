using BusinessLogicLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _PhotoGallery:ViewComponent
    {
        FeatureManager fm = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            using (var ent=new Context())
            {
                //Solide uygun değil ama bir değer için 
                //yapıyom
                ViewBag.i = ent.Feature2s.Where(z => z.Feature2Id == 1).Select(x => x.Image).FirstOrDefault();
            }
            var values = fm.TGetListAll();
            return View(values);
        }
    }
}
