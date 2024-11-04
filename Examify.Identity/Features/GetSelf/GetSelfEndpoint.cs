using System.Security.Claims;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Identity.Features.GetSelf;

public class GetSelfEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("auth/self",
                async (ILogger<GetSelfEndpoint> logger, IHttpContextAccessor httpContextAccessor, ClaimsPrincipal user, ISender sender) =>
                {
                    var ipAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
                    logger.LogInformation("Ip address: {0}", ipAddress);
                    logger.LogInformation("GetSelfEndpoint");

                    if (user.Identity?.Name == null)
                    {
                        logger.LogWarning("User is not authenticated or username is null.");
                        return Results.Unauthorized();
                    }

                    logger.LogInformation("Current user: {0}", user.Identity.Name);
                    return await sender.Send(new GetSelfQuery(user.Identity.Name));
                })
            .WithTags("Authentication")
            .RequireAuthorization();
    }
}