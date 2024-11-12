using MediatR;

namespace Examify.Identity.Features.Query.GetSelf;

public record GetSelfQuery(String username) : IRequest<IResult>;