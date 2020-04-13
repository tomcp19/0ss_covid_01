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
        //public static int nextID;
        public static int InvoiceId; //{ get; private set; }
        readonly DateTime CreationDateTime; //{ get; private set; }
        private Customer customer;
        private double subTotal;
        public double FedTax { get { return subTotal * 0.05; } }
        public double ProvTax { get { return subTotal * 0.0975; } }
        private double total { get { return subTotal + ProvTax + FedTax; } }

        public double Subtotal
        {
            get => subTotal;
            set
            {
                subTotal = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ProvTax));
                OnPropertyChanged(nameof(FedTax));
            }
        }

        public Customer Customer
        {
            get => customer;
            set
            {
                Customer = value;
                OnPropertyChanged();
            }
        }

        public Invoice()
        {
            InvoiceId = Interlocked.Increment(ref InvoiceId);
            CreationDateTime = DateTime.Now;
        }

        public Invoice(Customer Customer)
        {
            InvoiceId = Interlocked.Increment(ref InvoiceId);
            CreationDateTime = DateTime.Now;
            customer = Customer;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

