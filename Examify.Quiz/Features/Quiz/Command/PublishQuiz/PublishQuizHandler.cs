using Examify.Quiz.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Quiz.Command.PublishQuiz;

public class PublishQuizHandler(QuizContext context) : IRequestHandler<PublishQuizCommand, IResult>
{
    public async Task<IResult> Handle(PublishQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = await context.Quizzes.FirstOrDefaultAsync(x => x.Id == request.QuizId, cancellationToken);
        quiz.IsPublished = true;
        await context.SaveChangesAsync(cancellationToken);
        return TypedResults.NoContent();
    }
}