using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.BulkUpdateQuestion;

public class BulkUpdateQuestionEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("quizzes/{quizId}/questions/bulk", async (Guid quizId, BulkUpdateQuestionCommand command, ISender sender) =>
            await sender.Send(command with { QuizId = quizId })
        ).WithTags("Questions");
    }
}