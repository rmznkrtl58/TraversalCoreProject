using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateDestinationCommand c)
        {
            var findDestination = _context.Destinations.Find(c.DestinationId);
            findDestination.City=c.City;
            findDestination.DayNight=c.DayNight;
            findDestination.Price=c.Price;
            findDestination.Status = true;
            _context.Destinations.Update(findDestination);
            _context.SaveChanges();
        }
    }
}
