using Examify.Quiz.Infrastructure.Data;
using Examify.Quiz.Repositories.Questions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examify.Quiz.Features.Questions.Command.DuplicateQuestion;

public record DuplicateQuestionCommand(Guid Id) : IRequest<IResult>;

public class DuplicateQuestionValidator : AbstractValidator<DuplicateQuestionCommand>
{
    public DuplicateQuestionValidator(IQuestionRepository repository)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .MustAsync(async (id, cancellationToken) => await repository.IsQuestionExists(id, cancellationToken))
            .WithMessage("Question not found");
    }
}