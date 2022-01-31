using Aasani.CRM.App.Customers;
using Aasani.CRM.App.OrderPrep;
using Aasani.CRM.App.Orders;
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
    public class MainWindowViewModel : BindableBase
    {
        private readonly CustomerListViewModel customerListViewModel = new CustomerListViewModel();
        private readonly OrderViewModel orderViewModel = new OrderViewModel();
        private readonly OrderPrepViewModel orderPrepViewModel = new OrderPrepViewModel();
        private readonly AddCustomerViewModel addCustomerViewModel = new AddCustomerViewModel();
        private readonly CustomerService customerService;
        private BindableBase currentViewModel;

        public BindableBase CurrentViewModel { get => currentViewModel; set => SetProperty(ref currentViewModel, value); }
        public AsyncCommand<string> NavCommand { get; set; }

        public MainWindowViewModel()
        {
            customerService = new CustomerService();
            CurrentViewModel = customerListViewModel;
            NavCommand = new AsyncCommand<string>(OnNav);
            customerListViewModel.PlaceOrderEvent += GotoOrder;
            customerListViewModel.AddCustomerEvent += GotoCustomer;
            addCustomerViewModel.AddCustomerEvent += SaveCustomer;
        }

        private async void GotoCustomer(object sender, EventArgs e)
        {
            await OnNav("add_customer");
        }

        private async void GotoOrder(object sender, Customer e)
        {
            orderViewModel.SelectedCustomer = e;
            await OnNav("order");
        }

        private async void SaveCustomer(object sender, Customer e)
        {
            customerService.Add(e);
            customerListViewModel.Load();
            await OnNav("customer");
        }


        public Task OnNav(string viewName)
        {
            switch (viewName)
            {
                case "customer":
                    CurrentViewModel = customerListViewModel;
                    break;
                case "add_customer":
                    CurrentViewModel = addCustomerViewModel;
                    break;
                case "order":
                    CurrentViewModel = orderViewModel;
                    break;
                case "orderPrep":
                    CurrentViewModel = orderPrepViewModel;
                    break;
            }

            return Task.CompletedTask;
        }
    }
}
