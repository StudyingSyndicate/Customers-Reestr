using CustomersReestr.Components.ContentWindows;
using CustomersReestr.Components.Controllers;
using CustomersReestr.Components.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

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
            //ProgramTitle.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Resources/Fonts/#Cotlin");
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
            try
            {
                string folder = FileController.GetFolderFromChooserDialog();
                bool result = ExcellExportController.CustomersExportToExcel(folder);
                if (result)
                    ShowMessageOnSuccessExport();
            }
            catch (ArgumentException exc) when (exc.ParamName == FileController.NULL_FOLDER_ERROR)
            {
                System.Windows.MessageBox.Show("Не задана папка для экспорта.", "Ошибка");
                return;
            }
            catch (ArgumentException exc) when (exc.ParamName == ExcellExportController.EXCEL_EXPORT_ERROR)
            {
                System.Windows.MessageBox.Show("Не удалось выполнить экспорт.", "Ошибка");
                return;
            }
        }
        
        private void ShowMessageOnSuccessExport()
        {
            System.Windows.Forms.MessageBox.Show("Экспорт в Excel произведен успешно", "Экспорт в Excel", MessageBoxButtons.OK);
        }

        private  void ExcelImport_ClickHandler(object sender, RoutedEventArgs e)
        {
            FileController.ImportFileExcel();

        }
    }
}
