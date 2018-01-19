using CustomersReestr.Components.Controllers;
using System.Windows.Controls;

namespace CustomersReestr.Components.ContentWindows
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class NotificationsGrid : Page
    {

        public static string TITLE_TEXT = "Реестр уведомлений";

        public NotificationsGrid()
        {
            InitializeComponent();
            FillGrid();
        }

        private void FillGrid()
        {
            grid.ItemsSource = CustomerController.GetNotifications();
        }
    }
}
