using BillingManagement.Business;
using BillingManagement.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BillingManagement.UI.ViewModels
{
    public class CustomersViewModel: BaseViewModel
    {
        CustomersDataService customersDataService = new CustomersDataService();

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

        public CustomersViewModel()
        {
            InitValues();
        }

        private void InitValues()
        {
            customersDataService = new CustomersDataService();
            Customers = new ObservableCollection<Customer>(customersDataService.GetAll());
            //Debug.WriteLine(Customers.Count);
        }
    }
}
