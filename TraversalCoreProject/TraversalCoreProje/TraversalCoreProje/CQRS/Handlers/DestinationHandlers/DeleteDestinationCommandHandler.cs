using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class DeleteDestinationCommandHandler
    {
        private readonly Context _context;

        public DeleteDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(DeleteDestinationCommand d)
        {
            var findDestination = _context.Destinations.Find(d.Id);
            _context.Destinations.Remove(findDestination);
            _context.SaveChanges();
        }
    }
}
