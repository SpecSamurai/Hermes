using Hermes.Frameworks.Repositories.DataStructures;

namespace System.Collections.Generic;

public static class PaginationExtensions
{
    public static Page<T> ToPage<T>(this IEnumerable<T> collection, int totalCount, Offset offset)
    {
        var pageIndex = offset.Skip / offset.Take;
        return new Page<T>(collection.ToList(), totalCount, pageIndex, offset.Take);
    }
}