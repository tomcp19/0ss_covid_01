using app_models;
using BillingManagement.UI.ViewModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {

        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        /*
        BillingManagement.UI.ViewModels.MainViewModel _vm;

        public MainView(BillingManagement.UI.ViewModels.MainViewModel vm)
        {
            InitializeComponent();

            _vm = vm;
            DataContext = _vm;
        }*/
        /*

        private void CustomerNew_Click(object sender, RoutedEventArgs e)
        {
            app_models.Customer temp = new app_models.Customer() { Name = "Undefined", LastName = "Undefined" };
            _vm.Customers.Add(temp);
            _vm.SelectedCustomer = temp;            
        }

        private void CustomerDelete_Click(object sender, RoutedEventArgs e)
        {
            /*int currentIndex = _vm.Customers.IndexOf(_vm.SelectedCustomer);

            if (currentIndex > 0)
                currentIndex--;

            _vm.Customers.Remove(_vm.SelectedCustomer);

            lvCustomers.SelectedIndex = currentIndex;

        }
        
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }*/
    }
}
