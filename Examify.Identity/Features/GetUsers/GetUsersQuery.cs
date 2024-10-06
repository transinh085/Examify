using Examify.Identity.Dtos;
using MediatR;

namespace Examify.Identity.Features.GetUsers;

public record GetUsersQuery : IRequest<IEnumerable<AppUserDto>>;