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
        private bool isUserInteraction = true;

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
            DependencyProperty.Register("Customer", typeof(Customer), typeof(CustomerDetails), new PropertyMetadata(null, CustomerPropertyChanged));

        private static void CustomerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CustomerDetails;
            if(d != null)
            {
                control.isUserInteraction = false;

                var customer = e.NewValue as Customer;                
                if (customer != null)
                {
                    control.firstNameTextBox.Text = customer.FirstName;
                    control.lastNameTextBox.Text = customer.LastName;
                    control.phoneTextBox.Text = customer.Phone;
                    control.isDeveloperChkBox.IsChecked = customer.IsDeveloper;
                }

                control.isUserInteraction = true;
            }
            
        }

        private void firstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerUpdated();
        }

        private void lastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerUpdated();
        }

        private void phoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerUpdated();
        }

        private void isDeveloperChkBox_Click(object sender, RoutedEventArgs e)
        {
            CustomerUpdated();
        }

        private void CustomerUpdated()
        {
            if (!isUserInteraction) return;
            if(Customer != null)
            {
                Customer.FirstName = firstNameTextBox.Text;
                Customer.LastName = lastNameTextBox.Text;
                Customer.Phone = phoneTextBox.Text;
                Customer.IsDeveloper = isDeveloperChkBox.IsChecked.GetValueOrDefault();
            }
        }
    }
}
