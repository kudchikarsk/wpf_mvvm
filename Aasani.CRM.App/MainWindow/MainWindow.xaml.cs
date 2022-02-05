using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aasani.CRM.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string FORWARD = "\uE72A";
        const string BACKWARD = "\uE72B";
        bool isForward = true;
        private List<Customer> customers;
        private bool isUserInteraction = true;

        public MainWindow()
        {
            InitializeComponent();
            customers = new List<Customer>
            {
                new Customer
                {
                    FirstName = "Chris",
                    LastName = "Brown",
                    Phone = "55486583454",
                    IsDeveloper = true
                },
                new Customer
                {
                    FirstName = "Paul",
                    LastName = "Green",
                    Phone = "567345456757",
                    IsDeveloper = false
                },
                new Customer
                {
                    FirstName = "Jean",
                    LastName = "White",
                    Phone = "567345456757",
                    IsDeveloper = true
                },
            };

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomers();

        }

        private void LoadCustomers()
        {
            customerList.Items.Clear();
            customers.ForEach(customer => customerList.Items.Add(customer));
        }

        private void MoveCustomerListLayout_Click(object sender, RoutedEventArgs e)
        {
            isForward = !isForward;
            listDirectionButton.Text = isForward ? FORWARD : BACKWARD;
            customerListViewGrid.SetValue(Grid.ColumnProperty, isForward ? 0 : 2);
        }

        private void customerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customerDetails.SetCustomer(customerList.SelectedItem as Customer);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer { FirstName = "New", LastName = "", Phone = "", IsDeveloper = false };
            customerList.Items.Add(customer);
            customers.Add(customer);
            customerList.SelectedIndex = customerList.Items.Count - 1;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var customer = customerList.SelectedItem as Customer;
            customerList.Items.Remove(customer);
            customers.Remove(customer);
        }
    }
}
