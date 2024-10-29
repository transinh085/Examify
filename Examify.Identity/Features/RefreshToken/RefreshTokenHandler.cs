using Examify.Identity.Features.Login;
using Examify.Identity.Infrastructure.Jwt;
using MediatR;

namespace Examify.Identity.Features.RefreshToken;

public class RefreshTokenHandler(ITokenProvider tokenProvider) : IRequestHandler<RefreshTokenCommand, IResult>
{
    public async Task<IResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var authenticatedResponse = await tokenProvider.RefreshTokenAsync(request.Token);
        return TypedResults.Ok(authenticatedResponse);
    }
}