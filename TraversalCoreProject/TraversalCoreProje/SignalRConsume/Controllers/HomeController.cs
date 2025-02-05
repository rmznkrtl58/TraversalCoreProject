using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRConsume.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRConsume.Controllers
{
    public class HomeController : Controller
    {
        //SignalR-PostgreSql Bağlantı kontrolü
        public IActionResult Index()
        {
            return View();
        }
        //SignalR-MSsql Bağlantı kontrolü
        public IActionResult Index2()
        {
            return View();
        }
        //SignalR-MSsql Grafiğe verilerin gelmesi
        public IActionResult Index3()
        {
            return View();
        }
    }
}
