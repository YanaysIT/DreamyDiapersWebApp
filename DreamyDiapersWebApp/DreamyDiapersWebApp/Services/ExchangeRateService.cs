namespace DreamyDiapersWebApp.Services;

public class ExchangeRateService(IHttpClientFactory  httpClientFactory,IExchangeRateApiSettings apiSettings,
    ExchangeRateContainer exchangeRateContainer) 
                                : IExchangeRateService
{
    readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    readonly IExchangeRateApiSettings _apiSettings = apiSettings;
    readonly ExchangeRateContainer _exchangeRateContainer = exchangeRateContainer;

    public async Task<ExchangeRateContainer> GetExchangeRateAsync(Currency toCurrency, Currency fromCurrency = Currency.EUR)
    {
        string ApiUrlBase = _apiSettings.ApiUrlBase;

        string apiUrl = $"{ApiUrlBase}{GetCurrencyName(fromCurrency)}_{GetCurrencyName(toCurrency)}";
        
        using var _httpClient = _httpClientFactory.CreateClient();

        _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiSettings.ApiKey);

        try
        {
            var response = await _httpClient.GetFromJsonAsync<ExchangeRate>(apiUrl);

            _exchangeRateContainer.Rate = response is null ? 1 : response.Rate;
            _exchangeRateContainer.FromCurrency = response is null ? Currency.EUR : GetCurrency(response.CurrencyPair.Split('_')[0]);
            _exchangeRateContainer.ToCurrency = response is null ? Currency.EUR : GetCurrency(response.CurrencyPair.Split('_')[1]);

            return _exchangeRateContainer;
        }
        catch
        {
            _exchangeRateContainer.Rate = 1;
            _exchangeRateContainer.FromCurrency = Currency.EUR ;
            _exchangeRateContainer.ToCurrency = Currency.EUR;
            return _exchangeRateContainer;
        }
    }

    public string[] GetCurrencyNames() => Enum.GetNames<Currency>();
    public string? GetCurrencyName(Currency currency) => Enum.GetName(currency);
    public Currency GetCurrency(string name) => Enum.Parse<Currency>(name);
}

