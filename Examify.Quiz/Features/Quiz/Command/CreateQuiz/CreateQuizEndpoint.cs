using System.Security.Claims;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.CreateQuiz;

public class CreateQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/quizzes", async (ClaimsPrincipal user, ISender sender) => await sender.Send(new CreateQuizCommand(user.Identity.Name)))
            .Produces<Entities.Quiz>()
            .WithTags("Quiz")
            .RequireAuthorization();
    }
}