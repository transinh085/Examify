using Examify.Quiz.Dtos;
using Examify.Result.Repositories;
using MediatR;
using Result;

namespace Examify.Result.Features.Query.GetResultsOfQuiz;

public class GetResultsOfQuizHandler(
    IQuizResultRepository quizResultRepository,
    QuizGrpcService.QuizGrpcServiceClient quizClient
) : IRequestHandler<GetResultsOfQuizQuery, IResult>
{
    public async Task<IResult> Handle(GetResultsOfQuizQuery request, CancellationToken cancellationToken)
    {
        var quizResults = await quizResultRepository.GetResultsOfQuiz(request.quizId);
        return TypedResults.Ok(quizResults);
    }
}