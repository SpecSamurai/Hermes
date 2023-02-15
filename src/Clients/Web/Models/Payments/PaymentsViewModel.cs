using Hermes.Client.Web.Models.Shared;

namespace Hermes.Client.Web.Models.Payments;

internal class PaymentsViewModel
{
    public required PaginationViewModel Pagination { get; init; }
    public required IEnumerable<PaymentViewModel> Payments { get; init; }
}