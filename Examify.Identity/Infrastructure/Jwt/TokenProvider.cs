using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Examify.Identity.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Examify.Identity.Infrastructure.Jwt;

public class TokenProvider : ITokenProvider
{
    private readonly JwtSettings jwtSettings;
    
    public TokenProvider(JwtSettings jwtSettings)
    {
        this.jwtSettings = jwtSettings;
    }
    
    public string CreateToken(AppUser user)
    {
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserName)
            }),
            Audience = jwtSettings.Audience,
            Issuer = jwtSettings.Issuer,
            Expires = DateTime.UtcNow.AddMinutes(jwtSettings.DurationInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}