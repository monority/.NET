using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;


namespace Exercice05.Converters
{
    class WeatherImageConverter : IValueConverter
    {

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            string weather = value.ToString();  
            string icon = string.Empty;
            Debug.WriteLine(weather);
            switch (weather)
            {
                case "0":
                    icon = "sunny.json";
                    break;
                case "1":
                    icon = "foggy.json";
                    break;
                case "2":
                    icon = "parly-cloudy.json";
                    break;
                case "3":
                    icon = "windy.json";
                    break;
                default:
                    icon = "sunny.json";
                    break;
            }
            Debug.WriteLine(icon);
            return icon;
        }
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
