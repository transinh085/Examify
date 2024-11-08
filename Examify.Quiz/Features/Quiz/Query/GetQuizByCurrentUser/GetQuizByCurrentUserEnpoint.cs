using System.Security.Claims;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizByCurrentUser;

public class GetQuizByCurrentUserEnpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quizzes/current", async (ClaimsPrincipal user, ISender sender) =>
        {
            var userId = Guid.Parse(user.Identity.Name);
            return await sender.Send(new GetQuizByCurrentUserQuery(userId));
        }).RequireAuthorization();
    }
}