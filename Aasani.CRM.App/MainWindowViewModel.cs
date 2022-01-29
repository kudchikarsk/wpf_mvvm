using Aasani.CRM.App.Customers;
using Aasani.CRM.App.OrderPrep;
using Aasani.CRM.App.Orders;
using Aasani.CRM.Data;
using Aasani.CRM.Logic;
using AsyncAwaitBestPractices.MVVM;
using System;
using System.Collections.Generic;
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
        private BindableBase currentViewModel;

        public BindableBase CurrentViewModel { get => currentViewModel; set => SetProperty(ref currentViewModel, value); }
        public AsyncCommand<string> NavCommand { get; set; }

        public MainWindowViewModel()
        {
            CurrentViewModel = customerListViewModel;
            NavCommand = new AsyncCommand<string>(OnNav);
            customerListViewModel.PlaceOrderEvent += async (e, c) =>
            {
                orderViewModel.SelectedCustomer = c;
                await OnNav("order");
            };

        }

        public Task OnNav(string viewName)
        {
            switch (viewName)
            {
                case "customer":
                    CurrentViewModel = customerListViewModel;
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
