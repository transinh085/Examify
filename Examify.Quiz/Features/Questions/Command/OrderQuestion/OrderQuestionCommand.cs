using Examify.Quiz.Repositories.Questions;
using FluentValidation;
using MediatR;

namespace Examify.Quiz.Features.Questions.Command.OrderQuestion;

public record OrderQuestionCommand(Guid QuestionId, int Order) : IRequest<IResult>;

public class OrderQuestionValidator : AbstractValidator<OrderQuestionCommand>
{
    public OrderQuestionValidator(IQuestionRepository repository)
    {
        RuleFor(x => x.QuestionId)
            .NotEmpty().WithMessage("QuestionId is required");

        RuleFor(x => x.Order)
            .GreaterThanOrEqualTo(0).WithMessage("Order must be greater than or equal to 0");
    }
}