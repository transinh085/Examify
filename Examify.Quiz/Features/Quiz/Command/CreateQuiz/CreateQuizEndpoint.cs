using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Command.CreateQuiz;

public class CreateQuizEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/quizzes", async (ISender sender) => await sender.Send(new CreateQuizCommand()))
            .Produces<Entities.Quiz>()
            .WithTags("Quiz");
    }
}