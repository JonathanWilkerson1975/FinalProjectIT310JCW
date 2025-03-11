//namespace FinalProjectIT310JCW.Server.Controllers.Models
//{
//    public class WeatherForecast
//    {
//        public DateOnly Date { get; set; }

//        public int TemperatureC { get; set; }

//        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

//        public string? Summary { get; set; }
//    }
//}





// WeatherForecast.cs - Model for Weather Data
using System;

namespace FinalProjectIT310JCW.Server.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int Humidity { get; set; }
        public int WindSpeed { get; set; }
        public string Summary { get; set; }
    }
}
