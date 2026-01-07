using ForecastApp.Controllers;
using ForecastApp.Domain;
using TestTale.Complete.Parameters;

namespace ForecastTests.ForecastProviderTests.ProvideForecastFeature
{
    internal class GetForecastParameters : IAttemptParameters
    {
        public int RegionId { get; set; }
        public DateRequest DateRequest { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
    }
}
