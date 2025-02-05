using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Route("Member/[controller]/[action]")]//arealarda hata almamak için gerekli
    public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
