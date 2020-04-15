using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app_models;

namespace BillingManagement.Business
{
    public class InvoiceDataService : IDataService<Invoice>
    {

        readonly List<Invoice> invoices = new List<Invoice>();
        readonly List<Customer> _customers = new CustomersDataService().GetAll().ToList();

        public InvoiceDataService()
        {
            InitValues();
        }

        public void InitValues()
        { 
            Random rnd = new Random();
            foreach (var customer in _customers)
            {
                int nbInvoices = rnd.Next(10);

                for (int i = 0; i < nbInvoices; i++)
                {
                    var invoice = new Invoice(customer);
                    invoice.Subtotal = rnd.NextDouble() * 100 + 50;
                    customer.Invoices.Add(invoice);
                    invoices.Add(invoice);
                }
            }
        }

        public IEnumerable<Invoice> GetAll()
        {
            foreach (Invoice c in invoices)
            {
                yield return c;
            }
        }
    }
}

