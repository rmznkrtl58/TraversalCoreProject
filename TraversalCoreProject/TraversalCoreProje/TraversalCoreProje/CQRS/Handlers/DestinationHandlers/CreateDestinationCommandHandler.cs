using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;
        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        //Create Destination Command sınıfımda ekleme yapmak istediğim
        //alanları tanımlamıştım parametre olarakta o alanlara gelen 
        //değerleri veritabanımdaki proplara atama yapmam gerek
        public void Handle(CreateDestinationCommand c)
        {
            _context.Destinations.Add(new Destination
            {
                City = c.City,
                DayNight = c.DayNight,
                Price = c.Price,
                Capacity = c.Capacity,
                Status = true
            });
            _context.SaveChanges();
        }
    }
}
