using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Exercice04.Models
{
    public class HangManViewModel : INotifyPropertyChanged
    {

        private string? _wordToFind;
        public string? WordToFind
        {
            get => _wordToFind;
            set
            {
                _wordToFind = value;
                OnPropertyChanged();
            }
        }
        private int? _errors = 0;

        public int? Errors {
            get => _errors;
            set {
                _errors = value;
                OnPropertyChanged();
            }
        }

        private string? _mask;
        public string? Mask
        {
            get => _mask;
            set
            {
                _mask = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GenerateMask(string selectedword)
        {
            WordToFind = selectedword;
            Mask = string.Empty;

            for (int i = 0; i < selectedword.Length; i++)
            {
                Mask += "_";
            }

            Debug.WriteLine($"Word: {WordToFind}, Mask: {Mask}");
        }
    }
}
