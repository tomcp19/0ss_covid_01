using BillingManagement.UI.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
    class MainViewModel: BaseViewModel
    {

        private BaseViewModel contentviewModel;

        public BaseViewModel ContentViewModel
        {
            get { return contentviewModel; }
            set
            {
                contentviewModel = value;
                OnPropertyChanged();
            }
        }

        CustomerViewModel customerViewModel;
        InvoiceViewModel invoiceViewModel;

        public ChangeViewCommand ChangeViewCommand { get; set; }

        public MainViewModel()
        {
            InitValues();
        }

        private void InitValues()
        { 
            customerViewModel = new CustomerViewModel();
            invoiceViewModel = new InvoiceViewModel();
            ChangeViewCommand = new ChangeViewCommand(ChangeView);
            ContentViewModel = customerViewModel;
        }
        private void ChangeView(string vm)
        { 
        switch(vm)
            {
                case "customer":
                    ContentViewModel = customerViewModel;
                    break;

                case "invoice":
                    ContentViewModel = invoiceViewModel;
                    break;

            }
        }

    }
}
