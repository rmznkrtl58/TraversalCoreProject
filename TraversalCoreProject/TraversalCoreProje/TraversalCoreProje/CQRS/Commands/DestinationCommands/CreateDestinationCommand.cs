namespace TraversalCoreProje.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommand
    {   //Eklemek istediğim propları seçtim
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}
