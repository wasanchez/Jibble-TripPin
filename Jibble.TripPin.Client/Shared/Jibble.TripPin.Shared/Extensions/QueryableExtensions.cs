namespace Jibble.TripPin.Shared;

public static class QueryableExtensions
{
    /// <summary>
    /// Returns paginated list
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    /// <param name="query"></param>
    /// <param name="pageNumber">The page number</param>
    /// <param name="pageSize">The page size</param>
    /// <returns>An instance of PaginatedResult </returns>
    public static Task<PaginatedResult<T>> ToListAsync<T> (this IQueryable<T> query, int pageNumber = 1, int pageSize = 10) where T : class 
    {
        return Task.Run(() => 
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 10 : pageSize;
            var count = query.Count();
            query = query.Skip((pageNumber -1) * pageSize).Take(pageSize);        
            return PaginatedResult<T>.Create(query.ToList(), count, pageNumber, pageSize);
        });
    }

}
