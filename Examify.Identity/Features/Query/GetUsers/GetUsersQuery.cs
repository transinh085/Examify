using Examify.Identity.Dtos;
using MediatR;

namespace Examify.Identity.Features.Query.GetUsers;

public record GetUsersQuery : IRequest<IResult>;