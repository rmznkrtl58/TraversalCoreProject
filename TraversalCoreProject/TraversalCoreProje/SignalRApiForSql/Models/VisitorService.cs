using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApiForSql.Dal;
using SignalRApiForSql.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApiForSql.Models
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;
        public VisitorService(Context context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        //Ziyaretçileri listeleme metodum IQueryable bir collection
        //türüdür list,IEnumerable yapıları gibi toplu verileri tutar
        public IQueryable<Visitor> GetListVisitor()
        {
            return _context.visitors.AsQueryable();
        }
        //Ziyaretçi ekleme metodum
        public async Task SaveVisitor(Visitor v)
        {
           await _context.visitors.AddAsync(v);
           await _context.SaveChangesAsync();
                                          //1.p->grafikleri getireceğimiz Indexte Invoke içerisinde
                                          //çağırıyoruz
            await _hubContext.Clients.All.SendAsync("ReceiveVisitorList", GetListVisitorChart());
        }
        public List<VisitorChart> GetListVisitorChart()
        {
            List<VisitorChart> visitorCharts= new List<VisitorChart>();
            using (var command=_context.Database.GetDbConnection().CreateCommand())
            {
                //CommandText->adonetteki gibi sorgu yazdığımız yapıdır
                command.CommandText = "Select tarih,[1],[2],[3],[4],[5] from" +
                    " (select [City],CityVisitCount,Cast([VisitDate] as Date) " +
                    "as tarih from Visitors) as visitTable Pivot (Sum(CityVisitCount) " +
                    "For City in([1],[2],[3],[4],[5])) as pivottable order by tarih asc";
                //sorgu tipimiz->elle yazılacak sql sorgusu olduğu için
                //text tipinde olacak
                command.CommandType = System.Data.CommandType.Text;
                //veri tabanımızın bağlantısını aç
                _context.Database.OpenConnection();
                using (var reader=command.ExecuteReader())
                {   //sorgumdan gelen verileri okumaya başla
                    //ve okuduğu müttetçe döngüye sok
                    while (reader.Read()) 
                    {
                        VisitorChart chart = new VisitorChart();
                        //VisitorChart sınıfımdaki VisitDate propuma 
                        //okunan tarih verileri içinden 0'ıncı yani ilk tarih verisinden
                        //başla ve  son tarihe kadar oku bu okunan verilerinde kısa tarih
                        //formatını al ve VisitDate propuma atama yap
                        chart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        //Visitor sınıfımda hatırlarsan bir enum yapısı oluşturup 
                        //her bir şehirin karşılığında birer rakam tanımlamıştık 
                        //burada yazılan sorguya göre gelen verilerden yola çıkarak
                        //Enumerable yapısı içerisinde aralık belirttik 1 ile 5 arasında
                        //çünkü şehirlerimiz 1 ile 5 arasında bir değerde tanımlanmıştı
                        //bu şehirler arasında bir döngüye gir
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            //dögüye girdikten sonra VisitorChart sınıfımdaki
                            //VisitCounts propuma ekleme yap değer nereden gelecek
                            //1 ile 5 arasındaki şehirlerden alınan ziyaret
                            //Sayısına bağlı olarak
                            if (DBNull.Value.Equals(reader[x]))//veritabanındaki veriler içeriyorsa
                            {
                                chart.VisitCounts.Add(0);
                            }
                            else
                            {
                                chart.VisitCounts.Add(reader.GetInt32(x));
                            }
                        });
                        //en sonda ilk başta list olarak tanımladığım VisitorCharts
                        //sınıfıma ekle
                        visitorCharts.Add(chart);
                    }
                }
                //veri tabanı bağlantısını kapat
                _context.Database.CloseConnection();
                return visitorCharts;
            }
        } 
    }
}
