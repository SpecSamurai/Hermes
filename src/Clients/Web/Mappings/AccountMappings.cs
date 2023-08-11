using Hermes.Client.Web.Models.Account;

namespace Hermes.Client.Web.Mappings;

internal static class AccountMappings
{
    public static AccountViewModel ToAccountViewModel(this Account account) =>
        new()
        {
            FirstName = account.FirstName,
            LastName = account.LastName,
            Email = account.Email,
            Roles = account.Roles,
        };
}