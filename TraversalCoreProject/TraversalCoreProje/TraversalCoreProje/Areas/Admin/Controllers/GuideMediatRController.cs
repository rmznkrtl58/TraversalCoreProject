using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Commands.GuideCommands;
using TraversalCoreProje.CQRS.Handlers.GuideHandlers;
using TraversalCoreProje.CQRS.Queries.GuideQueries;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
                                   //IRequest'in miras aldığı sınıfı çağırcam
            var listGuide = await _mediator.Send(new GetAllGuideQuery());
            return View(listGuide);
        }
        [HttpGet]
        public async Task<IActionResult> GetGuideById(int id)
        {
            var findGuide =await _mediator.Send(new GetGuideByIdQuery(id));
            return View(findGuide);
        }
        [HttpPost]
        public async Task<IActionResult> GetGuideById()
        {
            //var findGuide = _mediator.Send(new GetGuideByIdQuery());
            return View();
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand g)
        {
            await _mediator.Send(g);
            return RedirectToAction("Index");
        }
    }
}
