using Examify.Events;
using Examify.Result.Repositories;
using MassTransit;

namespace Examify.Result.Consumers;

public class QuizDeletedConsumer(ILogger<QuizDeletedConsumer> logger, IQuizResultRepository quizResultRepository) : IConsumer<QuizDeletedEvent>
{
    public Task Consume(ConsumeContext<QuizDeletedEvent> context)
    {
        logger.LogInformation("Quiz Deleted Event Consumed");
        quizResultRepository.DeleteAllResultsOfQuiz(context.Message.QuizId);
        return Task.CompletedTask;
    }
}
