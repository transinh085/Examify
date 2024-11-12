using Examify.Identity.Repositories;
using FluentValidation;
using MediatR;

namespace Examify.Identity.Features.Command.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : IRequest<IResult>;

public class CreateUserValidator : AbstractValidator<RegisterCommand>
{
    private readonly IUserRepository _userRepository;
    public CreateUserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        RuleFor(x => x.FirstName)
            .NotEmpty();
        RuleFor(x => x.LastName)
            .NotEmpty();
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MustAsync(BeUniqueEmail)
            .WithMessage("Email already exists.");
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6);
    }
    
    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        return await _userRepository.IsEmailUniqueAsync(email);
    }
}