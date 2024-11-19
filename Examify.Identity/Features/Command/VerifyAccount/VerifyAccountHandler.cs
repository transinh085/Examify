using AutoMapper;
using Examify.Events;
using Examify.Identity.Dtos;
using Examify.Identity.Repositories;
using MassTransit;
using MediatR;

namespace Examify.Identity.Features.Command.VerifyAccount;

public class VerifyAccountHandler(
    IUserRepository userRepository, 
    IUserVerificationRepository userVerificationRepository, 
    IMapper mapper) : IRequestHandler<VerifyAccountCommand, IResult>
{
    public async Task<IResult> Handle(VerifyAccountCommand request, CancellationToken cancellationToken)
    {
        // Find verification token and ensure it exists
        var userVerification = await userVerificationRepository.FindByToken(request.Token);
    
        if (userVerification == null || userVerification.Expires < DateTime.UtcNow)
        {
            return TypedResults.NotFound("Verification token is invalid or expired.");
        }

        // Find the user and ensure they exist
        var user = await userRepository.GetByIdAsync(userVerification.AppUserId);
    
        if (user == null)
        {
            return TypedResults.NotFound("User associated with this token was not found.");
        }
    
        // Verify user
        user.EmailConfirmed = true;
        await userRepository.UpdateUserAsync(user);
    
        // Delete verification token
        await userVerificationRepository.Delete(userVerification);
    
        return TypedResults.Ok(new VerifyAccountDto
        {
            Email = user.Email,
            Message = "Account verified successfully."
        });
    }
}