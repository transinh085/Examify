using System.Security.Claims;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Identity.Features.GetSelf;

public class GetSelfEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("auth/self",
                async (ClaimsPrincipal user, ISender sender) =>
                {
                    if (user.Identity?.Name == null)
                    {
                        return Results.Unauthorized();
                    }
                    return await sender.Send(new GetSelfQuery(user.Identity.Name));
                })
            .WithTags("Authentication")
            .RequireAuthorization();
    }
}