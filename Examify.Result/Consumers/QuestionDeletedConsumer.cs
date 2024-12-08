using Examify.Events;
using Examify.Result.Repositories.QuestionResults;
using MassTransit;

namespace Examify.Result.Consumers;

public class QuestionDeletedConsumer(IQuestionResultRepository questionResultRepository, ILogger<QuestionDeletedConsumer> logger) : IConsumer<QuestionDeletedEvent>
{
    public async Task Consume(ConsumeContext<QuestionDeletedEvent> context)
    {
        logger.LogInformation("QuestionDeletedConsumer: Deleting question results for question {QuestionId}", context.Message.QuestionId);
        await questionResultRepository.DeleteByQuestionId(context.Message.QuestionId);
    }
}
