using Microsoft.Maui.Controls;
using System.Diagnostics;
using Exercice04.Models;
using System.Text;

namespace Exercice04.Pages
{
    public partial class HangManPage : ContentPage
    {
        public HangManViewModel ViewModel { get; set; }
        public List<string> QuotesList { get; } = new()
        {
            "apple",
            "banana",
            "kiwi"
        };


        public HangManPage()
        {
            InitializeComponent();
            ViewModel = new HangManViewModel();
            BindingContext = ViewModel;
            GenerateWords();
        }
        private void Btn_Clicked(object? sender, EventArgs e)
        {
            if (sender is not Button button || ViewModel.WordToFind == null || ViewModel.Mask == null)
                return;

            DisableButton(button);

            char pressedChar = button.Text.ToLower()[0];
            bool letterFound = false;
            StringBuilder newMask = new(ViewModel.Mask);

            for (int i = 0; i < ViewModel.WordToFind.Length; i++)
            {
                if (char.ToLower(ViewModel.WordToFind[i]) == pressedChar)
                {
                    newMask[i] = ViewModel.WordToFind[i];
                    letterFound = true;
                }
            }
            ViewModel.Mask = newMask.ToString();

            if (!letterFound)
            {
                ViewModel.Errors += 1;

            }

            CheckGameStatus();
        }

        private void DisableButton(Button button)
        {
            button.BackgroundColor = Color.FromArgb("#c8c8c8");
            button.TextColor = Color.FromArgb("#000000");
            button.IsEnabled = false;
        }

        private void CheckGameStatus()
        {
            if (ViewModel.Mask == ViewModel.WordToFind)
            {
                ViewModel.Mask = "You won";
                ShowRetryButton();
                DisableAllButtons();
                return;
            }

            if (ViewModel.Errors == 7)
            {
                ShowRetryButton();
                Mask.IsVisible = false;
                DisableAllButtons();
            }
        }

        private void ShowRetryButton()
        {
            BtnRetry.IsEnabled = true;
            BtnRetry.IsVisible = true;
        }

        private void DisableAllButtons()
        {
            foreach (var view in this.Content.FindByName<FlexLayout>("ButtonContainer").Children)
            {
                if (view is Button btn)
                {
                    btn.IsEnabled = false;
                }
            }
        }

        public void GenerateWords()
        {
            Random rnd = new();
            var randomQuote = rnd.Next(0, QuotesList.Count);
            string newWord = QuotesList[randomQuote];
            ViewModel.GenerateMask(newWord);
        }

        private void ResetButtons()
        {
            foreach (var view in this.Content.FindByName<FlexLayout>("ButtonContainer").Children)
            {
                if (view is Button button)
                {
                    button.BackgroundColor = Color.FromArgb("#9e4222");
                    button.TextColor = Color.FromArgb("#ffffff");
                    button.IsEnabled = true;
                }
            }
        }

        private void BtnRetry_Clicked(object sender, EventArgs e)
        {
            GenerateWords();
            BtnRetry.IsEnabled = false;
            BtnRetry.IsVisible = false;
            Mask.IsVisible = true;
            ResetButtons();
            ViewModel.Errors = 0;
        }
    }
}
