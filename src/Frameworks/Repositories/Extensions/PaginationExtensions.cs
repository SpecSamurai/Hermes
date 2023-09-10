using Hermes.Frameworks.Repositories.DataStructures;

namespace System.Collections.Generic;

public static class PaginationExtensions
{
    public static Page<T> ToPage<T>(this IEnumerable<T> collection, int totalCount, int pageIndex, int pageSize)
    {
        var pageCollection = collection.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        return new Page<T>(pageCollection, totalCount, pageIndex, pageSize);
    }

    public static Page<T> ToPage<T>(this IEnumerable<T> collection, int totalCount, Offset offset)
    {
        var pageIndex = offset.Skip / offset.Take;
        return collection.ToPage(totalCount, pageIndex, offset.Take);
    }
}