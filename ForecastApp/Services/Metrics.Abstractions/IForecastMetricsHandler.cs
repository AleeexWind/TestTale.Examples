namespace ForecastApp.Services.Metrics.Abstractions
{
    public interface IForecastMetricsHandler
    {
        void IncreaseSuccessfulProvidedForecast();
        void IncreaseNullProvidedForecast();
        void IncreaseFailedProvidedForecast();
    }
}
