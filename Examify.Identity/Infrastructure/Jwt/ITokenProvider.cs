using Examify.Identity.Entities;
using Examify.Identity.Features.Login;

namespace Examify.Identity.Infrastructure.Jwt;

public interface ITokenProvider
{
    Task<AuthenticationResponse> AuthenticateAsync(string email, string password);
    Task<AuthenticationResponse> RefreshTokenAsync(string token);
}