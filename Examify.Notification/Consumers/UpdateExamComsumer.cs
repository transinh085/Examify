using AutoMapper;
using Examify.Events;
using Examify.Notification.Grpc.Clients;
using Examify.Notification.Hubs;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace Examify.Notification.Consumers
{
	public class UpdateExamComsumer(ILogger<UserJoinedExamConsumer> logger, IHubContext<NotificationHub> hubContext) : IConsumer<UpdateExamEvent>
	{
		public async Task Consume(ConsumeContext<UpdateExamEvent> context)
		{
			logger.LogInformation("StartExamComsumer received: {QuizId}", context.Message.ExamId);
			await hubContext.Clients.Group(context.Message.ExamId + "-admin").SendAsync("UpdateQuiz");
		}
	}
}
