using CustomersReestr.Components.ContentWindows;
using CustomersReestr.Components.Controllers;
using CustomersReestr.Components.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CustomersReestr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowFrameWorker
    {
        public MainWindow()
        {
            InitializeComponent();
            CustomerController.InitDBSomething();
            NavigateToCustomersGrid();
        }

        public void NavigateToEditCustomer(Customer customer)
        {
            Frame.Navigate(new EditCustomer(customer, this));
            SetProgramTitleText(EditCustomer.TITLE_TEXT);
        }

        public void NavigateToCustomersGrid()
        {
            Frame.Navigate(new CustomersGrid(this));
            SetProgramTitleText(CustomersGrid.TITLE_TEXT);
        }

        private void NavigateToNotificationsGrid()
        {
            Frame.Navigate(new NotificationsGrid());
            SetProgramTitleText(NotificationsGrid.TITLE_TEXT);
        }

        private void NavigateToAddCustomer()
        {
            Frame.Navigate(new NewCustomer(this));
            SetProgramTitleText(NewCustomer.TITLE_TEXT);
        }

        private void SetProgramTitleText(string text)
        {
            ProgramTitle.Text = text;
        }

        // Click Handlers
        private void CustomersGrid_ClickHandler(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigateToCustomersGrid();
        }

        private void NotificationsGrid_ClickHandler(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigateToNotificationsGrid();
        }

        private void AddCustomer_ClickHandler(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigateToAddCustomer();
        }

        private void ExcelExport_ClickHandler(object sender, System.Windows.RoutedEventArgs e)
        {
            List<Customer> customersList = CustomerController.GetCustomers();
            string appPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string fileName = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss", CultureInfo.InvariantCulture) + ".xlsx";
            ExcellExportController.CreateExcelDocument(customersList, appPath + "\\" + fileName);

            ShowMessageOnSuccessExport(appPath + "\\" + fileName);
        }

        private void ShowMessageOnSuccessExport(string filepath)
        {
            string message = "Файл можно найти по адресу:\n"+ filepath + "\n\nСкопировать путь до файла в буфер обмена?";
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(message, "Экспорт в Excel произведен успешно", MessageBoxButtons.YesNo);

            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                System.Windows.Clipboard.SetText(filepath);

        }
    }
}
