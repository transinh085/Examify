using FluentValidation;
using MediatR;

namespace Examify.Identity.Features.Command.LoginGoogle;

public record LoginGoogleCommand(string clientId, string credential, string select_by) : IRequest<IResult>;

public class LoginGoogleValidator : AbstractValidator<LoginGoogleCommand>
{
    public LoginGoogleValidator()
    {
        RuleFor(x => x.clientId).NotEmpty();
        RuleFor(x => x.credential).NotEmpty();
        RuleFor(x => x.select_by).NotEmpty();
    }
}