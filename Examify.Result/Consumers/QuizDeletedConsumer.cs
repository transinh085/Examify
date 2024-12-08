using Examify.Events;
using Examify.Result.Repositories.QuizResults;
using MassTransit;

namespace Examify.Result.Consumers;

public class QuizDeletedConsumer(IQuizResultRepository quizResultRepository) : IConsumer<QuizDeletedEvent>
{
    public async Task Consume(ConsumeContext<QuizDeletedEvent> context)
    {
        await quizResultRepository.DeleteAllResultsOfQuiz(context.Message.QuizId);
    }
}
