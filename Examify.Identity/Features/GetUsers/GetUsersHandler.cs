using AutoMapper;
using Examify.Identity.Dtos;
using Examify.Identity.Interfaces;
using MediatR;

namespace Examify.Identity.Features.GetUsers;

public class GetUsersHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<GetUsersQuery, IEnumerable<AppUserDto>>
{
    public async Task<IEnumerable<AppUserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetUsersAsync();
        return mapper.Map<IEnumerable<AppUserDto>>(users);
    }
}