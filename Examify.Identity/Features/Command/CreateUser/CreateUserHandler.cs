using AutoMapper;
using Examify.Identity.Dtos;
using Examify.Identity.Entities;
using Examify.Identity.Repositories;
using MediatR;

namespace Examify.Identity.Features.Command.CreateUser;

public class CreateUserHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<CreateUserCommand, IResult>
{
    public async Task<IResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new AppUser
        {
            FirstName = request.FirstName, 
            LastName = request.LastName, 
            Email = request.Email, 
            UserName = request.Email
        };
        await userRepository.CreateUserAsync(user, request.Password);
        return TypedResults.Ok(mapper.Map<AppUserDto>(user));
    }
}