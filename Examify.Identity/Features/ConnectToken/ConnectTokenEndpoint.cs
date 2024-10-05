using System.Collections.Immutable;
using System.Security.Claims;
using Examify.Core.Endpoints;
using Examify.Identity.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Examify.Identity.Features.ConnectToken;

public class ConnectTokenEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/connect/token", HandleTokenExchange)
            .AllowAnonymous()
            .Produces<IResult>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
    }

    private static async Task<IResult> HandleTokenExchange(
        HttpContext httpContext,
        SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager)
    {
        var request = httpContext.GetOpenIddictServerRequest();
        if (request?.IsPasswordGrantType() != true)
        {
            return Results.Problem("The specified grant type is not implemented.", statusCode: 501);
        }

        var user = await userManager.FindByNameAsync(request.Username);
        if (user == null)
        {
            return CreateForbidResult("The username/password couple is invalid.");
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);
        if (!result.Succeeded)
        {
            return CreateForbidResult("The username/password couple is invalid.");
        }

        var identity = await CreateIdentityAsync(user, userManager, request);

        return Results.SignIn(new ClaimsPrincipal(identity), authenticationScheme: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }

    private static IResult CreateForbidResult(string errorDescription)
    {
        var properties = new AuthenticationProperties(new Dictionary<string, string?>
        {
            [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidGrant,
            [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = errorDescription
        });

        return Results.Forbid(properties, new[] { OpenIddictServerAspNetCoreDefaults.AuthenticationScheme });
    }

    private static async Task<ClaimsIdentity> CreateIdentityAsync(AppUser user, UserManager<AppUser> userManager, OpenIddictRequest request)
    {
        var identity = new ClaimsIdentity(
            authenticationType: TokenValidationParameters.DefaultAuthenticationType,
            nameType: Claims.Name,
            roleType: Claims.Role);

        identity.SetClaim(Claims.Subject, await userManager.GetUserIdAsync(user))
                .SetClaim(Claims.Email, await userManager.GetEmailAsync(user))
                .SetClaim(Claims.Name, await userManager.GetUserNameAsync(user))
                .SetClaim(Claims.PreferredUsername, await userManager.GetUserNameAsync(user))
                .SetClaims(Claims.Role, (await userManager.GetRolesAsync(user)).ToImmutableArray());

        identity.SetScopes(new[]
        {
            Scopes.OpenId,
            Scopes.Email,
            Scopes.Profile,
            Scopes.Roles
        }.Intersect(request.GetScopes()));

        identity.SetDestinations(GetDestinations);

        return identity;
    }

    private static IEnumerable<string> GetDestinations(Claim claim)
    {
        return claim.Type switch
        {
            Claims.Name or Claims.PreferredUsername =>
                new[] { Destinations.AccessToken }
                .Concat(claim.Subject.HasScope(Scopes.Profile) ? new[] { Destinations.IdentityToken } : Array.Empty<string>()),

            Claims.Email =>
                new[] { Destinations.AccessToken }
                .Concat(claim.Subject.HasScope(Scopes.Email) ? new[] { Destinations.IdentityToken } : Array.Empty<string>()),

            Claims.Role =>
                new[] { Destinations.AccessToken }
                .Concat(claim.Subject.HasScope(Scopes.Roles) ? new[] { Destinations.IdentityToken } : Array.Empty<string>()),

            "AspNet.Identity.SecurityStamp" => Array.Empty<string>(),

            _ => new[] { Destinations.AccessToken }
        };
    }


}