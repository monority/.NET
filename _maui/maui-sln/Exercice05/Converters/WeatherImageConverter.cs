using System.Globalization;
using System.Diagnostics;
using SkiaSharp.Extended.UI.Controls;
using Microsoft.Maui.Controls;

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
            Debug.WriteLine(weather);

            var lottieView = new SKLottieView
            {
                RepeatCount = -1, // Repeat indefinitely
                RepeatMode = SKLottieRepeatMode.Restart,
                Source = GetPictureFromCode(weather)
            };

            return lottieView.Source;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private SKLottieImageSource GetPictureFromCode(string weatherCode)
        {
            return new SKFileLottieImageSource
            {
                File = weatherCode switch
                {
                    "0" => "sunny.json",
                    "1" => "foggy.json",
                    "2" => "partly-cloudy.json",
                    "3" => "windy.json",
                    _ => "sunny.json"
                }
            };
        }
    }
}

