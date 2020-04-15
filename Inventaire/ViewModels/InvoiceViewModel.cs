using app_models;
using BillingManagement.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    class InvoiceViewModel : BaseViewModel
    {
        //Ajoutez une InvoiceViewModel dans lequel on y retrouve les factures et l’information que l’on désire afficher dans InvoiceView.

        public InvoiceDataService InvoicesDataService;
        private ObservableCollection<Invoice> invoices;
        private Invoice selectedInvoice; 

        public ObservableCollection<Invoice> Invoices
        {
            get => invoices;
            private set
            {
                invoices = value;
                OnPropertyChanged();
            }
        }
        
        public Invoice SelectedInvoice 
        {
            get => selectedInvoice;
            set
            {
                selectedInvoice = value;
                OnPropertyChanged();
            }
        }

        public InvoiceViewModel()
        {
            InitValues();
        }

        private void InitValues()
        {

            InvoicesDataService = new InvoiceDataService();
            Invoices = new ObservableCollection<Invoice>(InvoicesDataService.GetAll());
            Debug.WriteLine(Invoices.Count);
        }
    }
}
