using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class CommentController : Controller
    {
        //CommentManager cm = new CommentManager(new EfCommentDal());
        //newleme işleminden kurtarmam için service tarafında constructor metod oluşturdum.
        //startup.cs dede yapman gerekenler var!
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.GetCommentWithDestination();
            return View(values);
        }
        public IActionResult DeleteComment(int id)
        {
            var findComment=_commentService.TGetById(id);
            findComment.CommentState = false;
            _commentService.UpdateTheTable(findComment);
            return RedirectToAction("Index", "Destination", new {area=""});
        }
    }
}
