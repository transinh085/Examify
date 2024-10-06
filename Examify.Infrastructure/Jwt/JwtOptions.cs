using Examify.Infrastructure.Options;

namespace Examify.Infrastructure.Jwt;

public class JwtOptions : IOptionsRoot
{
    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int DurationInMinutes { get; set; }
    
    public int RefreshTokenDurationInDays { get; set; }
}