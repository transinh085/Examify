using Examify.Core.Endpoints;
using MediatR;
using System.Security.Claims;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizByCurrentUser;

public class GetQuizByCurrentUserEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quizzes/current",
                async (ClaimsPrincipal user, ISender sender, [AsParameters] GetQuizByCurrentUserQuery query) =>
                await sender.Send(query with { UserId = user.Identity.Name }))
            .RequireAuthorization();
    }
}