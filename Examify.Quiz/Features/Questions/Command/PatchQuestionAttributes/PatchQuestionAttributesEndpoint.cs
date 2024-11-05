using Examify.Core.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Examify.Quiz.Features.Questions.Command.PatchQuestionAttributes;

public class PatchQuestionAttributesEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("quizzes/{quizId}/questions/{id}/attributes",
                async (Guid id, ISender sender, PatchQuestionAttributesCommand command) =>
                    await sender.Send(command with { Id = id })
            ).Produces<NoContent>()
            .WithTags("Questions");
    }
}