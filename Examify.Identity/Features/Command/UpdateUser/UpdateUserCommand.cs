using Examify.Identity.Repositories;
using FluentValidation;
using MediatR;

namespace Examify.Identity.Features.Command.UpdateUser;

public record UpdateUserCommand(string Id,string FirstName,string LastName,string ImageUrl) :IRequest<IResult>;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    private readonly IUserRepository _userRepository;
    
    public UpdateUserValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.ImageUrl).NotEmpty();
    }
   
}