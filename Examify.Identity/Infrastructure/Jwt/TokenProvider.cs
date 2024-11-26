using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Examify.Identity.Dtos;
using Examify.Identity.Entities;
using Examify.Identity.Features.Login;
using Examify.Identity.Infrastructure.Data;
using Examify.Infrastructure.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Examify.Identity.Infrastructure.Jwt;

public class TokenProvider(UserManager<AppUser> userManager, IdentityContext context, IOptions<JwtOptions> jwtOptions)
    : ITokenProvider
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public async Task<AuthenticatedDto> AuthenticateAsync(string email, string password)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user.EmailConfirmed == false)
        {
            throw new UnauthorizedAccessException("This account has not been verified.");
        }
        if (user == null || !await userManager.CheckPasswordAsync(user, password))
            throw new UnauthorizedAccessException();

        var accessToken = CreateToken(user);
        var refreshToken = GenerateRefreshToken(user);

        await context.RefreshTokens.AddAsync(refreshToken);
        await context.SaveChangesAsync();

        return new AuthenticatedDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Image = user.Image,
            Token = accessToken,
            RefreshToken = refreshToken.Token,
            ExpiresIn = _jwtOptions.DurationInMinutes * 60
        };
    }
    
    public async Task<AuthenticatedDto> AuthenticateAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null )
            throw new UnauthorizedAccessException();

    public async Task<AuthenticatedDto> AuthenticateAsync(AppUser user)
    {
        var accessToken = CreateToken(user);
        var refreshToken = GenerateRefreshToken(user);

        await context.RefreshTokens.AddAsync(refreshToken);
        await context.SaveChangesAsync();

        return new AuthenticatedDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Image = user.Image,
            Token = accessToken,
            RefreshToken = refreshToken.Token,
            ExpiresIn = _jwtOptions.DurationInMinutes * 60
        };
    }
    public string CreateToken(AppUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
            }),
            Audience = _jwtOptions.Audience,
            Issuer = _jwtOptions.Issuer,
            Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.DurationInMinutes),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<AuthenticatedDto> RefreshTokenAsync(string token)
    {
        var user = await context.Users.Include(u => u.RefreshTokens)
            .SingleOrDefaultAsync(u => u.RefreshTokens
                .Any(t => t.Token == token && t.Expires > DateTime.UtcNow && t.Revoked == null));

        if (user == null) throw new UnauthorizedAccessException();

        var refreshToken = user.RefreshTokens.Single(t => t.Token == token);
        refreshToken.Revoked = DateTime.UtcNow;

        var newRefreshToken = GenerateRefreshToken(user);
        user.RefreshTokens.Add(newRefreshToken);

        await context.SaveChangesAsync();

        return new AuthenticatedDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Token = CreateToken(user),
            RefreshToken = newRefreshToken.Token,
            ExpiresIn = _jwtOptions.DurationInMinutes * 60
        };
    }

    private RefreshToken GenerateRefreshToken(AppUser user)
    {
        return new RefreshToken
        {
            Token = RandomTokenString(),
            Expires = DateTime.UtcNow.AddDays(_jwtOptions.RefreshTokenDurationInDays),
            Created = DateTime.UtcNow,
            AppUserId = user.Id
        };
    }

    private string RandomTokenString()
    {
        using var rng = RandomNumberGenerator.Create();
        var randomBytes = new byte[40];
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }
}