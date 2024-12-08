using Examify.Result.Repositories.QuizResults;
using MediatR;
namespace Examify.Result.Features.Query.GetStartQuiz;

public class GetUserStartQuizHandler(
	IQuizResultRepository quizResultRepository
) : IRequestHandler<GetStartQuizQuery, IResult>
{
    public async Task<IResult> Handle(GetStartQuizQuery request, CancellationToken cancellationToken)
    {
        var list = await quizResultRepository.GetStartQuiz(request.Code);
		return TypedResults.Ok(list);
    }
}