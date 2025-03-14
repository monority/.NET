using System.Globalization;

namespace Exercice02;

public partial class Sales : ContentPage
{
    private double _sliderValue;
    private double _totalPrice;
    private double _tip;
    private int _personCount = 1;
    CultureInfo culture = new CultureInfo("fr-Fr");

    public Sales()
    {
        InitializeComponent();
        UpdateUI();

    }

    private void UpdateUI()
    {
        totalPrice.Text = _totalPrice.ToString("C", culture); ;
        TipEntry.Text = _tip.ToString("C", culture);
        splitNumber.Text = CalculateSplitAmount().ToString("C" , culture);
        personNumber.Text = _personCount.ToString();
        PercentageTip.Text = _sliderValue.ToString();
    }

    private int CalculateSplitAmount()
    {
        return (int)((_totalPrice + _tip) / _personCount);
    }

    private void UpdateTip()
    {
        _tip = _totalPrice * _sliderValue / 100;
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        _sliderValue = (int)e.NewValue;
        UpdateTip();
        UpdateUI();
    }

    private void EntryBill_Completed(object sender, EventArgs e)
    {
        if (double.TryParse(EntryBill.Text, out double result))
        {
            _totalPrice = result;
            UpdateTip();
            UpdateUI();
        }
        else
        {
            DisplayAlert("Error", "Invalid input. Please enter a valid number.", "OK");
        }
    }

    private void Btn_Person_Management(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            if (button == BtnMinus && _personCount > 1)
            {
                _personCount--;
            }
            else if (button == BtnPlus)
            {
                _personCount++;
            }

            UpdateUI();
        }
    }

    private void Btn_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            int tipPercentage = button switch
            {
                _ when button == BtnTen => 10,
                _ when button == BtnFifteen => 15,
                _ when button == BtnTwenty => 20,
                _ => 0
            };

            _sliderValue = tipPercentage;
            UpdateTip();
            UpdateUI();
        }
    }
}
