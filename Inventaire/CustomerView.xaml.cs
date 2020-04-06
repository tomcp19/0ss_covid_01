using BillingManagement.Models;
using BillingManagement.Business;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using BillingManagement.UI.ViewModels;

namespace Inventaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //Commentaire pour tester le petit commit
    public partial class MainWindow : Window
    {

        public MainWindow(CustomersViewModel vm)
        {
            InitializeComponent();

            DataContext = vm;
        }
    }
}
