using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice05.Models
{
    public class Weather
    {

        public string? CityName { get; set; }
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public decimal Wind { get; set; }
        public int WeatherCondition { get; set; }

        public class Rootobject
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
            public float generationtime_ms { get; set; }
            public int utc_offset_seconds { get; set; }
            public string timezone { get; set; }
            public string timezone_abbreviation { get; set; }
            public float elevation { get; set; }
            public Hourly_Units hourly_units { get; set; }
            public Hourly hourly { get; set; }
        }

        public class Hourly_Units
        {
            public string time { get; set; }
            public string temperature_2m { get; set; }
            public string weather_code { get; set; }
            public string rain { get; set; }
            public string precipitation { get; set; }
            public string apparent_temperature { get; set; }
        }

        public class Hourly
        {
            public string[] time { get; set; }
            public float[] temperature_2m { get; set; }
            public int[] weather_code { get; set; }
            public float[] rain { get; set; }
            public float[] precipitation { get; set; }
            public float[] apparent_temperature { get; set; }
        }

    }
}
