using FluentValidation;
using MediatR;

namespace Examify.Result.Features.Command.CreateQuizResult;

public record JoinQuizCommand : IRequest<IResult>
{
    public string Code { get; init; }
    
    public string UserId { get; init; }
    
}

public class CreateQuizResultValidator : AbstractValidator<JoinQuizCommand>
{
    public CreateQuizResultValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required");
    }
}
