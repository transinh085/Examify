using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizByCurrentUser;

public class GetQuizByCurrentUserHandler(IQuizRepository quizRepository) : IRequestHandler<GetQuizByCurrentUserQuery, IResult>
{
    public async Task<IResult> Handle(GetQuizByCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        var quizzes = await quizRepository.GetQuizByUserId(userId, cancellationToken);
        return TypedResults.Ok(quizzes);
    }
}