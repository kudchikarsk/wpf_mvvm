using AsyncAwaitBestPractices.MVVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aasani.CRM.App.Customers
{
    public class AddCustomerViewModel : BindableBase
    {
        private Customer newCustomer;

        public Customer NewCustomer { get => newCustomer; set => SetProperty(ref newCustomer, value); }
        public AsyncCommand AddCustomerCommand { get; set; }
        public event EventHandler<Customer> AddCustomerEvent = delegate { };

        public AddCustomerViewModel()
        {
            AddCustomerCommand = new AsyncCommand(AddCustomer);
            NewCustomer = new Customer();
        }

        private Task AddCustomer()
        {
            AddCustomerEvent(this, NewCustomer);
            NewCustomer = new Customer();
            return Task.CompletedTask;
        }
    }
}
