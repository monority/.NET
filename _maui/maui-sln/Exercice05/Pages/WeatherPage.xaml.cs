using System.Diagnostics;
using System.Text.Json;
using Exercice05.Models;
using Exercice05.ViewModels;

namespace Exercice05.Pages;

public partial class WeatherPage : ContentPage
{
    HttpClient _http;
    public WeatherViewModel ViewModel { get; set; }

    public WeatherPage()
    {
        InitializeComponent();
        ViewModel = new WeatherViewModel();
        BindingContext = ViewModel;
        _http = new HttpClient();
    }
    private async Task GetWeather(Location location)
    {
        var response = await _http.GetAsync($"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&hourly=temperature_2m,wind_speed_10m&current=temperature_2m,precipitation,wind_speed_10m,weather_code");
        if (response.IsSuccessStatusCode)
        {
            using var contentAsStream = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<WeatherResponse>(contentAsStream);
            if (data != null && data.current != null)
            {
                ViewModel.CityName = LocationEntry.Text;
                ViewModel.Date = DateTime.Parse(data.current.time);
                ViewModel.TemperatureFormatted = data.current.TemperatureFormatted;
                ViewModel.WindFormatted = data.current.WindFormatted;
                ViewModel.WeatherCode = data.current.weather_code;
            }
        }
    }


    private async Task<Location> GetCoordinatesAsync()
    {
        try
        {
            IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(LocationEntry.Text);
            Location location = locations?.FirstOrDefault();
            if (location != null)
            {
                await GetWeather(location);
            }
            return location;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Erreur lors de la récupération des coordonnées : {ex.Message}");
            return null;
        }
    }


    private void LocationEntry_Completed(object sender, EventArgs e)
    {
        GetCoordinatesAsync();
    }
}
