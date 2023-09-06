namespace Hermes.Client.Web.Services.Models.Admin;

public class GetItemTypesServiceModel
{
    public required IEnumerable<GetItemTypeServiceModel> ItemTypes { get; init; }
}