using FluentValidation;
using MediatR;

namespace Examify.Identity.Features.Login;

public record LoginCommand(string Email, string Password) : IRequest<AuthenticationResponse>;

public class AuthenticationResponse
{
    public string Token { get; set; }
    public int ExpiresIn { get; set; }
    public string RefreshToken { get; set; }
};

public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}