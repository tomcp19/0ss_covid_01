using System.Windows;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow _window;

        public App()
        {
            _window = new MainWindow();

            _window.Show();
        }
    }
}
