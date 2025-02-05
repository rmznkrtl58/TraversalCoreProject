using Microsoft.AspNetCore.SignalR;
using SignalRApi.Models;
using System.Threading.Tasks;

namespace SignalRApi.Hubs
{
    public class VisitorHub:Hub//using.signalR
    {
        private readonly VisitorService _visitorService;

        public VisitorHub(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("GetVisitorList", "_visitorService.GetListVisitorChart()");
        }
    }
}
