using System;

namespace SignalRApiForSql.Dal
{
    //bir enumerable listesi oluşturuyorum
    public enum ECity
    {
        İstanbul = 1,
        Ankara = 2,
        İzmir = 3,
        Antalya = 4,
        Muğla = 5
    }
    public class Visitor
    {
        public int VisitorId { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
