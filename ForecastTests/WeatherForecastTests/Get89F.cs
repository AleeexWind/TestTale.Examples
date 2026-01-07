using FluentAssertions;
using ForecastApp.Domain;
using TestTale.Parameterless.Verifications;

namespace ForecastTests.WeatherForecastTests
{
    internal class Get89F : Verification<WeatherForecastDependencies, WeatherForecast, int>
    {
        public override void Verify()
        {
            Attempt.Result.Should().Be(89);
        }
    }
}
