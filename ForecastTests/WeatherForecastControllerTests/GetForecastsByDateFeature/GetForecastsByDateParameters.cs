using ForecastApp.Controllers;
using TestTale.Complete.Parameters;

namespace ForecastTests.WeatherForecastControllerTests.GetForecastsByDateFeature
{
    internal class GetForecastsByDateParameters : IAttemptParameters
    {
        public int RegionId { get; set; }
        public DateRequest DateRequest { get; set; }
    }
}
