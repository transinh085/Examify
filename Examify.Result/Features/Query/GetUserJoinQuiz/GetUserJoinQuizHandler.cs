using Examify.Result.Repositories;
using MediatR;
using Result;
namespace Examify.Result.Features.Query.GetUserJoinQuiz;

public class GetUserJoinQuizHandler(
    IJoinQuizRepository joinQuizRepository,
	QuizGrpcService.QuizGrpcServiceClient quizClient
) : IRequestHandler<GetUserJoinQuizQuery, IResult>
{
    public async Task<IResult> Handle(GetUserJoinQuizQuery request, CancellationToken cancellationToken)
    {
        var list = await joinQuizRepository.GetUserJoinQuiz(request.Code);
		var populatedQuiz = quizClient.GetQuiz(new QuizRequest
		{
			Id = "",
			Code = request.Code
		});
		if(populatedQuiz == null)
		{
			return Results.NotFound("Quiz not found");
		}
		return Results.Ok(new
        {
            items = list,
			quizId = populatedQuiz.Id
		});
    }
}