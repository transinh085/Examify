using Examify.Core.Pagination;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.SearchQuiz;

public record SearchQuizQuery : PagedRequest, IRequest<IResult>
{
    public string? Keyword { get; set; }

    public Guid? SubjectId { get; set; }

};