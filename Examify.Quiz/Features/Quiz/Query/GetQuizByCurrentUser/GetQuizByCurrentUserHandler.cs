using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizByCurrentUser;

public class GetQuizByCurrentUserHandler(IQuizRepository quizRepository)
    : IRequestHandler<GetQuizByCurrentUserQuery, IResult>
{
    public async Task<IResult> Handle(GetQuizByCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var quizzes = await quizRepository.GetQuizByUserId(request.UserId, request.IsPublished,
            request.GetPageNumber,
            request.GetPageSize, cancellationToken);
        return TypedResults.Ok(quizzes);
    }
}