using Ardalis.Result;
using Examify.Identity.Entities;
using Examify.Identity.Interfaces;
using MediatR;

namespace Examify.Identity.Features.CreateUser;

public class CreateUserHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Result<AppUser>>
{
    public async Task<Result<AppUser>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        AppUser user = new AppUser { Email = request.Email, UserName = request.Email };
        await userRepository.CreateUserAsync(user, request.Password);
        return Result<AppUser>.Success(user);
    }
}