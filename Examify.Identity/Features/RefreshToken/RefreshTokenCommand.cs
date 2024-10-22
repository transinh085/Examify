using Examify.Identity.Features.Login;
using FluentValidation;
using MediatR;

namespace Examify.Identity.Features.RefreshToken;

public record RefreshTokenCommand(string Token) : IRequest<IResult>;

public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenValidator()
    {
        RuleFor(x => x.Token).NotEmpty();
    }
}