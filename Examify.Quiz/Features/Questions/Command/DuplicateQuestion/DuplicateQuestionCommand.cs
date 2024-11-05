using Examify.Quiz.Infrastructure.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Questions.Command.DuplicateQuestion;

public record DuplicateQuestionCommand(Guid Id) : IRequest<IResult>;

public class DuplicateQuestionValidator : AbstractValidator<DuplicateQuestionCommand>
{
    public DuplicateQuestionValidator(QuizContext context)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .MustAsync(async (id, cancellationToken) =>
            {
                return await context.Questions.AnyAsync(x => x.Id == id, cancellationToken);
            }).WithMessage("Question not found");
    }
}