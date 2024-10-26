using MediatR;

namespace Examify.Catalog.Features.Languages.DeleteLanguage;

public record DeleteLanguageCommand(Guid Id): IRequest<IResult>;
