using Ardalis.GuardClauses;
using Examify.Identity.Repositories;
using MediatR;

namespace Examify.Identity.Features.Command.DeleteUser;

public class DeleteUserHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, IResult>
{
    public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, user);
        await userRepository.DeleteAsync(user);
        return Results.NoContent();
    }
}