using TestTale.TestClients;

namespace ForecastTests.WeatherForecastTests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void WeatherForecast_should_has_89F()
        {
            TestClient
                .Attempts(new GetTempretureAsF()) //TODO if we put a property name, it does not work. Example: nameof(WeatherForecast.TemperatureF)
                .Using(new WeatherForecastDependencies())
                .WithNoSituation()
                .Then(new Get89F())
                .Run();
        }
    }
}
