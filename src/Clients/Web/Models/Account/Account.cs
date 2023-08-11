namespace Hermes.Client.Web.Models.Account;

public class Account
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required IEnumerable<string> Roles { get; init; }
}