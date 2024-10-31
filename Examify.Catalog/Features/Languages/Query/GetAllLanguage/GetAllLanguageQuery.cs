using Examify.Core.Pagination;
using MediatR;

namespace Examify.Catalog.Features.Languages.GetAllLanguage;

public record GetAllLanguageQuery : IRequest<IResult>;