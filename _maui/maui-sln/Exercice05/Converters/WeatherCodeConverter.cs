﻿using System.Globalization;
using Microsoft.Maui.Controls;

namespace Exercice05.Converters;

public class WeatherCodeConverter : IValueConverter
{
    private static readonly Dictionary<int, string> WeatherCodeDescriptions = new()
{
    { 0, "Clear sky" },
    { 1, "Mostly clear" },
    { 2, "Partly cloudy" },
    { 3, "Overcast" },
    { 45, "Fog" },
    { 48, "Freezing fog" },
    { 51, "Light drizzle" },
    { 53, "Moderate drizzle" },
    { 55, "Dense drizzle" },
    { 56, "Light freezing drizzle" },
    { 57, "Dense freezing drizzle" },
    { 61, "Light rain" },
    { 63, "Moderate rain" },
    { 65, "Heavy rain" },
    { 66, "Light freezing rain" },
    { 67, "Heavy freezing rain" },
    { 71, "Light snow" },
    { 73, "Moderate snow" },
    { 75, "Heavy snow" },
    { 77, "Snow grains" },
    { 80, "Light rain showers" },
    { 81, "Moderate rain showers" },
    { 82, "Heavy rain showers" },
    { 85, "Light snow showers" },
    { 86, "Heavy snow showers" },
    { 95, "Thunderstorms" },
    { 96, "Thunderstorms with light hail" },
    { 99, "Thunderstorms with heavy hail" }
};


    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is int weatherCode && WeatherCodeDescriptions.TryGetValue(weatherCode, out var description))
        {
            return description;
        }
        return "Code météo inconnu";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

