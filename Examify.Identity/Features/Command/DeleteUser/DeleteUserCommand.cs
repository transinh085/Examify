using MediatR;

namespace Examify.Identity.Features.DeleteUser;

public record DeleteUserCommand(string Id) : IRequest<IResult>;