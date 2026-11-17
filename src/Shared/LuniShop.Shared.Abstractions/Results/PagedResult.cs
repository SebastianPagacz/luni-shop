namespace LuniShop.Shared.Abstractions.Results;

public sealed record PagedResult<T>
{
    public IList<T> Values { get; init; } = new List<T>();
    public int PageSize { get; init; }
    public int CurrentPage { get; init; }
    public int TotalCount { get; init; }
    public bool HasNextPage => CurrentPage * PageSize < TotalCount;
    public bool HasPreviousPage => CurrentPage > 1;

    internal PagedResult(IList<T> values, int pageSize, int currentPage, int totalCount)
    {
        Values = values;
        PageSize = pageSize;
        CurrentPage = currentPage;
        TotalCount = totalCount;
    }
}

public static class PagedResultFactory
{
    public static PagedResult<T> Create<T>(IQueryable<T> values, int pageSize, int currentPage, int totalCount)
    {
        if (pageSize < 0 || currentPage <= 0 || totalCount < 0)
            return new PagedResult<T>(new List<T>(), 0, 0, 0); // For now empty result if data is invalid

        var materializedValue = values.Skip((currentPage - 1) * pageSize).Take(currentPage * pageSize).ToList();

        return new PagedResult<T>(materializedValue, pageSize, currentPage, totalCount);
    }
}
