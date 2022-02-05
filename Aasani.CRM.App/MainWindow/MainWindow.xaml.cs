﻿using System;
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
            isUserInteraction = false;
            var customer = customerList.SelectedItem as Customer;
            if(customer != null)
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

            var customer = customerList.SelectedItem as Customer;
            customer.FirstName = firstNameTextBox.Text;
            customer.LastName = lastNameTextBox.Text;
            customer.Phone = phoneTextBox.Text;
            customer.IsDeveloper = isDeveloperChkBox.IsChecked.GetValueOrDefault();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer { FirstName = "New", LastName = "", Phone = "", IsDeveloper = false };
            customerList.Items.Add(customer);
            customers.Add(customer);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var customer = customerList.SelectedItem as Customer;
            customerList.Items.Remove(customer);
            customers.Remove(customer);
        }
    }
}
