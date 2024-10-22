using AutoMapper;
using Examify.Identity.Dtos;
using Examify.Identity.Interfaces;
using MediatR;

namespace Examify.Identity.Features.GetUsers;

public class GetUsersHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<GetUsersQuery, IResult>
{
    public async Task<IResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetUsersAsync();
        return TypedResults.Ok(mapper.Map<IEnumerable<AppUserDto>>(users));
    }
}