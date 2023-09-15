using System.ComponentModel.DataAnnotations;

namespace Hermes.Catalog.API.Requests;

public class PageRequest
{
    [Range(0, int.MaxValue, ErrorMessage = $"{nameof(Index)} can't be negative.")]
    public int Index { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = $"{nameof(Size)} can't be smaller than 1.")]
    public int Size { get; set; }

    public string? Sorting { get; set; }
}