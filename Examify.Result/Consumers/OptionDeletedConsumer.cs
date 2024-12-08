using Examify.Events;
using Examify.Result.Repositories.AnswerResults;
using MassTransit;

namespace Examify.Result.Consumers;

public class OptionDeletedConsumer(IAnswerResultRepository answerResultRepository) : IConsumer<OptionDeletedEvent>
{
    public async Task Consume(ConsumeContext<OptionDeletedEvent> context)
    {
        await answerResultRepository.DeleteByOptionIds(context.Message.OptionIds);
    }
}
