namespace Hermes.Client.Web.Services.Models.Admin;

public class GetBrandsServiceModel
{
    public required IEnumerable<GetBrandServiceModel> Brands { get; init; }
}