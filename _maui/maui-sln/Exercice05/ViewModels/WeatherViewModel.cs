using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Exercice05.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private string _cityName;
        private DateTime _date;
        private int _temperature;
        private decimal _wind;
        private string _weatherCondition;
        private string _temperatureFormatted;
        private string _windFormatted;
        private int _weatherCode;
        public string CityName
        {
            get => _cityName;
            set
            {
                _cityName = value;
                OnPropertyChanged();
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        public int Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                OnPropertyChanged();
            }
        }
        public decimal Wind
        {
            get => _wind;
            set
            {
                _wind = value;
                OnPropertyChanged();
            }
        }
        public string WeatherCondition
        {
            get => _weatherCondition;
            set
            {
                _weatherCondition = value;
                OnPropertyChanged();
            }
        }
       
        public string TemperatureFormatted
        {
            get => _temperatureFormatted;
            set{
                _temperatureFormatted = value;
                OnPropertyChanged();
            }
        }
        public string WindFormatted
        {
            get => _windFormatted;
            set
            {
                _windFormatted = value;
                OnPropertyChanged();
            }
        }
        public int WeatherCode
        {
            get => _weatherCode;
            set
            {
                _weatherCode = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

   
    }
}
