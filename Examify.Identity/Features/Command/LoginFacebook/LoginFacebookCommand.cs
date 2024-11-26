using FluentValidation;
using MediatR;

namespace Examify.Identity.Features.Command.LoginFacebook;

public record LoginFacebookCommand(string AccessToken) : IRequest<IResult>;

public class LoginFacebookValidator : AbstractValidator<LoginFacebookCommand>
{
    public LoginFacebookValidator()
    {
        RuleFor(x => x.AccessToken).NotEmpty();
    }
}