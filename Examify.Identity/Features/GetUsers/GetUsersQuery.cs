using Examify.Identity.Entities;
using MediatR;

namespace Examify.Identity.Features.GetUsers;

public record GetUsersQuery : IRequest<IEnumerable<AppUser>>
{
    
}