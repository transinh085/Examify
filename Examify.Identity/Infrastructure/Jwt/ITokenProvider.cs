using Examify.Identity.Entities;

namespace Examify.Identity.Infrastructure.Jwt;

public interface ITokenProvider
{
    string CreateToken(AppUser user);
}