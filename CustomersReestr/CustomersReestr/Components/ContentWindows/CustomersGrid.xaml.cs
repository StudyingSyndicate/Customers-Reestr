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
    public partial class CustomersGrid : Page
    {
      
        public CustomersGrid()

        {
            InitializeComponent();
            /* Нерабочий код. Пока убрал, потом разберемся с этим
             * Вернул как было
             * 
             * CustomerContext db;
            db = new CustomerContext();
            db.Customers.Load(); // загружаем данные
            cusgrid.ItemsSource = db.Customers.Local.ToBindingList(); // устанавливаем привязку к кэшу*/

            cusgrid.ItemsSource = CustomerController.GetCustomers();
        }
   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
           
        }

       
    }
}
