using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;
using TraversalCoreProje.CQRS.Results.DestinationResults;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIdQueryHandler
    {
        //Id 'ye göre veri getirme işlemi
        private readonly Context _context;

        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
        {
            var findDestination = _context.Destinations.Find(query.id);
            return new GetDestinationByIdQueryResult
            {
                City = findDestination.City,
                DayNight = findDestination.DayNight,
                DestinationId = findDestination.DestinationId,
                Price=findDestination.Price
            };
        }
    }
}
