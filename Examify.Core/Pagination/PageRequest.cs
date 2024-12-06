using FluentValidation;

namespace Examify.Core.Pagination;


public abstract record PagedRequest
{
    public int? PageNumber { get; init; } = 1;
    public int? PageSize { get; init; } = 8;

    public int GetPageNumber => PageNumber ?? 1;
    public int GetPageSize => PageSize ?? 8;
}

public class PagedRequestValidator<T> : AbstractValidator<T> where T : PagedRequest
{
    public PagedRequestValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .When(x => x.PageNumber.HasValue);

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .LessThanOrEqualTo(100)
            .When(x => x.PageSize.HasValue);
    }
}