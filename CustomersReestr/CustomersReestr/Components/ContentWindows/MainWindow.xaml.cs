using CustomersReestr.Components.ContentWindows;
using CustomersReestr.Components.Controllers;
using CustomersReestr.Components.Models;
using System.Windows;
using System.Windows.Controls;

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

        public void NavigateToEditCustomer(Customers customer)
        {
            Frame.Navigate(new EditCustomer(customer));
            SetProgramTitleText(EditCustomer.TITLE_TEXT);
        }

        private void NavigateToCustomersGrid()
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
            Frame.Navigate(new NewCustomer());
            SetProgramTitleText(NewCustomer.TITLE_TEXT);
        }

        private void SetProgramTitleText(string text)
        {
            ProgramTitle.Text = text;
        }

        // Click Handlers
        private void CustomersGrid_ClickHandler(object sender, RoutedEventArgs e)
        {
            NavigateToCustomersGrid();
        }

        private void NotificationsGrid_ClickHandler(object sender, RoutedEventArgs e)
        {
            NavigateToNotificationsGrid();
        }

        private void AddCustomer_ClickHandler(object sender, RoutedEventArgs e)
        {
            NavigateToAddCustomer();
        }
    }
}
