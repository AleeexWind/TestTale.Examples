using ForecastTests.ForecastProviderTests.ProvideForecastFeature;
using TestTale.TestClients;

namespace ForecastTests.ForecastProviderTests
{
    public class ForecastProviderTests
    {
        [Fact]
        public async Task Successful_metric_shoud_be_sent()
        {
            await TestClient
                .Attempts(new GetForecast())
                .Using(new ForecastProviderDependencies())
                .WithAnyParameters()
                .WithSituation(new WhenProvidedForecastIsNotNull())
                .Then(new SeeSuccessfulMetric())
                .RunAsync();
        }
        [Fact]
        public async Task Failed_metric_shoud_be_sent()
        {
            await TestClient
                .Attempts(new GetForecast())
                .Using(new ForecastProviderDependencies())
                .WithAnyParameters()
                .WithSituation(new WhenUnhandledExceptionRaised())
                .Then(new SeeFailedMetric())
                .RunAsync();
        }
        [Fact]
        public async Task Null_metric_shoud_be_sent()
        {
            await TestClient
                .Attempts(new GetForecast())
                .Using(new ForecastProviderDependencies())
                .WithAnyParameters()
                .WithSituation(new WhenProvidedForecastIsNull())
                .Then(new SeeNullMetric())
                .RunAsync();
        }
    }
}
