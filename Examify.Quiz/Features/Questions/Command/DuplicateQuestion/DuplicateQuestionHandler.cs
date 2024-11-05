using Examify.Quiz.Entities;
using Examify.Quiz.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Questions.Command.DuplicateQuestion;

public class DuplicateQuestionHandler(QuizContext context) : IRequestHandler<DuplicateQuestionCommand, IResult>
{
    public async Task<IResult> Handle(DuplicateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await context.Questions.Include(x => x.Options)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (question is null)
        {
            return TypedResults.NotFound();
        }

        var newQuestion = new Question
        {
            QuizId = question.QuizId,
            Content = question.Content,
            Duration = question.Duration,
            Points = question.Points,
            Type = question.Type,
            Options = question.Options.Select(x => new Option
            {
                Content = x.Content,
                IsCorrect = x.IsCorrect
            }).ToList(),
        };

        await context.Questions.AddAsync(newQuestion, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return TypedResults.Created();
    }
}