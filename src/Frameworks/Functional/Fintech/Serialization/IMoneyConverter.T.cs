namespace Fintech.Serialization;

public interface IMoneyConverter<T> : IMoneyConverter
{
    T Read(Money value, MoneySerializerOptions moneySerializerOptions);
    Money? Write(T value, MoneySerializerOptions moneySerializerOptions);
}