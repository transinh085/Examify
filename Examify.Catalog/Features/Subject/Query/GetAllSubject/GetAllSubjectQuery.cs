using MediatR;

namespace Examify.Catalog.Features.Subject.Query.GetAllSubject;

// Query (thực hiện thao tác đọc) R
// Command (thực hiện thao tác cập nhật dữ liệu) CUD

public record GetAllSubjectQuery : IRequest<IResult>;