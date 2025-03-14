namespace Exercice02;

public partial class Sales : ContentPage
{
    private int _sliderValue;
    private int _totalPrice;
    private int _tip;
    private int _personCount = 1;

    public Sales()
    {
        InitializeComponent();
        UpdateUI();
    }

    private void UpdateUI()
    {
        totalPrice.Text = _totalPrice.ToString();
        TipEntry.Text = _tip.ToString();
        splitNumber.Text = CalculateSplitAmount().ToString();
        personNumber.Text = _personCount.ToString();
        PercentageTip.Text = _sliderValue.ToString();
    }

    private int CalculateSplitAmount()
    {
        return (_totalPrice + _tip) / _personCount;
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
        if (int.TryParse(EntryBill.Text, out int result))
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
