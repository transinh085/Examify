using MediatR;

namespace Examify.Identity.Features.GetSelf;

public record GetSelfQuery(String username) : IRequest<IResult>;