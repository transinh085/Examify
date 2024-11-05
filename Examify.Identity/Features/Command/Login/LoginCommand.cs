using FluentValidation;
using MediatR;

namespace Examify.Identity.Features.Login;

public record LoginCommand(string Email, string Password) : IRequest<IResult>;


public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}