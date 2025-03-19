using Exercice05.Pages;

namespace Exercice05
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WeatherPage();
        }
    }
}
