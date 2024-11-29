using System.Security.Claims;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizByCurrentUser;

public class GetQuizByCurrentUserEnpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/quizzes/current",
            async (ClaimsPrincipal user, ISender sender) =>
                await sender.Send(new GetQuizByCurrentUserQuery(user.Identity.Name))).RequireAuthorization();
    }
}