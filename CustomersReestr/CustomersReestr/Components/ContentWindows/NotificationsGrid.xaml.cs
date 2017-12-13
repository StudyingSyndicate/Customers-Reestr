using System;
using System.Collections.Generic;
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

namespace CustomersReestr.Components.ContentWindows
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class NotificationsGrid : Page
    {

        CustomersEntities dataEntities = new CustomersEntities();

        public NotificationsGrid()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<Customers> customers = (from p in dataEntities.Customers select p).Take(20);
            grid.ItemsSource = customers.ToList<Customers>();
        }
    }
}
