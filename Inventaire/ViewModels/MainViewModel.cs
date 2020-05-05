using BillingManagement.Models;
using BillingManagement.UI.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;

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

		public DelegateCommand<Customer> SearchCommand { get; private set; }

		public MainViewModel()
		{
			ChangeViewCommand = new ChangeViewCommand(ChangeView);
			DisplayInvoiceCommand = new DelegateCommand<Invoice>(DisplayInvoice);
			DisplayCustomerCommand = new DelegateCommand<Customer>(DisplayCustomer);

			AddNewItemCommand = new DelegateCommand<object>(AddNewItem, CanAddNewItem);
			AddInvoiceToCustomerCommand = new DelegateCommand<Customer>(AddInvoiceToCustomer);

			customerViewModel = new CustomerViewModel();
			invoiceViewModel = new InvoiceViewModel(customerViewModel.Customers);

			SearchCommand = new DelegateCommand<Customer>(SearchCustomer, CanSearch);

			VM = customerViewModel;

		}

		private void SearchCustomer(object parameter)
		{
			string input = parameter as string;
			//int output;
			string searchMethod;
			/*if (!Int32.TryParse(input, out output)) pas besoin car recherche juste les noms
			{
				searchMethod = "name";
			}
			else
			{
				searchMethod = "id";
			}*/

			//switch (searchMethod)
			{
				/*case "id":
					SelectedCustomer = PhoneBookBusiness.GetInvoiceByID(output);
					break;
				case "name":
					Contacts = PhoneBookBusiness.GetContactByName(input);
					if (Contacts.Count > 0)
					{
						SelectedContact = Contacts[0];
					}
					else
					{
						Contacts = PhoneBookBusiness.GetAllContacts();
						SelectedContact = Contacts.First<ContactModel>();
						MessageBox.Show("Aucun contact trouvé");
					}
					break;
				default:
					MessageBox.Show("Unknown search method");
					break;*/
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
			//Search.IsEnabled = false;
		}

		private void DisplayCustomer(Customer customer)
		{
			customerViewModel.SelectedCustomer = customer;
			VM = customerViewModel;
			//Search.IsEnabled = true;
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

	}
}
