using CustomersReestr.Components.ContentWindows;
using CustomersReestr.Components.Controllers;
using CustomersReestr.Components.Models;
using System;
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
        const string exceltype = "Файлы Excel (*.xls; *.xlsx) | *.xls; *.xlsx";
        const string defaultfilename = "Document";
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
            }
            catch (ArgumentException exc) when (exc.ParamName == ExcellExportController.EXCEL_EXPORT_ERROR)
            {
                System.Windows.MessageBox.Show("Не удалось выполнить экспорт.", "Ошибка");
            }
        }
        
        private void ShowMessageOnSuccessExport()
        {
            System.Windows.Forms.MessageBox.Show("Экспорт в Excel произведен успешно", "Экспорт в Excel", MessageBoxButtons.OK);
        }
        
        private  void ExcelImport_ClickHandler(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = defaultfilename; // Default file name
                dlg.Filter = exceltype; // Filter files by extension

                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    ExcelImportController.Import(dlg.FileName, ExcelImportController.IMPORT_TYPE_CUSTOMER);
                    ShowMessageOnSuccessImport(dlg.FileName);
                    NavigateToCustomersGrid();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Не удалось выполнить импорт.\nТекст ошибки: " + ex.Message, "Ошибка");
            }
        }

        private void ShowMessageOnSuccessImport(string filename)
        {
            System.Windows.Forms.MessageBox.Show("Клиенты из файла '" + filename + "' успешно загружены.", "Импорт из Excel", MessageBoxButtons.OK);
        }
    }
}
