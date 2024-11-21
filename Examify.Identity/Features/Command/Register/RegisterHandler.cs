using AutoMapper;
using Examify.Events;
using Examify.Identity.Dtos;
using Examify.Identity.Entities;
using Examify.Identity.Repositories;
using MassTransit;
using MediatR;

namespace Examify.Identity.Features.Command.Register;

public class RegisterHandler(
    IUserRepository userRepository, 
    IUserVerificationRepository userVerificationRepository, 
    IPublishEndpoint publishEndpoint,
    IMapper mapper,
    IConfiguration configuration) : IRequestHandler<RegisterCommand, IResult>
{
    public async Task<IResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // create user
        var user = new AppUser
        {
            FirstName = request.FirstName, 
            LastName = request.LastName, 
            Email = request.Email, 
            UserName = request.Email,
            Image = "" 
        };
        await userRepository.CreateUserAsync(user, request.Password);
        
        // generate verification token
        var userVerification = new UserVerification
        {
            AppUserId = user.Id,
            Token = Guid.NewGuid().ToString(),
            Expires = DateTime.UtcNow.AddMinutes(15)
        };
        await userVerificationRepository.Create(userVerification);
        
        // send mail
        publishEndpoint.Publish<UserVerificationEmailEvent>(new
        {
            Email = user.Email,
            VerificationLink = $"{configuration["ApplicationSettings:FrontendUrl"]}/auth/verify-account/{userVerification.Token}"
        });
        
        return TypedResults.Ok(mapper.Map<AppUserDto>(user));
    }
}