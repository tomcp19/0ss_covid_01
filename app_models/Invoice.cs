using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace app_models
{
    public class Invoice : INotifyPropertyChanged
    {
        public static int invoiceId = 0; //{ get; private set; }
        public int InvoiceId { get; private set; }
        private DateTime creationDateTime; //{ get; private set; }
        public DateTime CreationDateTime { get { return creationDateTime; } set { creationDateTime = value; } }
        private Customer customer;
        private double subTotal;
        public double FedTax { get { return subTotal * 0.05; } }
        public double ProvTax { get { return subTotal * 0.0975; } }
        public double Total { get { return Subtotal + ProvTax + FedTax; } }

        public double Subtotal
        {
            get { return subTotal; }
            set
            {
                subTotal = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ProvTax));
                OnPropertyChanged(nameof(FedTax));
                OnPropertyChanged(nameof(Total));
            }
        }

        public Customer Customer
        {
            get => customer;
            set
            {
                customer = value;
                OnPropertyChanged();
            }
        }

        public Invoice()
        {
            InvoiceId = Interlocked.Increment(ref invoiceId);
            CreationDateTime = DateTime.Now;
        }

        public Invoice(Customer _Customer)
        {
            Customer = _Customer;
            InvoiceId = Interlocked.Increment(ref invoiceId);
            CreationDateTime = DateTime.Now;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

