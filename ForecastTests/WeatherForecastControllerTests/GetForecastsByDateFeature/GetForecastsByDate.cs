using ForecastApp.Controllers;
using ForecastApp.Domain;
using TestTale.Complete.Attempts;

namespace ForecastTests.WeatherForecastControllerTests.GetForecastsByDateFeature
{
    internal class GetForecastsByDate : Attempt<WeatherForecastControllerDependencies, WeatherForecastController, GetForecastsByDateParameters, Task<IEnumerable<WeatherForecast>>>
    {
        public override Func<Task<IEnumerable<WeatherForecast>>> AttemptFunc
        {
            get
            {
                return () =>
                {
                    return Sut.GetForecastsByDate(Parameters.RegionId, Parameters.DateRequest);
                };
            }
        }
    }
}
