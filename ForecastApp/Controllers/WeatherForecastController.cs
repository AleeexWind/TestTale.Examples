using ForecastApp.Domain;
using ForecastApp.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ForecastApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IForecastProvider _summaryProvider;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IForecastProvider summaryProvider)
        {
            _logger = logger;
            _summaryProvider = summaryProvider;
        }

        [HttpGet]
        [Route("bydate")]
        public async Task<IEnumerable<WeatherForecast>> GetForecastsByDate(int regionId, [FromQuery] DateRequest date)
        {
            var weatherForcasts = await _summaryProvider.ProvideForecastsAsync(regionId, date);
            if (weatherForcasts?.Any() == true)
            {
                return weatherForcasts;
            }
            else
            {
                _logger.LogError("WeatherForcasts is null or empty. Parameters: region:{0}, date: {1} ", regionId, date);
                return Enumerable.Empty<WeatherForecast>();
            }
        }
        [HttpGet]
        [Route("bydateandtimeofday")]
        public async Task<IActionResult> GetForecastByDateAndTimeofDay(int regionId, [FromQuery] DateRequest date, TimeOfDay timeOfDay)
        {
            var weatherForcast = await _summaryProvider.ProvideForecastAsync(regionId, date, timeOfDay);
            if (weatherForcast is null)
            {
                _logger.LogError("WeatherForcasts is null or empty. Parameters: region:{0}, date: {1}, timeofday: {2} ", regionId, date, timeOfDay);
                return StatusCode(500, "Requested weatherForcast is received as null");
            }
            return Ok(weatherForcast);
        }
    }
}
