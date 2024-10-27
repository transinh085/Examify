using System.ComponentModel;
using Examify.Core.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Examify.Catalog.Features.Grades.GetGrades;

public record GetGradesQuery : IRequest<IResult>, IPageRequest
{
    [DefaultValue(1)]
    [FromQuery(Name = "pageNumber")]
    public int PageNumber { get; set; } = 1;
    
    [DefaultValue(10)]
    [FromQuery(Name = "pageSize")]
    public int PageSize { get; set; } = 10;
}