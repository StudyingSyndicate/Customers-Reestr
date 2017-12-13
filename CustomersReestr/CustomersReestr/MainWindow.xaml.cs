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

namespace CustomersReestr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClientsGrid_ClickHandler(object sender, RoutedEventArgs e)
        {
            Frame.Source = new Uri("MainTable.xaml", UriKind.Relative);
        }

        private void NotificationsGrid_ClickHandler(object sender, RoutedEventArgs e)
        {
            //Frame.Source = new Uri("NewCustomer.xaml", UriKind.Relative);
        }

        private void AddClient_ClickHandler(object sender, RoutedEventArgs e)
        {
            Frame.Source = new Uri("NewCustomer.xaml", UriKind.Relative);
        }
    }
}
