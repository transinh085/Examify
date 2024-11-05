using System.ComponentModel;
using Examify.Core.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Examify.Catalog.Features.Subject.Query.GetAllSubject;

// Query (thực hiện thao tác đọc) R
// Command (thực hiện thao tác cập nhật dữ liệu) CUD

public record GetAllSubjectQuery : IRequest<IResult>, IPageRequest
{
    [DefaultValue(1)]
    [FromQuery(Name = "pageNumber")]
    public int PageNumber { get; set; } = 1;
    
    [DefaultValue(30)]
    [FromQuery(Name = "pageSize")]
    public int PageSize { get; set; } = 30;
}