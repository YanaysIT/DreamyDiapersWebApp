namespace DreamyDiapersWebApp.Core.Classes;

public class ExchangeRate
{
    [JsonPropertyName("exchange_rate")]
    public decimal Rate { get; set; }

    [JsonPropertyName("currency_pair")]
    public string CurrencyPair { get; set; } = string.Empty;
}
