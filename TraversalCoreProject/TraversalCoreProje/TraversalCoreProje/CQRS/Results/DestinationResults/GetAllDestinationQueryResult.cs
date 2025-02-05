using MimeKit.Tnef;

namespace TraversalCoreProje.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {   //Üye Olmayan kullanıcıya göstermek istediğim değerleri yazıyorum
        public int Id { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }

    }
}
