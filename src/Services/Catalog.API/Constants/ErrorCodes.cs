using Hermes.Catalog.API.Entities;

namespace Hermes.Catalog.API.Constants;

internal static class ErrorCodes
{
    internal static class Items
    {
        public const string InvalidName = $"{nameof(Item)}:{nameof(InvalidName)}";
        public const string InvalidDescription = $"{nameof(Item)}:{nameof(InvalidDescription)}";
        public const string InvalidPictureFileName = $"{nameof(Item)}:{nameof(InvalidPictureFileName)}";
        public const string InvalidPictureUri = $"{nameof(Item)}:{nameof(InvalidPictureUri)}";
        public const string InvalidAvailableStock = $"{nameof(Item)}:{nameof(InvalidAvailableStock)}";
    }

    internal static class Brands
    {
        public const string InvalidName = $"{nameof(Brand)}:{nameof(InvalidName)}";
    }

    internal static class ItemTypes
    {
        public const string InvalidName = $"{nameof(ItemType)}:{nameof(InvalidName)}";
    }
}