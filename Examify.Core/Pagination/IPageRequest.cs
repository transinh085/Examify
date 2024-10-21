namespace Examify.Core.Pagination;

public interface IPageRequest
{
    int PageNumber { get; set; }
    int PageSize { get; set; }
}