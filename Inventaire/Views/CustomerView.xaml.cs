using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BillingManagement.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
       // BillingManagement.UI.ViewModels.CustomerViewModel _vm1;
        public CustomerView()
        {
            InitializeComponent();
        }

       private void CustomerDelete_Click(object sender, RoutedEventArgs e)
        {
            /*int currentIndex = _vm1.Customers.IndexOf(_vm1.SelectedCustomer);

            if (currentIndex > 0)
                currentIndex--;

            _vm1.Customers.Remove(_vm1.SelectedCustomer);

            lvCustomers.SelectedIndex = currentIndex;*/

        }
    }
}
