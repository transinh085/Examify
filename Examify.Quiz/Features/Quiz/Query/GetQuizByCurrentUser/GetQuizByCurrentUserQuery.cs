using System.Security.Claims;
using Examify.Core.Endpoints;
using MediatR;

namespace Examify.Quiz.Features.Quiz.Query.GetQuizByCurrentUser;

public record GetQuizByCurrentUserQuery(Guid UserId): IRequest<IResult>;