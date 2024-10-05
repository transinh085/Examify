using Examify.Identity.Entities;
using Examify.Identity.Interfaces;
using MediatR;

namespace Examify.Identity.Features.GetUsers;

public class GetUsersHandler(IUserRepository userRepository) : IRequestHandler<GetUsersQuery, IEnumerable<AppUser>>
{
    public Task<IEnumerable<AppUser>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return userRepository.GetUsersAsync();
    }
}