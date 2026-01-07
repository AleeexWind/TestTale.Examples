using ForecastApp.Controllers;
using ForecastApp.Domain;
using Microsoft.Extensions.Logging;
using Moq;
using TestTale.Complete.Verifications;

namespace ForecastTests.WeatherForecastControllerTests.GetForecastsByDateFeature
{
    internal class SeeLog(LogLevel logLevel,
        string message) : Verification<WeatherForecastControllerDependencies, WeatherForecastController, GetForecastsByDateParameters, Task<IEnumerable<WeatherForecast>>>
    {
        private readonly LogLevel _logLevel = logLevel;
        private readonly string _message = message;
        public override void Verify()
        {
            Attempt.SutDependencies.LoggerMock.Verify(
                logger => logger.Log(
                    It.Is<LogLevel>(l => l == _logLevel),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains(_message)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }
}
