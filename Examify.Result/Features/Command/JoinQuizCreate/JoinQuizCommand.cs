using FluentValidation;
using MediatR;

namespace Examify.Result.Features.Command.JoinQuizCreate;

public record JoinQuizCommand(string Code, string UserId) : IRequest<IResult>;

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
