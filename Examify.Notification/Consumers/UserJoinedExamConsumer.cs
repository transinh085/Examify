using Examify.Events;
using MassTransit;

namespace Examify.Notification.Consumers;

public class UserJoinedExamConsumer(ILogger<UserJoinedExamConsumer> logger) : IConsumer<UserJoinedExamEvent>
{
    public Task Consume(ConsumeContext<UserJoinedExamEvent> context)
    {
        logger.LogInformation("UserJoinedExamConsumer received: {UserId}", context.Message.UserId);
        return Task.CompletedTask;
    }
}