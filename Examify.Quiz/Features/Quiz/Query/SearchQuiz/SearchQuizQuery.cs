using Examify.Core.Pagination;
using FluentValidation;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.SearchQuiz;

public record SearchQuizQuery() : IRequest<IResult>, IPageRequest
{
    public string? Keyword { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 12;
};

public class SearchQuizValidator : AbstractValidator<SearchQuizQuery>
{
    public SearchQuizValidator()
    {
        RuleFor(x => x.Keyword).NotEmpty();
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}