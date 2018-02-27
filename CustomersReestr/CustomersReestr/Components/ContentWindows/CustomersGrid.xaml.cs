using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using CustomersReestr.Components.Controllers;
using CustomersReestr.Components.Models;

namespace CustomersReestr
{
    public partial class CustomersGrid : Page
    {
        public static string TITLE_TEXT = "Реестр клиентов";

        private MainWindow mainWindow;

        public CustomersGrid(MainWindow inputMainWindow)
        {
            InitializeComponent();
            FillGrid();
            mainWindow = inputMainWindow;
        }

        private void FillGrid()
        {
            cusgrid.ItemsSource = CustomerController.GetCustomers();
        }

        private void OnEditRow_ClickHandler(object sender, RoutedEventArgs e)
        {
            Customer customer = (Customer)cusgrid.SelectedItem;
            mainWindow.NavigateToEditCustomer(customer);
        }
        private void OnDelRow_ClickHandler(object sender, RoutedEventArgs e)
        {
            Customer customer = (Customer)cusgrid.SelectedItem;
            string message = "Вы уверены,что хотите удалить клиента?";
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(message, "Информация", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                CustomerController.DeleteEntity(customer);
                System.Windows.Forms.MessageBox.Show("Запись удалена");
            }
            FillGrid();
        }
    }
}
