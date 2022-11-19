using Hermes.Frameworks.Repositories.DataStructures;

namespace System.Collections.Generic;

public static class PaginationExtensions
{
    public static Page<T> ToPage<T>(this IEnumerable<T> collection, int pageIndex, int pageSize)
    {
        var totalCount = collection.Count();
        var pageCollection = collection.Skip(pageIndex * pageSize).Take(pageSize).ToList();

        return new Page<T>(pageCollection, totalCount, pageIndex, pageSize);
    }
}