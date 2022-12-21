namespace Hermes.Client.Web.Models;

internal class PaymentsViewModel
{
    public required IEnumerable<PaymentViewModel> Payments { get; init; }
}