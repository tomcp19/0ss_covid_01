using BillingManagement.UI.ViewModels;
using System.Windows;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainView _window;

        public App()
        {
            MainViewModel vm = new MainViewModel();

            _window = new MainView();

            _window.Show();
        }
    }
}
