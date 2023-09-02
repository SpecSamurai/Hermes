namespace Fintech.Serialization;

internal static class MoneySerializerOptionsExtensions
{
    internal static IMoneyConverter<T> GetConverter<T>(this MoneySerializerOptions options)
    {
        var converter = options
            .Converters
            .SingleOrDefault(converter => converter.CanConvert<T>()) as IMoneyConverter<T>;

        return converter ?? throw new NotSupportedException(
            $"There is no compatible {nameof(IMoneyConverter)} for type of {typeof(T)}.");
    }
}