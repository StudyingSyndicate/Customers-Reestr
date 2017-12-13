using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            //DBUtil.CheckConnection(); // пока закомментировал, т.к. проверка подключения по автогенерируемой строке не работает сейчас
            //fillDataGrid2();
        }
   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Это твой исходный вариант, оставил просто чтобы тебе посмотреть разницу, можешь удалять
            // + Window_Loaded не вызывается по дефолту (видимо без объявления в xaml, поэтому сделал отдельные методы

            /* ObjectQuery<Customers> myTable = dataEntities.Customers;

            var query =
            from customer in myTable
            select new { customer.id, customer.name };

            clientsGrid.ItemsSource = query.ToList();*/
            var adapter = (IObjectContextAdapter)dataEntities;
            var objectContext = adapter.ObjectContext;
            ObjectSet<Customers> customers = objectContext.CreateObjectSet<Customers>();

            var query =
            from customer in customers
            select new { customer.name, customer.birthDate };

            clientsGrid.ItemsSource = query.ToList();
        }

        private void fillDataGrid()
        {
            /* ObjectSet<Customers> это по факту тоже самое что ObjectQuery<Customers>,
             * т.к. ObjectSet наследуется от ObjectQuery
             * все что выше это строки ( ObjectSet<Customers> customers = objectContext.CreateObjectSet<Customers>();)
             * нужно только для конвертации нашего dataEntities в какой-то волшебный ObjectContext,
             * который умеет делать .CreateObjectSet (я хз почему именно так)
             * вот ссылка по этому поводу https://stackoverflow.com/questions/27093849/how-do-i-convert-dbset-to-objectquery
             * и вот https://stackoverflow.com/questions/8059900/convert-dbcontext-to-objectcontext-for-use-with-gridview
             */
           
        }

        private void fillDataGrid2()
        {
            /* Это более краткий вариант записи
             * взял отсюда http://www.c-sharpcorner.com/uploadfile/raj1979/using-ado-net-entity-data-model-in-wpf/
             * но исходный вариант не работал
             * исходный: 
             * clientsGrid.ItemsSource = customers;
             * добавил .ToList<Customers>() и вроде взлетело
             * 
             * Похоже что тут где то есть маленький баг - в таблице под строкой с данными появляется одна пустая строка,
             * которой нет при заполнеии через метод fillDataGrid
             */
            IEnumerable<Customers> customers = (from p in dataEntities.Customers select p).Take(20);
            clientsGrid.ItemsSource = customers.ToList<Customers>();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
