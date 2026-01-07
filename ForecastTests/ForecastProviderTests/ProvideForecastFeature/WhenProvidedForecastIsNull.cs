using ForecastApp.Domain;
using ForecastApp.Services.Implementations;
using Moq;
using TestTale.Complete.Situations;

namespace ForecastTests.ForecastProviderTests.ProvideForecastFeature
{
    internal class WhenProvidedForecastIsNull : Situation<ForecastProviderDependencies, ForecastProvider, GetForecastParameters, Task<WeatherForecast?>>
    {
        private readonly WeatherForecast? _returnedForecast = null;
        public override Action Action
        {
            get
            {
                return () =>
                {
                    Attempt.SutDependencies.WeatherForecastRepositoryMock
                        .Setup(s => s.GetWeatherForecast(
                            Attempt.Parameters.RegionId,
                            Attempt.Parameters.DateRequest,
                            Attempt.Parameters.TimeOfDay))
                        .ReturnsAsync(_returnedForecast!);
                };
            }
        }
    }
}
