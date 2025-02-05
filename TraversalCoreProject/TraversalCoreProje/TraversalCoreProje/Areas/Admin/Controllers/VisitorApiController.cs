using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{   //Api'nin sürekli açık kalması gerekiyor yoksa burdaki actionlar
    //ve viewlar çalışmaz
    //apileri consume ettiğimiz user interface tarafına çektiğimiz ve 
    //apileri tükettiğimiz yerdir
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
                                               //swaggerdaki request url alanı
            var responseMessage = await client.GetAsync("http://localhost:9853/api/Visitor");
                                         //parametsesiz GetAsync Kullanımı
            //apilere istek göndeririz ve sonucunda bu istekte başarılıysa aşağıdaki
            //adımları takip etsin biz zaten api projesi içerisinde  gerekli
            //crud işlemlerinin olaylarını yazdık
            if (responseMessage.IsSuccessStatusCode)//istek yanıtı başarılıysa
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                //listelemede deserilaze kullanıyoruz
                var getVisitors = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
                return View(getVisitors);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddVisitor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorViewModel v)
        {
            var client = _httpClientFactory.CreateClient();
            //eklemelerde serializeObject kullanılır.
            var jsonData=JsonConvert.SerializeObject(v);
            StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:9853/api/Visitor",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","VisitorApi");
            }
            return View();
        }
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:9853/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "VisitorApi");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditVisitor(int id)
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage =await client.GetAsync($"http://localhost:9853/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var getVisitor = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
                return View(getVisitor);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditVisitor(VisitorViewModel v)
        {
            var client=_httpClientFactory.CreateClient();
            //güncellemelerde ve eklemelerde serialize
            //listeleme ve veri getirmede deserialize
            var jsonData=JsonConvert.SerializeObject(v);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage =await client.PutAsync("http://localhost:9853/api/Visitor",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "VisitorApi");
            }
            return View();
        }
    }
}
//API(Application Programming Interface): Bir uygulamanın başka bir
//uygulamayla iletişim kurmasını sağlayan bir ara yüzdür.
//HttpClient: Bu API'lere HTTP protokolü üzerinden
//GET, POST, PUT, DELETE gibi istekler göndermek için kullanılan bir sınıftır.