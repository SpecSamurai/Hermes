namespace Hermes.Client.Web.Services.Models.Admin;

public class GetItemsServiceModel
{
    public required IEnumerable<GetItemServiceModel> Items { get; init; }
}