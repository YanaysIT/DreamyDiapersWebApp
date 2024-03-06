namespace DreamyDiapersWebApp.Core.Interfaces;

public interface IExchangeRateService
{ 
    Task<ExchangeRateContainer> GetExchangeRateAsync(Currency toCurrency, Currency fromCurrency = Currency.EUR);
    string[] GetCurrencyNames();
    string? GetCurrencyName(Currency currency);
}
