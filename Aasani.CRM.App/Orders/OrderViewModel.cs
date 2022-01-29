using Aasani.CRM.App.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aasani.CRM.App.Orders
{
    public class OrderViewModel : BindableBase
    {
        private Customer selectedCustomer;

        public Customer SelectedCustomer { get => selectedCustomer; set => SetProperty(ref selectedCustomer, value); }
    }
}
