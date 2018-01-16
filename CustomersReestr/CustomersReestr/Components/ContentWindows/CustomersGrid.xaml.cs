using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CustomersReestr.Components.Controllers;
using CustomersReestr.Components.Models;


namespace CustomersReestr
{
    public partial class CustomersGrid : Page
    {
        public static string TITLE_TEXT = "Реестр клиентов";

        private MainWindow MainWindow;

        public CustomersGrid(MainWindow mainWindow)
        {
            InitializeComponent();
            FillGrid();
            MainWindow = mainWindow;
            //Тестовый Кусочек, что бы проверить действие экспорта
            List<Customers> customersList = CustomerController.GetCustomers().ToList();
            ExcellExportController.CreateExcelDocument( customersList,"E:\\Sample.xlsx");
        }

        private void FillGrid()
        {
            cusgrid.ItemsSource = CustomerController.GetCustomers();
        }

        private void OnEditRow_ClickHandler(object sender, RoutedEventArgs e)
        {
            Customers customer = (Customers)cusgrid.SelectedItem;
            MainWindow.NavigateToEditCustomer(customer);
        }
    }
}
