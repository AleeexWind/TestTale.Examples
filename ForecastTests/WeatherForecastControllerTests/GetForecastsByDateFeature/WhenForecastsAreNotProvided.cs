using ForecastApp.Controllers;
using ForecastApp.Domain;
using Moq;
using TestTale.Complete.Situations;

namespace ForecastTests.WeatherForecastControllerTests.GetForecastsByDateFeature
{
    internal class WhenForecastsAreNotProvided : Situation<WeatherForecastControllerDependencies, WeatherForecastController, GetForecastsByDateParameters, Task<IEnumerable<WeatherForecast>>>
    {
        private readonly IReadOnlyList<WeatherForecast>? _expectedReturn = null;
        public override Action Action
        {
            get
            {
                return () =>
                {
                    Attempt.SutDependencies.ForecastProviderMock
                    .Setup(p => p.ProvideForecastsAsync(Attempt.Parameters.RegionId, Attempt.Parameters.DateRequest))
                    .ReturnsAsync(_expectedReturn!);
                };
            }
        }
    }
}
