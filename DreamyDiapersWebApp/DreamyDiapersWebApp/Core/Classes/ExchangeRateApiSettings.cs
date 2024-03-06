namespace DreamyDiapersWebApp.Core.Classes;

public class ExchangeRateApiSettings : IExchangeRateApiSettings
{
    public string ApiKey { get; set; } = string.Empty;
    public string ApiUrlBase { get; set; } = string.Empty;
}
