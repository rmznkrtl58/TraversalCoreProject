using BusinessLogicLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TraversalCoreProje.Areas.Admin.Controllers
{   //Ajax işlemleri
    //1)view tarafında script eklemen lazım jguery.min.js
    //2)backend tarafında json formatında verilerimi çağırıyorum
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        //dinamik ajax işlemleri 
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CityList()
        {   //Ajax Listeleme
            //json formatında çağırıyorum
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetListAll());
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(Destination d)
        {
            //Ajax ile ekleme
            d.Status = true;
            d.Capacity = 15;
            d.Image = "ajax denemesi";
            d.Image1 = "ajax denemesi";
            d.Image2 = "ajax denemesi";
            d.CoverImage = "ajax denemesi";
            d.Description = "ajax denemesi";
            d.Details1 = "ajax denemesi";
            d.Details2 = "ajax denemesi";
            _destinationService.AddToTable(d);
            var values=JsonConvert.SerializeObject(d);
            return Json(values);
        }
        public IActionResult GetCityById(int DestinationId)
        {
            //Ajax ile veritabanından veri getirme
            var values=_destinationService.TGetById(DestinationId);
            var jsonValues= JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }
        public IActionResult DeleteCity(int id)
        {
            var findDestination= _destinationService.TGetById(id);
            _destinationService.DeleteFromTable(findDestination);
            return NoContent();//hiçbir değer içerik getirme boş döndür
        }
        public IActionResult UpdateDestination(Destination d)
        {
            d.Status = true;
            d.Capacity = 15;
            d.Image = "ajax denemesi";
            d.Image1 = "ajax denemesi";
            d.Image2 = "ajax denemesi";
            d.CoverImage = "ajax denemesi";
            d.Description = "ajax denemesi";
            d.Details1 = "ajax denemesi";
            d.Details2 = "ajax denemesi";
            _destinationService.UpdateTheTable(d);
            var values= JsonConvert.SerializeObject(d);
            return Json(values);
        }
    }
}
