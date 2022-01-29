using AsyncAwaitBestPractices.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Aasani.CRM.App.Customers
{
    public class CustomerListViewModel : BindableBase
    {
        private ObservableCollection<Customer> customers;

        public ObservableCollection<Customer> Customers { get => customers; set => SetProperty(ref customers, value); }
        public AsyncCommand<Customer> PlaceOrderCommand { get; set; }
        public event EventHandler<Customer> PlaceOrderEvent = delegate { };

        public CustomerListViewModel()
        {
            Customers = new ObservableCollection<Customer>(
                new List<Customer> {
                    new Customer { FirstName = "Shadman", LastName = "Kudchikar", MobileNo = "7977503536" },
                    new Customer { FirstName = "Saif", LastName = "Kudchikar", MobileNo = "6977543536" },
                    new Customer { FirstName = "Suheb", LastName = "Kudchikar", MobileNo = "3977503536" },
                    new Customer { FirstName = "Aaman", LastName = "Kudchikar", MobileNo = "7875573536" },
                }
            );

            PlaceOrderCommand = new AsyncCommand<Customer>(PlaceOrder);
        }

        private Task PlaceOrder(Customer arg)
        {
            PlaceOrderEvent(this, arg);
            return Task.CompletedTask;
        }
    }
}
