using ForecastApp.Controllers;
using ForecastApp.Domain;
using ForecastApp.Services.Abstractions;
using ForecastApp.Services.Metrics.Abstractions;
using ForecastApp.Services.Repositories.Abstractions;

namespace ForecastApp.Services.Implementations
{
    public class ForecastProvider : IForecastProvider
    {
        private readonly IWeatherForecastRepository _forecastRepository;
        private readonly ILogger<ForecastProvider> _logger;
        private readonly IForecastMetricsHandler _forecastMetricsHandler;
        public ForecastProvider(
            IWeatherForecastRepository forecastRepository,
            ILogger<ForecastProvider> logger,
            IForecastMetricsHandler forecastMetricsHandler)
        {
            _forecastRepository = forecastRepository;
            _logger = logger;
            _forecastMetricsHandler = forecastMetricsHandler;
        }
        public async Task<WeatherForecast?> ProvideForecastAsync(int regionIndex, DateRequest date, TimeOfDay timeOfDay)
        {
            WeatherForecast? weatherForecast = null;
            try
            {
                weatherForecast = await _forecastRepository.GetWeatherForecast(regionIndex, date, timeOfDay);
                if (weatherForecast is null)
                {
                    _logger.LogError("Requested weather forecast returned as null from {0} in method: {1} with parameters: regionIndex: {2}, dateRequest: {3}, timeOfDay: {4}",
                        nameof(IWeatherForecastRepository),
                        nameof(ProvideForecastAsync),
                        regionIndex,
                        date,
                        timeOfDay);
                    _forecastMetricsHandler.IncreaseNullProvidedForecast();
                }
                else
                {
                    _forecastMetricsHandler.IncreaseSuccessfulProvidedForecast();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception in method: {0} with parameters: regionIndex: {1}, dateRequest: {2}, timeOfDay: {3}",
                    nameof(ProvideForecastAsync),
                    regionIndex,
                    date,
                    timeOfDay);
                _forecastMetricsHandler.IncreaseFailedProvidedForecast();
            }
            return weatherForecast;
        }

        public Task<IReadOnlyList<WeatherForecast>> ProvideForecastsAsync(int regionIndex, DateRequest date)
        {
            throw new NotImplementedException();
        }
    }
}
