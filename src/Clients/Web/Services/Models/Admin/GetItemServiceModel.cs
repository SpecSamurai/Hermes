namespace Hermes.Client.Web.Services.Models.Admin;

public class GetItemServiceModel
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}