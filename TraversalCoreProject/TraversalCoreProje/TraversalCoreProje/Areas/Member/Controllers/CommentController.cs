﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
	[Area("Member")]
    [Route("Member/[controller]/[action]")]//arealarda hata almamak için gerekli
    public class CommentController : Controller
	{   
		public IActionResult Index()
		{
			return View();
		}
	}
}
