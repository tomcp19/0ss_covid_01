using BillingManagement.UI.ViewModels;
using System.Windows;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        CustomerView _window;

        public App()
        {
            CustomerViewModel vm = new CustomerViewModel();

            _window = new CustomerView(vm);

            _window.Show();
        }
    }
}
