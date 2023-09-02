namespace Fintech.Serialization;

public static class MoneySerializer
{
    public static Money? Serialize<T>(T value, MoneySerializerOptions? moneySerializerOptions = default)
    {
        moneySerializerOptions ??= MoneySerializerOptions.Default;
        var converter = moneySerializerOptions.GetConverter<T>();
        return converter.Write(value, moneySerializerOptions);
    }

    public static T Deserialize<T>(Money value, MoneySerializerOptions? moneySerializerOptions = default)
    {
        moneySerializerOptions ??= MoneySerializerOptions.Default;
        var converter = moneySerializerOptions.GetConverter<T>();
        return converter.Read(value, moneySerializerOptions);
    }
}