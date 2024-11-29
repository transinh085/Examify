using Microsoft.AspNetCore.SignalR;

namespace Examify.Notification.Hubs;

public class ResultHub : Hub<IResultHub>
{
     public async Task SendMessage(string message)
    {
        await Clients.All.SendMessage(message);
    }
}