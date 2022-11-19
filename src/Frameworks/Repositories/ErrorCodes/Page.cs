using Hermes.Frameworks.Repositories.DataStructures;

namespace Hermes.Frameworks.Repositories.ErrorCodes;

public static class Page
{
    public static readonly string InvalidListCount = $"{typeof(Page<>).Name}:{nameof(InvalidListCount)}";
    public static readonly string InvalidPageIndex = $"{typeof(Page<>).Name}:{nameof(InvalidPageIndex)}";
    public static readonly string InvalidPageSize = $"{typeof(Page<>).Name}:{nameof(InvalidPageSize)}";
}