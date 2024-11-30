using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.EndQuiz;

public class EndQuizHandler(IQuizRepository quizRepository) : IRequestHandler<EndQuizCommand, IResult>
{
    public async Task<IResult> Handle(EndQuizCommand request, CancellationToken cancellationToken)
    {
        await quizRepository.EndQuiz(request.QuizId, cancellationToken);
        return TypedResults.Ok();
    }
}