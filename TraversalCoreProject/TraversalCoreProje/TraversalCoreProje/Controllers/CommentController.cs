using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult _LeaveAComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult _LeaveAComment(Comment c)
        {
            c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.CommentState = true;
            cm.AddToTable(c);
            return RedirectToAction("Index","Destination");
        }
    }
}
