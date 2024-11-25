using Examify.Identity.Entities;
using Examify.Identity.Infrastructure.Jwt;
using Examify.Identity.Repositories;
using Examify.Identity.Utilities;
using Google.Apis.Auth;
using MediatR;

namespace Examify.Identity.Features.Command.LoginGoogle;

public class LoginGoogleHandler(
    IConfiguration configuration,
    IUserRepository userRepository,
    ITokenProvider tokenProvider)
    : IRequestHandler<LoginGoogleCommand, IResult>
{
    public async Task<IResult> Handle(LoginGoogleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var payload = await ValidateGoogleToken(request.credential);
            if (payload == null)
            {
                return Results.BadRequest(new { message = "Invalid Google token" });
            }

            var email = payload.Email;
            if (string.IsNullOrEmpty(email))
            {
                return Results.BadRequest(new { message = "Email is required" });
            }

            var existingUser = await userRepository.GetByEmailAsync(email);
            
            if (existingUser == null)
            {
                var newUser = new AppUser
                {
                    Email = email,
                    FirstName = payload.GivenName ?? payload.Name,
                    LastName = payload.FamilyName ?? payload.Name,
                    Image = payload.Picture,
                    UserName = email,
                    EmailConfirmed = true
                };

                var password = PasswordGenerator.GenerateSecurePassword();
                await userRepository.CreateUserAsync(newUser, password);
                
                var tokenForNewUser = await tokenProvider.AuthenticateAsync(email);
                return Results.Ok(tokenForNewUser);
            }
            
            var token = await tokenProvider.AuthenticateAsync(email);
            return Results.Ok(token);
        }
        catch (InvalidJwtException)
        {
            return Results.BadRequest(new { message = "Invalid Google credential" });
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { message = ex.Message });
        }
    }

    private async Task<GoogleJsonWebSignature.Payload> ValidateGoogleToken(string credential)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new[] { configuration["Authentication:Google:ClientId"] }
        };

        return await GoogleJsonWebSignature.ValidateAsync(credential, settings);
    }
}