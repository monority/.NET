using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice05.Models
{
    public class WeatherResponse
    {
        public CurrentWeather current { get; set; }
    }

    public class CurrentWeather
    {
        public string time { get; set; }
        public double temperature_2m { get; set; }
        public double precipitation { get; set; }
        public double wind_speed_10m { get; set; }
        public string TemperatureFormatted => $"{temperature_2m} °C";
        public string WindFormatted => $"{wind_speed_10m} km/h";
        public int weather_code { get; set; }
    }

}
