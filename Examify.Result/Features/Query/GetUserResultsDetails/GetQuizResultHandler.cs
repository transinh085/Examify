using Examify.Quiz.Dtos;
using Examify.Result.Repositories;
using MediatR;
using Result;

namespace Examify.Result.Features.Query.GetUsersResultsDetails;

public class GetUsersResultsDetailsHandler(
    IQuizResultRepository quizResultRepository
) : IRequestHandler<GetUsersResultsDetailsQuery, IResult>
{
    public async Task<IResult> Handle(GetUsersResultsDetailsQuery request, CancellationToken cancellationToken)
    {
        var quizResults = await quizResultRepository.GetQuizResultsByQuizAndUser(request.quizId, request.userId);
        return TypedResults.Ok(quizResults);
    }
}