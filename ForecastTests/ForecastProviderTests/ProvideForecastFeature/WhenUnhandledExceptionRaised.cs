using ForecastApp.Domain;
using ForecastApp.Services.Implementations;
using TestTale.Complete.Situations;

namespace ForecastTests.ForecastProviderTests.ProvideForecastFeature
{
    internal class WhenUnhandledExceptionRaised : Situation<ForecastProviderDependencies, ForecastProvider, GetForecastParameters, Task<WeatherForecast?>>
    {
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
                        Attempt.Parameters.TimeOfDay))
                    .Throws(new Exception("Unhandled exception"));
                };
            }
        }
    }
}
