using Ardalis.GuardClauses;
using Ardalis.Result;
using Examify.Identity.Infrastructure.Jwt;
using Examify.Identity.Interfaces;
using MediatR;

namespace Examify.Identity.Features.Login;

public class LoginCommandHandler(IUserRepository userRepository, ITokenProvider tokenProvider) : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var valid = await userRepository.VerifyLoginAsync(request.Email, request.Password);
        if (!valid)
        {
            throw new UnauthorizedAccessException();
        }

        var user = await userRepository.GetByEmailAsync(request.Email);
        return new LoginResponse
        {
            Token = tokenProvider.CreateToken(user),
            ExpiresIn = 3600,
            RefreshToken = "refresh_token"
        };
    }
}