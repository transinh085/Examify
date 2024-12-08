using MediatR;

namespace Examify.Result.Features.Command.DeleteQuizResult;

public record DeleteQuizResultCommand(Guid Id) : IRequest<IResult>;