using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.DeleteQuiz;

public class DeleteQuizHandler(IQuizRepository quizRepository) : IRequestHandler<DeleteQuizCommand, IResult>
{
    public async Task<IResult> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
    {
        await quizRepository.DeleteQuizById(request.QuizId, cancellationToken);
        return TypedResults.NoContent();
    }
}