using Aasani.CRM.Data;
using Aasani.CRM.Logic;
using AsyncAwaitBestPractices.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aasani.CRM.App
{
    public class MainWindowViewModel : Observable
    {
        private readonly CustomerService customerService;
        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;

        public ObservableCollection<Customer> Customers { get => customers; set => OnPropertyChange(ref customers, value); }
        public Customer SelectedCustomer { get => selectedCustomer; set {
                OnPropertyChange(ref selectedCustomer, value);
                OnPropertyChange(nameof(IsCustomerSelected));
            } }
        public IAsyncCommand AddCustomerCommand { get; set; }
        public IAsyncCommand DeleteCustomerCommand { get; set; }

        public bool IsCustomerSelected => SelectedCustomer != null;

        public MainWindowViewModel(CustomerService customerService)
        {
            this.customerService = customerService;
            AddCustomerCommand = new AsyncCommand(AddCustomer);
            DeleteCustomerCommand = new AsyncCommand(DeleteCustomer);
        }

        public void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>(customerService.GetAll());
            SelectedCustomer = null;
        }

        private Task AddCustomer()
        {
            var customer = new Customer { FirstName = "New", LastName = "", Phone = "", IsDeveloper = false };
            Customers.Add(customer);
            customerService.Add(customer);
            SelectedCustomer = customer;
            return Task.CompletedTask;
        }

        private Task DeleteCustomer()
        {
            Customers.Remove(SelectedCustomer);
            customerService.Remove(selectedCustomer);
            SelectedCustomer = null;
            return Task.CompletedTask;
        }
    }
}
