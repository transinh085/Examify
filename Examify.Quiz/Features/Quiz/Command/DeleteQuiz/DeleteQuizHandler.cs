using Examify.Events;
using Examify.Quiz.Repositories.Quiz;
using MassTransit;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.DeleteQuiz;

public class DeleteQuizHandler(IQuizRepository quizRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<DeleteQuizCommand, IResult>
{
    public async Task<IResult> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
    {
        await quizRepository.DeleteQuizById(request.QuizId, cancellationToken);

        await publishEndpoint.Publish<QuizDeletedEvent>(new
        {
            request.QuizId,
            DeletedAt = DateTime.UtcNow
        }, cancellationToken);

        return TypedResults.NoContent();
    }
}