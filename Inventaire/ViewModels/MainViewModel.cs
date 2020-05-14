using BillingManagement.Models;
using BillingManagement.UI.ViewModels.Commands;
using Inventaire;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace BillingManagement.UI.ViewModels
{
    class MainViewModel : BaseViewModel
    {
		private BaseViewModel _vm;

		public BaseViewModel VM
		{
			get { return _vm; }
			set {
				_vm = value;
				OnPropertyChanged();
			}
		}

		private string searchCriteria;

		public string SearchCriteria
		{
			get { return searchCriteria; }
			set { 
				searchCriteria = value;
				OnPropertyChanged();
			}
		}


		CustomerViewModel customerViewModel;
		InvoiceViewModel invoiceViewModel;

		public ChangeViewCommand ChangeViewCommand { get; set; }

		public DelegateCommand<object> AddNewItemCommand { get; private set; }

		public DelegateCommand<Invoice> DisplayInvoiceCommand { get; private set; }
		public DelegateCommand<Customer> DisplayCustomerCommand { get; private set; }

		public DelegateCommand<Customer> AddInvoiceToCustomerCommand { get; private set; }

		public RelayCommand<Customer> SearchCommand { get; private set; }

		public DelegateCommand<object> CloseCommand { get; set; }

		public MainViewModel()
		{
			ChangeViewCommand = new ChangeViewCommand(ChangeView);
			DisplayInvoiceCommand = new DelegateCommand<Invoice>(DisplayInvoice);
			DisplayCustomerCommand = new DelegateCommand<Customer>(DisplayCustomer);

			AddNewItemCommand = new DelegateCommand<object>(AddNewItem, CanAddNewItem);
			AddInvoiceToCustomerCommand = new DelegateCommand<Customer>(AddInvoiceToCustomer);

			customerViewModel = new CustomerViewModel();
			invoiceViewModel = new InvoiceViewModel(customerViewModel.Customers);

			SearchCommand = new RelayCommand<Customer>(SearchCustomer, CanSearch);
			CloseCommand = new DelegateCommand<object>(CloseApp);

			VM = customerViewModel;

		}

		private void SearchCustomer(object parameter)
		{
			string input = searchCriteria as string;
			List<Customer> Customers = customerViewModel.CustomersBackUp.ToList<Customer>();//a garder intact
			List<Customer> CustomersResults = customerViewModel.Customers.ToList<Customer>();//pour la recherche
			Customer SelectedCustomer = customerViewModel.SelectedCustomer;
			ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

			SelectedCustomer = Customers.Find(c=> c.Name == input || c.LastName == input);

			if (SelectedCustomer != null)
			{
				customerViewModel.Customers.Clear();
				foreach (Customer c in CustomersResults.Where(c => c.Name.StartsWith(input) || c.LastName.StartsWith(input)))
				{
					customerViewModel.Customers.Add(c);
				}
				customerViewModel.SelectedCustomer = SelectedCustomer;
			}
			else
			{
				customerViewModel.Customers.Clear();
				foreach (Customer c in Customers)
				{
					customerViewModel.Customers.Add(c);
				}

				SelectedCustomer = Customers.First<Customer>();
				MessageBox.Show("Aucun contact trouvé");

			}
		}


		private void ChangeView(string vm)
		{
			switch (vm)
			{
				case "customers":
					VM = customerViewModel;

					break;
				case "invoices":
					VM = invoiceViewModel;

					break;
			}
		}

		private void DisplayInvoice(Invoice invoice)
		{
			invoiceViewModel.SelectedInvoice = invoice;
			VM = invoiceViewModel;
		}

		private void DisplayCustomer(Customer customer)
		{
			customerViewModel.SelectedCustomer = customer;
			VM = customerViewModel;
		}

		private void AddInvoiceToCustomer(Customer c)
		{
			var invoice = new Invoice(c);
			c.Invoices.Add(invoice);
			DisplayInvoice(invoice);
		}

		private void AddNewItem (object item)
		{
			if (VM == customerViewModel)
			{
				var c = new Customer();
				customerViewModel.Customers.Add(c);
				customerViewModel.SelectedCustomer = c;
			}
		}

		private bool CanAddNewItem(object o)
		{
			bool result = false;

			result = VM == customerViewModel;
			return result;
		}

		private bool CanSearch(object o)
		{
			bool result = false;
			result = VM == customerViewModel;
			return result;
		}

		private void CloseApp(object o)
		{
			App.Current.Shutdown();
		}

	}
}
