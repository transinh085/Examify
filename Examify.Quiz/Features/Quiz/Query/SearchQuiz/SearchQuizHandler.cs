using Examify.Quiz.Repositories.Quiz;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.SearchQuiz;

public class SearchQuizHandler(IQuizRepository repository) : IRequestHandler<SearchQuizQuery, IResult>
{
    public async Task<IResult> Handle(SearchQuizQuery request, CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await repository.SearchQuizzes(request.Keyword, request.SubjectId,
            request.PageNumber.Value,
            request.PageSize.Value,
            cancellationToken));
    }
}