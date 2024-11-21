using Ardalis.GuardClauses;
using AutoMapper;
using Examify.Identity.Dtos;
using Examify.Identity.Infrastructure.Jwt;
using Examify.Identity.Repositories;
using MediatR;

namespace Examify.Identity.Features.Command.UpdateUser;

public class UpdateUserHandler(IUserRepository userRepository,IMapper mapper): IRequestHandler<UpdateUserCommand, IResult>
{
    public async Task<IResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, user);
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        await userRepository.UpdateUserAsync(user);
        return TypedResults.Ok(mapper.Map<AppUserDto>(user));
    }
}