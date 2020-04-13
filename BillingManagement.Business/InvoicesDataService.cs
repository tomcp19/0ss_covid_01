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

        public InvoiceDataService()
        {
            Random rnd1 = new Random();      

            for (int i = 0; i < 500; i++)
            {
                var nbSubtotalRandom = rnd1.Next(100, 10000);     
                Invoice newInvoices = new Invoice() { Subtotal = nbSubtotalRandom };   

                invoices.Add(newInvoices);       
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

