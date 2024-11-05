using MediatR;

namespace Examify.Quiz.Features.Questions.Command.PatchQuestionAttributes;

public record PatchQuestionAttributesCommand(Guid Id, int? Duration, int? Points) : IRequest<IResult>;