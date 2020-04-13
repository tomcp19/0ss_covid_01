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
        //public static int InvoiceId; //{ get; private set; }
        //readonly DateTime CreationDateTime; //{ get; private set; }
        //private Customer customer;
        //private double subTotal;
        //public double FedTax { get { return subTotal * 0.05; } }
        // public double ProvTax { get { return subTotal * 0.0975; } }
        // private double total { get { return subTotal + ProvTax + FedTax; } }

        readonly InvoiceDataService invoicesDataService = new InvoiceDataService();

        private ObservableCollection<Invoice> invoices;
        private Invoice selectedInvoice; //si jamais on a plus qu'un invoice? flushera plus tard ni non-nécessaire

        public ObservableCollection<Invoice> Invoices
        {
            get => invoices;
            private set
            {
                invoices = value;
                OnPropertyChanged();
            }
        }
        
        public Invoice SelectedInvoice //si jamais on a plus qu'un invoice?? //si jamais on a plus qu'un invoice? flushera plus tard ni non-nécessaire
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
            Invoices = new ObservableCollection<Invoice>(invoicesDataService.GetAll());
            Debug.WriteLine(Invoices.Count);
        }
    }
}
