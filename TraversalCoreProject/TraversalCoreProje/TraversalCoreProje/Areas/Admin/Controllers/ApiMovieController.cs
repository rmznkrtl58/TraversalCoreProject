using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ApiMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //oluşturduğum modelde rapid apideki propların aynısını
            //tanımladım şimdi list türünde bir movieviewmodel'e bağlı
            //olan bir clasıma bağlı nesne oluşturdum 
            List<MovieViewModel>movies= new List<MovieViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "f365ad9247mshf04a630f9851b16p13c6aejsn45af46c8e35c" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                //body içerisine  imdb top 100 filiminin 
                //verilerini okuyup atıyoruz
                var body = await response.Content.ReadAsStringAsync();
                var movieList=JsonConvert.DeserializeObject<List<MovieViewModel>>(body);
                return View(movieList);
            }
        }
    }
}
