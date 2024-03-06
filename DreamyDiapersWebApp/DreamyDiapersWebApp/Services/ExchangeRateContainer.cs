namespace DreamyDiapersWebApp.Services;

public class ExchangeRateContainer
{
    public Currency FromCurrency { get; set; } = Currency.EUR;
    public Currency ToCurrency { get; set; } = Currency.EUR;
    public decimal Rate { get; set; } = 1;  
}
