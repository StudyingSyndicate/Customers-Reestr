using CustomersReestr.Components.Controllers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CustomersReestr.Components.Models;
using System.Data.Entity;

namespace CustomersReestr
{
    /// <summary>
    /// Логика взаимодействия для MainTable.xaml
    /// </summary>
    public partial class CustomersGrid : Page
    {
      
        public CustomersGrid()

        {
            CustomerContext db;
            InitializeComponent();
            db = new CustomerContext();
            db.Customers.Load(); // загружаем данные
            cusgrid.ItemsSource = db.Customers.Local.ToBindingList(); // устанавливаем привязку к кэшу

           

        }
   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
           
        }

       
    }
}
