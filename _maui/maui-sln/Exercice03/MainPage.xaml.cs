namespace Exercice03;

public partial class MainPage : ContentPage
{
    HashSet<string> quotes = new();

    public MainPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await LoadMauiAsset();

    }
    async Task LoadMauiAsset()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
        using var reader = new StreamReader(stream);

        while (reader.Peek() >= 0)
        {
            var line = await reader.ReadLineAsync();
            quotes.Add(line);
        }
    }

    private void GetRandomGradient()
    {
        Random rnd = new Random();
        double blueRnd = rnd.Next(0, 255) / 255.0;
        double redRnd = rnd.Next(0, 255) / 255.0;
        double greenRnd = rnd.Next(0, 255) / 255.0;

        LinearGradientBrush brush = new LinearGradientBrush
        {
            GradientStops = new GradientStopCollection
        {
            new GradientStop { Color = Color.FromRgb(redRnd, greenRnd, blueRnd), Offset = 0.0f },
            new GradientStop { Color = Color.FromRgb(blueRnd, redRnd, greenRnd), Offset = 1.0f }
        },
            StartPoint = new Point(0, 0),
            EndPoint = new Point(1, 1)
        };

        PageBg.Background = brush;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        for (int i = 0; i < quotes.Count; i++)
        {
            Random rnd = new Random();
            var randomQuote = rnd.Next(1, quotes.Count);
            quote.Text = quotes.ElementAt(randomQuote);
        }
        GetRandomGradient();
    }
}
