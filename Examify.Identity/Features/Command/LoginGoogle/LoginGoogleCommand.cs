using FluentValidation;
using MediatR;

namespace Examify.Identity.Features.Command.LoginGoogle;

public record LoginGoogleCommand(string AccessToken) : IRequest<IResult>;

public class LoginFacebookValidator : AbstractValidator<LoginGoogleCommand>
{
    public LoginFacebookValidator()
    {
        RuleFor(x => x.AccessToken).NotEmpty();
    }
}