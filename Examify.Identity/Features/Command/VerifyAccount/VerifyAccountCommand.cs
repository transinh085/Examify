using Examify.Identity.Repositories;
using FluentValidation;
using MediatR;

namespace Examify.Identity.Features.Command.VerifyAccount;

public record VerifyAccountCommand(string Token) : IRequest<IResult>;

public class VerifyAccountValidator : AbstractValidator<VerifyAccountCommand>
{
    private readonly IUserRepository _userRepository;
    public VerifyAccountValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        RuleFor(x => x.Token)
            .NotEmpty();
    }
}