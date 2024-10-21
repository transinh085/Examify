using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Examify.Core.Pagination;

public class PagedList<T>(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
{
    public IReadOnlyCollection<T> Items { get; } = items;

    public PageMeta Meta { get; set; } = new()
    {
        CurrentPage = pageNumber,
        PageSize = pageSize,
        TotalCount = count,
        TotalPages = (int)Math.Ceiling(count / (double)pageSize)
    };

    public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}

public class PageMeta
{
    [JsonPropertyName("current_page")] public int CurrentPage { get; set; }

    [JsonPropertyName("page_size")] public int PageSize { get; set; }

    [JsonPropertyName("total_pages")] public int TotalPages { get; set; }

    [JsonPropertyName("total_count")] public int TotalCount { get; set; }
}