using DemoMAUI.Pages;
namespace DemoMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new DemoFlyoutPage();
        }

 
    }
}
