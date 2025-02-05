namespace TraversalCoreProje.CQRS.Results.DestinationResults
{
    public class GetDestinationByIdQueryResult
    {//güncellemek isteyeceğim verilerin listesini getircem
        public int DestinationId { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
    }
}
