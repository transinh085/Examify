using Examify.Identity.Infrastructure.Jwt;
using Examify.Identity.Repositories;
using MediatR;

namespace Examify.Identity.Features.Command.UpdatePassword;

public class UpdatePasswordHandler(IUserRepository userRepository,ITokenProvider tokenProvider): IRequestHandler<UpdatePasswordCommand, IResult>
{
    public async Task<IResult> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        var userToUpdate = await userRepository.GetByEmailAsync(request.email);
        var user = await userRepository.UpdatePasswordAsync(userToUpdate,request.OldPassword, request.NewPassword);
        return TypedResults.Ok(user);
    }
}