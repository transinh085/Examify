using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.PlayQuiz;

public class PlayQuizHandler(IQuizRepository quizRepository) : IRequestHandler<PlayQuizCommand, IResult>
{
    public async Task<IResult> Handle(PlayQuizCommand request, CancellationToken cancellationToken)
    {
        await quizRepository.PlayQuiz(request.QuizId, cancellationToken);
        return TypedResults.Ok();
    }
}