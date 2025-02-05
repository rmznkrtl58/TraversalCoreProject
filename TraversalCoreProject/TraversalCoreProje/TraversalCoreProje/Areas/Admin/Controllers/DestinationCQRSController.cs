using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestination;
        private readonly GetDestinationByIdQueryHandler _getDestinationById;
        private readonly CreateDestinationCommandHandler _createDestination;
        private readonly DeleteDestinationCommandHandler _deleteDestination;
        private readonly UpdateDestinationCommandHandler _updateDestination;
        public DestinationCQRSController(GetAllDestinationQueryHandler queryHandler, GetDestinationByIdQueryHandler getDestinationById, CreateDestinationCommandHandler createDestination, DeleteDestinationCommandHandler deleteDestination, UpdateDestinationCommandHandler updateDestination)
        {
            _getAllDestination = queryHandler;
            _getDestinationById = getDestinationById;
            _createDestination = createDestination;
            _deleteDestination = deleteDestination;
            _updateDestination = updateDestination;
        }
        //constructorumu startup tarafında yapılandırmam gerek
        public IActionResult Index()
        {
            var destinationList = _getAllDestination.Handle();
            return View(destinationList);
        }
        [HttpGet]
        public IActionResult GetDestinationById(int id)
        {
            var values = _getDestinationById.Handle(new GetDestinationByIdQuery(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult GetDestinationById(UpdateDestinationCommand c)
        {
            _updateDestination.Handle(c);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand c)
        {
            _createDestination.Handle(c);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDestination(int id)
        {
            _deleteDestination.Handle(new DeleteDestinationCommand(id));
            return View();
        }
    }
}
