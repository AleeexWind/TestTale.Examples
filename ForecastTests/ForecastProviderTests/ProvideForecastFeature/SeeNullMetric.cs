using ForecastApp.Domain;
using ForecastApp.Services.Implementations;
using Moq;
using TestTale.Complete.Verifications;

namespace ForecastTests.ForecastProviderTests.ProvideForecastFeature
{
    internal class SeeNullMetric : Verification<ForecastProviderDependencies, ForecastProvider, GetForecastParameters, Task<WeatherForecast?>>
    {
        public override void Verify()
        {
            Attempt.SutDependencies.ForecastMetricHandlerMock
                .Verify(x => x.IncreaseNullProvidedForecast(), Times.Once);
        }
    }
}
