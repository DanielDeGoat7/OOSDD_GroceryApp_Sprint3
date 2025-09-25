using Grocery.App.ViewModels;
using Grocery.App.Views;

namespace Grocery.App
{
    public partial class App : Application
    {
        public App(AppShell shell)
        {
            InitializeComponent();
            MainPage = shell;
        }
    }
}
