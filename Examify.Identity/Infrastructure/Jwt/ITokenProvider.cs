using Examify.Identity.Dtos;
using Examify.Identity.Entities;
using Examify.Identity.Features.Login;

namespace Examify.Identity.Infrastructure.Jwt;

public interface ITokenProvider
{
    Task<AuthenticatedDto> AuthenticateAsync(string email, string password);
    Task<AuthenticatedDto> RefreshTokenAsync(string token);
}