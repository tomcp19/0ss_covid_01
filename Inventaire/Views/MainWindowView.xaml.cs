using app_models;
using BillingManagement.UI.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window, INotifyPropertyChanged
    {
        BaseViewModel _mainContentViewModel;

        public BaseViewModel MainContentViewModel
        {
            get => _mainContentViewModel;
            set
            {
                _mainContentViewModel = value;
                OnPropertyChanged();
            }
        }

        CustomerViewModel customerViewModel;
        InvoiceViewModel invoiceViewModel;


        public MainWindowView(BaseViewModel vm)
        {
            InitializeComponent();

            MainContentViewModel = vm;

            System.Type vmType = vm.GetType();

            if (vmType == typeof(CustomerViewModel))
            {
                customerViewModel = vm as CustomerViewModel;
            } else if (vmType == typeof(InvoiceViewModel))
            {
                invoiceViewModel = vm as InvoiceViewModel;
            }
        }


        private void NewItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ShowCustomersView_Click(object sender, RoutedEventArgs e)
        {
            if (_mainContentViewModel.GetType() != typeof(CustomerViewModel))
            {
                if (customerViewModel != null)
                {
                    MainContentViewModel = customerViewModel;
                } else
                {
                    MainContentViewModel = customerViewModel = new CustomerViewModel();
                }
            }
        }

        private void ShowInvoicesView_Click(object sender, RoutedEventArgs e)
        {
            if (_mainContentViewModel.GetType() != typeof(InvoiceViewModel))
            {
                if (invoiceViewModel != null)
                {
                    MainContentViewModel = invoiceViewModel;
                } else
                {
                    MainContentViewModel = invoiceViewModel = new InvoiceViewModel(customerViewModel.Customers);
                }
            }
        }
    }
}
