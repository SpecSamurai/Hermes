using Hermes.Client.Web.Configurations;
using Hermes.Client.Web.Models.Payments;
using Hermes.Client.Web.Responses;

namespace Hermes.Client.Web.Mappings;

static class PaymentsMappings
{
    public static PaymentsViewModel ToPaymentsViewModel(
        this PageResponse<PaymentGetResponse> response,
        PaginationViewConfiguration configuration) =>
            new()
            {
                Pagination = response.ToPaginationViewModel(configuration),
                Payments = response.Data.Select(ToPaymentViewModel)
            };

    public static PaymentViewModel ToPaymentViewModel(this PaymentGetResponse response) =>
        new()
        {
            Id = response.Id,
            OrderId = response.OrderId,
            Date = response.Date,
            Price = response.Price,
            Status = response.Status
        };
}