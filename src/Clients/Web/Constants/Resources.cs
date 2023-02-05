namespace Hermes.Client.Web.Constants;

public static class Resources
{
    public static class Navigation
    {
        public const string OrdersLabel = $"{nameof(Navigation)}|{nameof(OrdersLabel)}";
        public const string PaymentsLabel = $"{nameof(Navigation)}|{nameof(PaymentsLabel)}";
    }

    public static class Login
    {
        public const string LoginButtonLabel = $"{nameof(Login)}|{nameof(LoginButtonLabel)}";
    }

    public static class Pagination
    {
        public const string PreviousButtonLabel = $"{nameof(Pagination)}|{nameof(PreviousButtonLabel)}";
        public const string NextButtonLabel = $"{nameof(Pagination)}|{nameof(NextButtonLabel)}";
    }

    public static class Catalog
    {
        public const string Title = $"{nameof(Catalog)}|{nameof(Title)}";
        public const string AddToBasketButtonLabel = $"{nameof(Catalog)}|{nameof(AddToBasketButtonLabel)}";
    }

    public static class Orders
    {
        public const string Title = $"{nameof(Orders)}|{nameof(Title)}";

        public const string ProductsColumnHeader = $"{nameof(Orders)}|{nameof(ProductsColumnHeader)}";
        public const string PriceColumnHeader = $"{nameof(Orders)}|{nameof(PriceColumnHeader)}";
        public const string DateColumnHeader = $"{nameof(Orders)}|{nameof(DateColumnHeader)}";
        public const string StatusColumnHeader = $"{nameof(Orders)}|{nameof(StatusColumnHeader)}";
    }

    public static class Payments
    {
        public const string Title = $"{nameof(Payments)}|{nameof(Title)}";

        public const string OrderColumnHeader = $"{nameof(Payments)}|{nameof(OrderColumnHeader)}";
        public const string PriceColumnHeader = $"{nameof(Payments)}|{nameof(PriceColumnHeader)}";
        public const string DateColumnHeader = $"{nameof(Payments)}|{nameof(DateColumnHeader)}";
        public const string StatusColumnHeader = $"{nameof(Payments)}|{nameof(StatusColumnHeader)}";
    }
}