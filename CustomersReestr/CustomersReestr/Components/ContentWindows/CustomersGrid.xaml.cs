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
            Database.SetInitializer(
               new DropCreateDatabaseIfModelChanges<CustomerContext>());
            InitializeComponent();
             CustomerContext db;
            db = new CustomerContext();
            db.Customers.Load(); 
            cusgrid.ItemsSource = db.Customers.Local.ToList(); 

            
        }
   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
           
        }

       
    }
}
