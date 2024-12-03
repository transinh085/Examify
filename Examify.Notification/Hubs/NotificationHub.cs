using Examify.Notification.Dtos;
using Examify.Notification.Grpc.Clients;
using Microsoft.AspNetCore.SignalR;

namespace Examify.Notification.Hubs;

public class NotificationHub(INotificationMetaService notificationMetaService) : Hub
{
    public async Task JoinQuizAdmin(String quizId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, quizId+"-admin");
    }
    
    public async Task JoinQuizUser(String quizId, String userId)
    {
        IdentityDto identityDto = await notificationMetaService.GetIdentityAsync(Guid.Parse(userId));
        await Groups.AddToGroupAsync(Context.ConnectionId, quizId+"-user");
        await Clients.Group(quizId+"-user").SendAsync("JoinQuiz", identityDto);
        await Clients.Group(quizId+"-admin").SendAsync("JoinQuiz", identityDto);
    }
    
}