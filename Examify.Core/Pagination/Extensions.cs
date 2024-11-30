using Microsoft.EntityFrameworkCore;

namespace Examify.Core.Pagination;

public static class Extensions
{
    public static Task<PagedList<TDestination>> PaginatedListAsync<TDestination>(
        this IQueryable<TDestination> queryable, int pageNumber = 1, int pageSize = 8) where TDestination : class
        => PagedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);
}