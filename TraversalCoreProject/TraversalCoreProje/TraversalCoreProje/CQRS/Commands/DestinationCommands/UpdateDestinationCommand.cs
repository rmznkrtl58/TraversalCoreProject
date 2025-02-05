namespace TraversalCoreProje.CQRS.Commands.DestinationCommands
{
    public class UpdateDestinationCommand
    {//güncelleme yapmak istediğim proplarımı yazdım
        public int DestinationId { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
    }
}
