using BillingManagement.UI.ViewModels;
using System.Windows;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow _wnd;
        public App()
        {
            CustomersViewModel vm = new CustomersViewModel();

            _wnd = new MainWindow(vm);

            _wnd.Show();
        }
    }
}
