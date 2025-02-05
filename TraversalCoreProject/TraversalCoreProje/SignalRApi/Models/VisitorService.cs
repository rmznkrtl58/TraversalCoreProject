using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApi.Dal;
using SignalRApi.Hubs;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SignalRApi.Models
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
           await _hubContext.Clients.All.SendAsync("GetVisitorList","");
        }
        public List<VisitorChart> GetListVisitorChart()
        {
            List<VisitorChart> visitorCharts= new List<VisitorChart>();
            using (var command=_context.Database.GetDbConnection().CreateCommand())
            {
                //CommandText->adonetteki gibi sorgu yazdığımız yapıdır
                command.CommandText = "select* from crosstab('select VisitDate,City,CityVisitCount from visitors order by 1,2') As ct(VisitDate date,City1 int,City2 int,City3 int,City4 int,City5 int);";
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
                            chart.VisitCounts.Add(reader.GetInt32(x));
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
//Her bir gün 5 saniyede tamamlanacak.
//Her günde 5 farklı şehre random değer gelecek
//Totalde 10 ardışık günün değeri tabloya eklenecek
//İşlemler toplam 50 saniye sürecek
//Her saniyede tablonun son hali gözükecek
//Toplamda 50 satır kayıt eklenmiş olacak.
//Bu işlemler postmanda gerçekleşecek...
