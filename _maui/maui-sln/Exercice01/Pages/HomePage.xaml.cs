namespace Exercice01.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }
    private void ChangeRedValue(object sender,ValueChangedEventArgs args)
    {
        double value = ((Slider)sender).Value;
        int roundedValue = (int)Math.Round(value, 0);
        displayRed.Text = roundedValue.ToString();
        ShowHexColor();
    }
    private void ChangeBlueValue(object sender, ValueChangedEventArgs args)
    {
        double value = ((Slider)sender).Value;
        int roundedValue = (int)Math.Round(value, 0);
        displayBlue.Text = roundedValue.ToString();
        ShowHexColor();
    }
    private void ChangeGreenValue(object sender, ValueChangedEventArgs args)
    {
        double value = ((Slider)sender).Value;
        int roundedValue = (int)Math.Round(value, 0);
        displayGreen.Text = roundedValue.ToString();
        ShowHexColor();
    }
    private void ShowHexColor(){
        var myColor = Color.FromRgb(Convert.ToInt32(displayRed.Text), Convert.ToInt32(displayGreen.Text), Convert.ToInt32(displayBlue.Text));
        var myHexa = myColor.ToHex();
        hexRect.Fill = new SolidColorBrush(myColor);
        displayHex.Text = myHexa;
    }
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        var rnd = new Random();
        int rndGreen = rnd.Next(0, 255);
        int rndRed = rnd.Next(0, 255);
        int rndBlue = rnd.Next(0, 255);

        var newColor = Color.FromRgb(rndRed, rndGreen, rndBlue);
        var newHexa = newColor.ToHex();
        hexRect.Fill = new SolidColorBrush(newColor);
        displayHex.Text = newHexa;
        displayRed.Text = rndRed.ToString();
        displayGreen.Text = rndGreen.ToString();
        displayBlue.Text = rndBlue.ToString();
        
    }
}
