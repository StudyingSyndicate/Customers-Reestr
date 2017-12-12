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
using System.Collections;
using System.Data.SqlClient;
using System.Data.Objects;
using System.Data;

namespace CustomersReestr
{
    /// <summary>
    /// Логика взаимодействия для MainTable.xaml
    /// </summary>
    public partial class MainTable : Page
    {
        CustomersEntities dataEntities = new CustomersEntities();


        public MainTable()
        {
            InitializeComponent();
            DBUtil.CheckConnection();
                      
        }
   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectQuery<Customers> myTable = dataEntities.Customers;

            var query =
            from customer in myTable
            select new { customer.id, customer.name };

            clientsGrid.ItemsSource = query.ToList();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
