using ForecastApp.Controllers;
using ForecastApp.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Moq;
using TestTale;

namespace ForecastTests.WeatherForecastControllerTests
{
    internal class WeatherForecastControllerDependencies : ISutDependencies<WeatherForecastController>
    {
        public Mock<ILogger<WeatherForecastController>> LoggerMock { get; }
        public Mock<IForecastProvider> ForecastProviderMock { get; }
        public WeatherForecastController SUT { get; }

        public WeatherForecastControllerDependencies()
        {
            LoggerMock = new Mock<ILogger<WeatherForecastController>>();
            ForecastProviderMock = new Mock<IForecastProvider>();
            SUT = new(LoggerMock.Object, ForecastProviderMock.Object);
        }
    }
}
