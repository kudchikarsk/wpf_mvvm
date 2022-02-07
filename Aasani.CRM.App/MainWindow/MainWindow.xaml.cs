using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        const string FORWARD = "\uE72A";
        const string BACKWARD = "\uE72B";
        bool isForward = true;
        MainWindowViewModel ViewModel;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel(new CustomerService());
            DataContext = ViewModel;
            ViewModel.LoadCustomers();
            ViewModel.PropertyChanged += (s, e) =>
              {
                  if (e.PropertyName == nameof(MainWindowViewModel.IsCustomerSelected))
                  {
                      PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsCustomerSelected)));
                  }
              };
        }

        private void MoveCustomerListLayout_Click(object sender, RoutedEventArgs e)
        {
            isForward = !isForward;
            listDirectionButton.Text = isForward ? FORWARD : BACKWARD;
            customerListViewGrid.SetValue(Grid.ColumnProperty, isForward ? 0 : 2);
        }

        public Visibility IsCustomerSelected => ViewModel?.IsCustomerSelected ?? false ? Visibility.Visible : Visibility.Collapsed;
    }
}
