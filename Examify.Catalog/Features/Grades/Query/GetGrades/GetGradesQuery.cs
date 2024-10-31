using System.ComponentModel;
using Examify.Core.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Examify.Catalog.Features.Grades.Query.GetGrades;

public record GetGradesQuery : IRequest<IResult>;