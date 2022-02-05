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
        private Customer customer;
        private bool isUserInteraction = true;

        public CustomerDetails()
        {
            InitializeComponent();
        }

        internal void SetCustomer(Customer customer)
        {
            this.customer = customer;
            isUserInteraction = false;
            if (customer != null)
            {
                firstNameTextBox.Text = customer.FirstName;
                lastNameTextBox.Text = customer.LastName;
                phoneTextBox.Text = customer.Phone;
                isDeveloperChkBox.IsChecked = customer.IsDeveloper;
            }
            isUserInteraction = true;
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
            if(customer != null)
            {
                customer.FirstName = firstNameTextBox.Text;
                customer.LastName = lastNameTextBox.Text;
                customer.Phone = phoneTextBox.Text;
                customer.IsDeveloper = isDeveloperChkBox.IsChecked.GetValueOrDefault();
            }
        }
    }
}
