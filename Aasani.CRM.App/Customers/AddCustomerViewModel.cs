using AsyncAwaitBestPractices.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            AddCustomerCommand = new AsyncCommand(AddCustomer, CanExecute);
            NewCustomer = new Customer();
            NewCustomer.ErrorsChanged += RaiseCanExecute;
        }

        private void RaiseCanExecute(object sender, DataErrorsChangedEventArgs e)
        {
            AddCustomerCommand.RaiseCanExecuteChanged();
        }

        private bool CanExecute(object arg)
        {
            return !NewCustomer.HasErrors;
        }

        private Task AddCustomer()
        {
            AddCustomerEvent(this, NewCustomer);
            NewCustomer = new Customer();
            NewCustomer.ErrorsChanged += RaiseCanExecute;
            return Task.CompletedTask;
        }
    }
}
