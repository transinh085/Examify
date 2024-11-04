using Examify.Quiz.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Questions.Command.BulkUpdateQuestion;

public class BulkUpdateQuestionHandler(QuizContext context) : IRequestHandler<BulkUpdateQuestionCommand, IResult>
{
    public async Task<IResult> Handle(BulkUpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var questions = await context.Questions.Where(x => x.QuizId == request.QuizId).
            ToListAsync(cancellationToken);
        
        questions.ForEach(x =>
        {
            x.Duration = request.Duration ?? x.Duration;
            x.Points = request.Points ?? x.Points;
        });
        
        await context.SaveChangesAsync(cancellationToken);

        return TypedResults.NoContent();
    }
}