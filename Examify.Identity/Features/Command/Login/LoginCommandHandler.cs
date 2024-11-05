using Examify.Identity.Infrastructure.Jwt;
using Examify.Identity.Interfaces;
using MediatR;

namespace Examify.Identity.Features.Login;

public class LoginCommandHandler(IUserRepository userRepository, ITokenProvider tokenProvider)
    : IRequestHandler<LoginCommand, IResult>
{
    public async Task<IResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var authenticatedResponse = await tokenProvider.AuthenticateAsync(request.Email, request.Password);
        return TypedResults.Ok(authenticatedResponse);
    }
}