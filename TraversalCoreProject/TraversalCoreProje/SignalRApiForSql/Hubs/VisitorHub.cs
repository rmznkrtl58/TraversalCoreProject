using Microsoft.AspNetCore.SignalR;
using SignalRApiForSql.Models;
using System.Threading.Tasks;

namespace SignalRApiForSql.Hubs
{
    public class VisitorHub:Hub
    {
        private readonly VisitorService _visitorService;

        public VisitorHub(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        public async Task GetVisitorList()
        {                             //1.p->grafikleri getireceğimiz Indexte Invoke içerisinde
                                      //çağırıyoruz
            await Clients.All.SendAsync("ReceiveVisitorList", _visitorService.GetListVisitorChart());
        }
    }
}
