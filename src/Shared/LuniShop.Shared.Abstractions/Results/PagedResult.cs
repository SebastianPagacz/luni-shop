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
    /// <summary>
    /// Create returns a PagedResult with a generic IList, using IQueryable as an entry value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values">IQueryable<T> parameter used to determine collection</param>
    /// <param name="pageSize">Size of a single page</param>
    /// <param name="currentPage">Number of current page starting from 1</param>
    /// <param name="totalCount">Count of all results</param>
    /// <returns></returns>
    public static PagedResult<T> Create<T>(IList<T> values, int pageSize, int currentPage, int totalCount)
    {
        if (pageSize < 0 || currentPage <= 0 || totalCount < 0)
            return new PagedResult<T>(new List<T>(), 0, 0, 0); // For now empty result if data is invalid

        return new PagedResult<T>(values, pageSize, currentPage, totalCount);
    }
}
