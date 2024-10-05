using Ardalis.Result;
using Examify.Identity.Entities;
using Examify.Identity.Interfaces;
using FluentValidation;
using MediatR;

namespace Examify.Identity.Features.CreateUser;

public record CreateUserCommand(string Email, string Password) : IRequest<Result<AppUser>>;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    public CreateUserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MustAsync(BeUniqueEmail)
            .WithMessage("Email already exists.");
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
    
    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        return await _userRepository.IsEmailUniqueAsync(email);
    }
}