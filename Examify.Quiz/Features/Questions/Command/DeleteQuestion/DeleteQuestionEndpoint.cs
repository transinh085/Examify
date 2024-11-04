using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.DeleteQuestion;

public class DeleteQuestionEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("quizzes/{quizId}/questions/{id}", async (Guid quizId, Guid id, ISender sender) =>
            await sender.Send(new DeleteQuestionCommand(id))
        ).WithTags("Questions");
    }
}