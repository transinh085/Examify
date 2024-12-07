using Examify.Events;
using Examify.Notification.Hubs;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace Examify.Notification.Consumers
{
	public class EndExamComsumer(ILogger<EndExamComsumer> logger, IHubContext<NotificationHub> hubContext) : IConsumer<EndExamEvent>
	{
		public async Task Consume(ConsumeContext<EndExamEvent> context)
		{
			logger.LogInformation("EndExamComsumer received: {QuizId}", context.Message.ExamId);
			await hubContext.Clients.Group(context.Message.ExamId + "-user").SendAsync("EndQuiz");
		}
	}
}
