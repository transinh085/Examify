using AutoMapper;
using Examify.Identity.Dtos;
using Examify.Identity.Entities;
using Examify.Identity.Interfaces;
using MediatR;

namespace Examify.Identity.Features.Register;

public class RegisterHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<RegisterCommand, IResult>
{
    public async Task<IResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
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