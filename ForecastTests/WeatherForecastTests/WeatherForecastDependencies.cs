using ForecastApp.Domain;
using TestTale;

namespace ForecastTests.WeatherForecastTests
{
    internal class WeatherForecastDependencies : ISutDependencies<WeatherForecast>
    {
        public WeatherForecast SUT { get; }
        public WeatherForecastDependencies()
        {
            SUT = new WeatherForecast()
            {
                Date = default,
                TimeOfDay = default,
                Summary = default,
                Region = default,
                TemperatureC = 32,
            };
        }
    }
}
