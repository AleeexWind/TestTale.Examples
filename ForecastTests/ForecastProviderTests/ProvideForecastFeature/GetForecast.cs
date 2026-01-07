using ForecastApp.Domain;
using ForecastApp.Services.Implementations;
using TestTale.Complete.Attempts;

namespace ForecastTests.ForecastProviderTests.ProvideForecastFeature
{
    internal class GetForecast : Attempt<ForecastProviderDependencies, ForecastProvider, GetForecastParameters, Task<WeatherForecast?>>
    {
        public override Func<Task<WeatherForecast?>> AttemptFunc
        {
            get
            {
                return () =>
                {
                    return Sut.ProvideForecastAsync(Parameters.RegionId, Parameters.DateRequest, Parameters.TimeOfDay);
                };
            }
        }
    }
}
