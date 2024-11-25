using AutoMapper;
using Examify.Identity.Dtos;
using Examify.Identity.Repositories;
using MediatR;
using Ardalis.GuardClauses;


namespace Examify.Identity.Features.Command.UpdateUserImage;

public class UpdateUserImageHandler(IUserRepository userRepository,IMapper mapper) : IRequestHandler<UpdateUserImageCommand,IResult>
{
    public async Task<IResult> Handle(UpdateUserImageCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, user);
        user.Image = request.ImageUrl;
        await userRepository.UpdateUserAsync(user);
        return TypedResults.Ok(mapper.Map<AppUserDto>(user));
    }
}