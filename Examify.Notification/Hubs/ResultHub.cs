using System.Security.Claims;
using Examify.Notification.Dtos;
using Examify.Notification.Grpc.Clients;
using Microsoft.AspNetCore.SignalR;

namespace Examify.Notification.Hubs;

public class ResultHub(INotificationMetaService notificationMetaService) : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("SendMessage", message);
    }

    public async Task JoinQuiz(String quizId, String userId)
    {
        IdentityDto identityDto = await notificationMetaService.GetIdentityAsync(Guid.Parse(userId));
        await Groups.AddToGroupAsync(Context.ConnectionId, quizId);
        await Clients.Group(quizId.ToString()).SendAsync("JoinQuiz", identityDto);
    }
}