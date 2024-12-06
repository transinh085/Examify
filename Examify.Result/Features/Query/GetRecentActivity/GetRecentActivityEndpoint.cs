using Examify.Core.Endpoints;
using MediatR;
using System.Security.Claims;

namespace Examify.Result.Features.Query.GetRecentActivity;

public class GetRecentActivityEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("recent-activity", async ([AsParameters] GetRecentActivityQuery query, ClaimsPrincipal user, ISender sender) =>
            await sender.Send(query with { UserId = user.Identity.Name }
        )).RequireAuthorization();
    }
}