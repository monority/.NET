namespace Exercice04
{
    public partial class MainPage : ContentPage
    {
        List<string> _quotesList = new();

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
            using var stream = await FileSystem.OpenAppPackageFileAsync("wordsList.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() >= 0)
            {
                var currentLine = await reader.ReadLineAsync();
                if (!String.IsNullOrWhiteSpace(currentLine)) _quotesList.Add(currentLine);
            }
        }
    }

}
