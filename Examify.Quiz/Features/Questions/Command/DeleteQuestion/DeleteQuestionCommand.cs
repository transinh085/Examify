using Examify.Quiz.Repositories.Questions;
using FluentValidation;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.DeleteQuestion;

public record DeleteQuestionCommand(Guid Id) : IRequest<IResult>;

public class DeleteQuestionValidator : AbstractValidator<DeleteQuestionCommand>
{
    public DeleteQuestionValidator(IQuestionRepository repository)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .MustAsync(async (id, cancellationToken) => !(await repository.IsQuestionExists(id, cancellationToken)))
            .WithMessage("Question not found");
    }
}