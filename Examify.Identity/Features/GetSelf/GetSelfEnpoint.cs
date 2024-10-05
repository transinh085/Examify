using System.Security.Claims;
using Examify.Core.Endpoints;
using Examify.Identity.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OpenIddict.Abstractions;
using OpenIddict.Validation.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Hollastin.Server;

public class GetSelfEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/message", GetMessageHandler)
            .RequireAuthorization(new AuthorizeAttribute
            {
                AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme
            });
    }

    private static async Task<IResult> GetMessageHandler(
        ClaimsPrincipal user,
        UserManager<AppUser> userManager)
    {
        var applicationUser = await userManager.FindByIdAsync(user.GetClaim(Claims.Subject));
        if (applicationUser is null)
        {
            return Results.Challenge(
                authenticationSchemes: new[] { OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme },
                properties: new AuthenticationProperties(new Dictionary<string, string?>
                {
                    [OpenIddictValidationAspNetCoreConstants.Properties.Error] = Errors.InvalidToken,
                    [OpenIddictValidationAspNetCoreConstants.Properties.ErrorDescription] =
                        "The specified access token is bound to an account that no longer exists."
                }));
        }

        return Results.Text($"{applicationUser.UserName} has been successfully authenticated.");
    }
}