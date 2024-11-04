using Examify.Quiz.Infrastructure.Data;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.PatchQuestionAttributes;

public class PatchQuestionAttributesHandler(QuizContext context)
    : IRequestHandler<PatchQuestionAttributesCommand, IResult>
{
    public async Task<IResult> Handle(PatchQuestionAttributesCommand request, CancellationToken cancellationToken)
    {
        var question = await context.Questions
            .FindAsync(request.Id, cancellationToken);


        if (question == null) return TypedResults.NotFound();

        if (request.Duration.HasValue)
        {
            question.Duration = request.Duration.Value;
        }

        if (request.Points.HasValue)
        {
            question.Points = request.Points.Value;
        }

        await context.SaveChangesAsync(cancellationToken);
        return TypedResults.NoContent();
    }
}