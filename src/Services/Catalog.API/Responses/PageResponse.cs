namespace Hermes.Catalog.API.Responses;

public class PageResponse<TModel>
{
    public PageResponse(int index, int size, long count, IEnumerable<TModel> data)
    {
        Index = index;
        Size = size;
        Count = count;
        Data = data;
    }

    public int Index { get; }
    public int Size { get; }
    public long Count { get; }
    public IEnumerable<TModel> Data { get; }
}