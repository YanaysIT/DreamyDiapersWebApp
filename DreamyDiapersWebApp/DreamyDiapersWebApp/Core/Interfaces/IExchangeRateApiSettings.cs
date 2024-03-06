namespace DreamyDiapersWebApp.Core.Interfaces;

public interface IExchangeRateApiSettings
{
    string ApiKey { get; set; }
    string ApiUrlBase { get; set; }
}
