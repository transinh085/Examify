using Examify.Core.Pagination;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizByCurrentUser;

public record GetQuizByCurrentUserQuery : PagedRequest, IRequest<IResult>
{
    public string? UserId { get; set; }

    public bool IsPublished { get; set; }

};