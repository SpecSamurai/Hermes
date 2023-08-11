using Hermes.Client.Web.Models.Account;

namespace Hermes.Client.Web.Services;

internal class AccountService : IAccountService
{
    public Account GetAccount()
    {
        return new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "email@domain.com",
            Roles = new[] { "Admin", "Developer" }
        };
    }
}