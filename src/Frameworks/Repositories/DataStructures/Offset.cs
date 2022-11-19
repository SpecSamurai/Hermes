namespace Hermes.Frameworks.Repositories.DataStructures;

public record Offset
{
    public required int Skip { get; init; }
    public required int Take { get; init; }

    public static Offset Of(int pageIndex, int pageSize) =>
        new()
        {
            Skip = pageIndex * pageSize,
            Take = pageSize
        };
}