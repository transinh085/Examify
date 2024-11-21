using FluentValidation;
using MediatR;

namespace Examify.Result.Features.Command.UpdateQuestionResult;

public record UpdateQuestionResultCommand : IRequest<IResult>
{
    public Guid QuestionResultId { get; init; }
    public List<string> Answers { get; init; }
    
    public int TimeTaken { get; init; }
    
    public int TimeSpent { get; init; }
    
}

public class CreateQuizResultValidator : AbstractValidator<UpdateQuestionResultCommand>
{
    public CreateQuizResultValidator()
    {
        RuleFor(x => x.Answers)
            .NotEmpty().WithMessage("Answers is required");

        RuleFor(x => x.TimeTaken)
            .GreaterThan(0).WithMessage("TimeTaken must be greater than 0");

        RuleFor(x => x.TimeSpent)
            .GreaterThan(0).WithMessage("TimeSpent must be greater than 0");
    }
}
