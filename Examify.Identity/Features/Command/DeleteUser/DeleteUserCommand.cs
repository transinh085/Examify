using MediatR;

namespace Examify.Identity.Features.Command.DeleteUser;

public record DeleteUserCommand(string Id) : IRequest<IResult>;