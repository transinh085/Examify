using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetAllQuiz;

public class GetAllQuizHandler(IQuizRepository quizRepository) : IRequestHandler<GetAllQuizQuery, IResult>
{
    public async Task<IResult> Handle(GetAllQuizQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await quizRepository.GetAllQuizzes(cancellationToken);
        return TypedResults.Ok(quizzes);
    }
}