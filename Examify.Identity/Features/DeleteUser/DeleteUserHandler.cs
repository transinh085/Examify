using Ardalis.GuardClauses;
using Ardalis.Result;
using Examify.Identity.Interfaces;
using MediatR;

namespace Examify.Identity.Features.DeleteUser;

public class DeleteUserHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, Result>
{
    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, user);
        userRepository.DeleteAsync(user);
        return Result.NoContent();
    }
}