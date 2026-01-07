using ForecastApp.Controllers;
using ForecastApp.Domain;

namespace ForecastApp.Services.Abstractions
{
    public interface IForecastProvider
    {
        public Task<IReadOnlyList<WeatherForecast>> ProvideForecastsAsync(int regionId, DateRequest date);

        public Task<WeatherForecast?> ProvideForecastAsync(int regionId, DateRequest date, TimeOfDay timeOfDay);
    }
}
