using ForecastApp.Services.Implementations;
using ForecastApp.Services.Metrics.Abstractions;
using ForecastApp.Services.Repositories.Abstractions;
using Microsoft.Extensions.Logging;
using Moq;
using TestTale;

namespace ForecastTests.ForecastProviderTests
{
    internal class ForecastProviderDependencies : ISutDependencies<ForecastProvider>
    {
        public Mock<IWeatherForecastRepository> WeatherForecastRepositoryMock { get; } = new Mock<IWeatherForecastRepository>();
        public Mock<ILogger<ForecastProvider>> LoggerMock { get; } = new Mock<ILogger<ForecastProvider>>();
        public Mock<IForecastMetricsHandler> ForecastMetricHandlerMock { get; } = new Mock<IForecastMetricsHandler>();
        public ForecastProvider SUT { get; }
        public ForecastProviderDependencies()
        {
            SUT = new(WeatherForecastRepositoryMock.Object, LoggerMock.Object, ForecastMetricHandlerMock.Object);
        }
    }
}
