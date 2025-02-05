using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApi.Dal;
using SignalRApi.Models;
using System;
using System.Collections;
using System.Linq;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _visitorService;

        public VisitorController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        //Startup tarafında yapılandırman gereken yerler var unutma!
        [HttpGet]
        public ActionResult CreateVisitor()
        {
            Random randomValue=new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x =>
            {
                foreach (ECity item in Enum.GetValues(typeof(ECity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = item,
                        CityVisitCount = randomValue.Next(100, 2000),
                        VisitDate = DateTime.Now.AddDays(x),
                    };
                    _visitorService.SaveVisitor(newVisitor).Wait();
                    System.Threading.Thread.Sleep(1000);//her bir saniyede 
                    //ekleme yap
                }
            });
            return Ok("Ziyaretçiler başarılı bir şekilde eklendi");
        }
    }
}
