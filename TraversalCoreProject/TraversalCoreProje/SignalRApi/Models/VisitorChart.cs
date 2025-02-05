using System.Collections.Generic;

namespace SignalRApi.Models
{
    public class VisitorChart
    {
        public VisitorChart()
        {
            VisitCounts= new List<int>();
        }
        //hangi tarihlerde kaç kişi ziyaret etmiş
        public string VisitDate { get; set; }
        public List<int> VisitCounts { get; set; }
    }
}
