using System.Windows;
using System.Windows.Controls;
using CustomersReestr.Components.Controllers;

namespace CustomersReestr
{
    public partial class CustomersGrid : Page
    {
        public CustomersGrid()
        {
            InitializeComponent();
            FillGrid();
        }

        private void FillGrid()
        {
            cusgrid.ItemsSource = CustomerController.GetCustomers();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
