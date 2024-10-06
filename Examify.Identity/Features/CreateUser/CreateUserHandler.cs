using AutoMapper;
using Examify.Identity.Dtos;
using Examify.Identity.Entities;
using Examify.Identity.Interfaces;
using MediatR;

namespace Examify.Identity.Features.CreateUser;

public class CreateUserHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<CreateUserCommand, AppUserDto>
{
    public async Task<AppUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        AppUser user = new AppUser
        {
            FirstName = request.FirstName, 
            LastName = request.LastName, 
            Email = request.Email, 
            UserName = request.Email
        };
        await userRepository.CreateUserAsync(user, request.Password);
        return mapper.Map<AppUserDto>(user);
    }
}