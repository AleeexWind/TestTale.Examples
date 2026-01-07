using ForecastApp.Domain;
using ForecastApp.Services.Implementations;
using Moq;
using TestTale.Complete.Situations;

namespace ForecastTests.ForecastProviderTests.ProvideForecastFeature
{
    internal class WhenProvidedForecastIsNotNull : Situation<ForecastProviderDependencies, ForecastProvider, GetForecastParameters, Task<WeatherForecast?>>
    {
        private readonly WeatherForecast _returnedWeatherForecast = new()
        {
            Date = default,
            TimeOfDay = default,
            Region= new Region()
            {
                Id = 1,
                Name = "Moscow"
            },
            Summary = "Sunny",
            TemperatureC = 22
        };
        public override Action Action
        {
            get
            {
                return () =>
                {
                    Attempt.SutDependencies.WeatherForecastRepositoryMock
                    .Setup(x => x.GetWeatherForecast(
                        Attempt.Parameters.RegionId,
                        Attempt.Parameters.DateRequest,
                        Attempt.Parameters.TimeOfDay
                        ))
                    .ReturnsAsync(_returnedWeatherForecast);
                };
            }
        }
    }
}
