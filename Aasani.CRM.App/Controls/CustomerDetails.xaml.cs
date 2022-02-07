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

namespace Aasani.CRM.App.Controls
{
    /// <summary>
    /// Interaction logic for CustomerDetails.xaml
    /// </summary>
    public partial class CustomerDetails : UserControl
    {

        public CustomerDetails()
        {
            InitializeComponent();
        }

        public Customer Customer
        {
            get { return (Customer)GetValue(CustomerProperty); }
            set { SetValue(CustomerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Customer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerProperty =
            DependencyProperty.Register("Customer", typeof(Customer), typeof(CustomerDetails), new PropertyMetadata(null));

       
    }
}
