using MediatR;

namespace Examify.Identity.Features.GetSelf;

public record GetSeftQuery(String username) : IRequest<IResult>;