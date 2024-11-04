using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.DuplicateQuestion;

public class DuplicateQuestionEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("quizzes/{quizId}/questions/{id}/duplicate",
            async (Guid quizId, Guid id, ISender sender) =>
                await sender.Send(new DuplicateQuestionCommand(id))
        ).WithTags("Questions");
    }
}