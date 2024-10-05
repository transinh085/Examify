using Examify.Infrastructure.Options;

namespace Examify.Identity.Infrastructure.Jwt;

public class JwtSettings : IOptionsRoot
{
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int DurationInMinutes { get; set; }
}