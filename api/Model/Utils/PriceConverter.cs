namespace api.Model.Utils;

public class PriceConverter
{
    private static readonly Lazy<PriceConverter> _instance = new Lazy<PriceConverter>(() => new PriceConverter());
    public static PriceConverter Instance => _instance.Value;
    
    private PriceConverter() {}
    
    public decimal ConvertToDecimal(long price)
    {
        decimal centsInDecimal = (decimal) price;
        return centsInDecimal / 100;
    }

    public long ConvertToLong(decimal price)
    {
        decimal cents = price * 100;
        return (long) cents;
    }
}