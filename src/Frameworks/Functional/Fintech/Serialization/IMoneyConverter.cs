namespace Fintech.Serialization;

public interface IMoneyConverter
{
    bool CanConvert<T>();
}