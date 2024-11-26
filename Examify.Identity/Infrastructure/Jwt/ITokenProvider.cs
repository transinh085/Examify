using Examify.Identity.Dtos;
using Examify.Identity.Entities;

namespace Examify.Identity.Infrastructure.Jwt;

public interface ITokenProvider
{
    Task<AuthenticatedDto> AuthenticateAsync(string email, string password);
    Task<AuthenticatedDto> AuthenticateAsync(AppUser user);
    Task<AuthenticatedDto> RefreshTokenAsync(string token);
}