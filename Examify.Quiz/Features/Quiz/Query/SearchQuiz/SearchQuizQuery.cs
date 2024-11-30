using Examify.Core.Pagination;
using FluentValidation;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.SearchQuiz;

public record SearchQuizQuery : PageRequest, IRequest<IResult>
{
    public string? Keyword { get; set; }

    public Guid? SubjectId { get; set; }

};