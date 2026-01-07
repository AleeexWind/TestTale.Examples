using ForecastApp.Controllers;
using ForecastApp.Domain;

namespace ForecastApp.Services.Repositories.Abstractions
{
    public interface IWeatherForecastRepository
    {
        Task<WeatherForecast> GetWeatherForecast(int regionIndex, DateRequest date, TimeOfDay timeOfDay);
    }
}
