using ForecastApp.Domain;
using TestTale.Parameterless.Attempts;

namespace ForecastTests.WeatherForecastTests
{
    internal class GetTempretureAsF : Attempt<WeatherForecastDependencies, WeatherForecast, int>
    {
        public override Func<int> AttemptFunc
        {
            get
            {
                return () =>
                {
                    return Sut.TemperatureF;
                };
            }
        }
    }
}
