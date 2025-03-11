//using FinalProjectIT310JCW.Server.Controllers.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace FinalProjectIT310JCW.Server.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        };

//        private readonly ILogger<WeatherForecastController> _logger;

//        public WeatherForecastController(ILogger<WeatherForecastController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet(Name = "GetWeatherForecast")]
//        public IEnumerable<WeatherForecast> Get()
//        {
//            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//            {
//                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                TemperatureC = Random.Shared.Next(-20, 55),
//                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//            })
//            .ToArray();
//        }
//    }
//}





// WeatherForecastController.cs - ASP.NET Core Weather API Controller
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectIT310JCW.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<WeatherForecast> WeatherData = new();

        public WeatherForecastController()
        {
            if (!WeatherData.Any())
            {
                var rng = new Random();
                WeatherData = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Humidity = rng.Next(20, 100),
                    WindSpeed = rng.Next(5, 50),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToList();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            return Ok(WeatherData);
        }

        [HttpPost]
        public ActionResult AddWeather([FromBody] WeatherForecast forecast)
        {
            WeatherData.Add(forecast);
            return Ok("Weather entry added.");
        }

        [HttpPut("{date}")]
        public ActionResult UpdateWeather(DateTime date, [FromBody] WeatherForecast forecast)
        {
            var existing = WeatherData.FirstOrDefault(w => w.Date.Date == date.Date);
            if (existing == null)
                return NotFound("Weather data not found.");

            existing.TemperatureC = forecast.TemperatureC;
            existing.Humidity = forecast.Humidity;
            existing.WindSpeed = forecast.WindSpeed;
            existing.Summary = forecast.Summary;

            return Ok("Weather entry updated.");
        }

        [HttpDelete("{date}")]
        public ActionResult DeleteWeather(DateTime date)
        {
            var existing = WeatherData.FirstOrDefault(w => w.Date.Date == date.Date);
            if (existing == null)
                return NotFound("Weather data not found.");

            WeatherData.Remove(existing);
            return Ok("Weather entry deleted.");
        }
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int Humidity { get; set; }
        public int WindSpeed { get; set; }
        public string Summary { get; set; }
    }
}
