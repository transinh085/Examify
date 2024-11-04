using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.CreateQuestion;

public class CreateQuestionEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/quizzes/{quizId}/questions", async (Guid quizId, CreateQuestionCommand command, ISender sender) =>
            await sender.Send(command with
            {
                QuizId = quizId
            })
        ).WithTags("Questions");
    }
}