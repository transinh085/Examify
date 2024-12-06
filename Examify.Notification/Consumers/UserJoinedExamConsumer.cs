using AutoMapper;
using Examify.Events;
using Examify.Notification.Dtos;
using Examify.Notification.Grpc.Clients;
using Examify.Notification.Hubs;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace Examify.Notification.Consumers;

public class UserJoinedExamConsumer(ILogger<UserJoinedExamConsumer> logger, IHubContext<NotificationHub> hubContext, INotificationMetaService notificationMetaService, IMapper mapper) : IConsumer<UserJoinedExamEvent>
{
    public async Task Consume(ConsumeContext<UserJoinedExamEvent> context)
    {
        logger.LogInformation("UserJoinedExamConsumer received: {UserId} {QuizId}", context.Message.UserId, context.Message.ExamId);
		IdentityDto identityDto = await notificationMetaService.GetIdentityAsync(Guid.Parse(context.Message.UserId));
		UserDto userDto = mapper.Map<UserDto>(identityDto);
		await hubContext.Clients.Group(context.Message.ExamId + "-user").SendAsync("JoinQuiz", userDto);
		await hubContext.Clients.Group(context.Message.ExamId + "-admin").SendAsync("JoinQuiz", userDto);
    }
}