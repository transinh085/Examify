using System.Security.Claims;
using Examify.Core.Endpoints;

namespace Examify.Identity.Features.GetSelf;

public class GetSelfEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/auth/self",
            async (ILogger<GetSelfEndpoint> logger, IHttpContextAccessor httpContextAccessor, ClaimsPrincipal user) =>
            {
                var ipAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
                logger.LogInformation("Ip address: {0}", ipAddress);
                logger.LogInformation("GetSelfEndpoint");
                logger.LogInformation("Current user: {0}", user.Identity.Name);
                return user.Identity.Name;
            })
            .WithTags("Authentication")
            .RequireAuthorization(); // yêu cầu login
    }
}