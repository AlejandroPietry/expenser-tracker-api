using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ExpenserTracker.Presentation.Hubs
{
    public class NotifyHub : Hub
    {
        public async Task SendNotify(string mensagemNotificacao)
        {
            await Clients.All.SendAsync("receiveNotify", mensagemNotificacao);
        }
    }
}
