using Examify.Core.Pagination;
using FluentValidation;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizBySubject;

public record GetQuizBySubjectQuery : IRequest<IResult>, IPageRequest
{
    public Guid SubjectId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 8;
}

public class GetQuizBySubjectValidator : AbstractValidator<GetQuizBySubjectQuery>
{
    public GetQuizBySubjectValidator()
    {
        RuleFor(x => x.SubjectId).NotEmpty();
        RuleFor(x => x.PageNumber).NotNull().GreaterThan(0);
        RuleFor(x => x.PageSize).NotNull().GreaterThan(0);
    }
}