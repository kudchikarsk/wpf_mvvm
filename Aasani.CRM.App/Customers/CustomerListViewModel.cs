using AsyncAwaitBestPractices.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aasani.CRM.App.Customers
{
    public class CustomerListViewModel : BindableBase
    {
        private ObservableCollection<Customer> customers;
        private Customer newCustomer;

        public Customer NewCustomer { get => newCustomer; set => SetProperty(ref newCustomer, value); }

        private CustomerService customerService;

        public ObservableCollection<Customer> Customers { get => customers; set => SetProperty(ref customers, value); }
        public AsyncCommand<Customer> PlaceOrderCommand { get; set; }
        public AsyncCommand AddCustomerCommand { get; set; }
        public event EventHandler<Customer> PlaceOrderEvent = delegate { };
        public event EventHandler AddCustomerEvent = delegate { };

        public CustomerListViewModel()
        {
            customerService = new CustomerService(); 
            PlaceOrderCommand = new AsyncCommand<Customer>(PlaceOrder);
            AddCustomerCommand = new AsyncCommand(AddCustomer);
        }

        private Task AddCustomer()
        {
            AddCustomerEvent(this, new EventArgs());
            return Task.CompletedTask;
        }

        public void Load()
        {
            Customers = new ObservableCollection<Customer>(
                customerService.GetAll()
            );
        }
       
        private Task PlaceOrder(Customer arg)
        {
            PlaceOrderEvent(this, arg);
            return Task.CompletedTask;
        }
    }
}
