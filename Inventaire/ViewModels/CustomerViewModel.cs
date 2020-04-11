using app_models;
using BillingManagement.Business;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BillingManagement.UI.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        readonly CustomersDataService customersDataService = new CustomersDataService();

        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;

        public ObservableCollection<Customer> Customers
        {
            get => customers;
            private set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel()
        {
            InitValues();
        }

        private void InitValues()
        {
            Customers = new ObservableCollection<Customer>(customersDataService.GetAll());
            Debug.WriteLine(Customers.Count);
        }

    }
}
