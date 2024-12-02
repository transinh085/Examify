using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.StartQuiz;

public class StartQuizHandler(IQuizRepository quizRepository) : IRequestHandler<StartQuizCommand, IResult>
{
    public async Task<IResult> Handle(StartQuizCommand request, CancellationToken cancellationToken)
    {
        await quizRepository.StartQuiz(request.QuizId, cancellationToken);
        return TypedResults.Ok();
    }
}