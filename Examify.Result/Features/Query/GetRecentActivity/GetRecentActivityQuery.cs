using Examify.Core.Pagination;
using MediatR;

namespace Examify.Result.Features.Query.GetRecentActivity;

public record GetRecentActivityQuery : PagedRequest, IRequest<IResult>
{
    public string? UserId { get; init; }
    public string? Status { get; init; } = "all";
}
