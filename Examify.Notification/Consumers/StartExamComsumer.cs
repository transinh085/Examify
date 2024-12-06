using AutoMapper;
using Examify.Events;
using Examify.Notification.Grpc.Clients;
using Examify.Notification.Hubs;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace Examify.Notification.Consumers
{
	public class StartExamComsumer(ILogger<UserJoinedExamConsumer> logger, IHubContext<NotificationHub> hubContext, INotificationMetaService notificationMetaService, IMapper mapper) : IConsumer<StartExamEvent>
	{
		public async Task Consume(ConsumeContext<StartExamEvent> context)
		{
			logger.LogInformation("StartExamComsumer received: {QuizId}", context.Message.ExamId);
			await hubContext.Clients.Group(context.Message.ExamId + "-user").SendAsync("StartQuiz");
		}
	}
}
