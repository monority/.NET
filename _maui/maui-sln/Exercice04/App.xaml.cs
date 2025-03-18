using Exercice04.Pages;

namespace Exercice04
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new HangManPage();
        }
    }
}
