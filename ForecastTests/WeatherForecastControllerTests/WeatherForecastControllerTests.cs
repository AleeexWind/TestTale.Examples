using ForecastTests.WeatherForecastControllerTests.GetForecastsByDateFeature;
using Microsoft.Extensions.Logging;
using TestTale.TestClients;

namespace ForecastTests.WeatherForecastControllerTests
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public async Task WhenThereAreNoForcasts_LogErrorShouldBeRaised()
        {
            await TestClient
                .Attempts(new GetForecastsByDate())
                .Using(new WeatherForecastControllerDependencies())
                .WithAnyParameters()
                .WithSituation(new WhenForecastsAreNotProvided())
                .Then(new SeeLog(LogLevel.Error, "WeatherForcasts is null or empty. Parameters:"))
                .RunAsync();
        }
    }
}
