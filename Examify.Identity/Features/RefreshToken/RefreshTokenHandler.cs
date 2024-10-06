using Examify.Identity.Features.Login;
using Examify.Identity.Infrastructure.Jwt;
using MediatR;

namespace Examify.Identity.Features.RefreshToken;

public class RefreshTokenHandler(ITokenProvider tokenProvider) : IRequestHandler<RefreshTokenCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var authenticatedResponse = await tokenProvider.RefreshTokenAsync(request.Token);
        return authenticatedResponse;
    }
}