using Hermes.Client.Web.Configurations;
using Hermes.Client.Web.Models.Orders;
using Hermes.Client.Web.Responses;

namespace Hermes.Client.Web.Mappings;

static class OrdersMappings
{
    public static OrdersViewModel ToOrdersViewModel(
        this PageResponse<OrderGetResponse> response,
        PaginationViewConfiguration configuration) =>
            new()
            {
                Pagination = response.ToPaginationViewModel(configuration),
                Orders = response.Data.Select(ToOrderViewModel),
            };

    public static OrderViewModel ToOrderViewModel(this OrderGetResponse response) =>
        new()
        {
            Id = response.Id,
            Date = response.Date,
            Price = response.Price,
            Status = response.Status,
            Products = response.Products.Select(ToOrderedProductViewModel)
        };

    public static OrderedProductViewModel ToOrderedProductViewModel(OrderedProductGetResponse response) =>
        new()
        {
            Name = response.Name
        };
}