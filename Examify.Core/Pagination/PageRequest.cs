using FluentValidation;

namespace Examify.Core.Pagination;

public record PageRequest
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}

public class PageRequestValidator : AbstractValidator<PageRequest>
{
    public PageRequestValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}