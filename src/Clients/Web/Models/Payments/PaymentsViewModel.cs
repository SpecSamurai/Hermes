using Hermes.Client.Web.Models.Shared;

namespace Hermes.Client.Web.Models.Payments;

class PaymentsViewModel
{
    public required PaginationViewModel Pagination { get; init; }
    public required IEnumerable<PaymentViewModel> Payments { get; init; }
}