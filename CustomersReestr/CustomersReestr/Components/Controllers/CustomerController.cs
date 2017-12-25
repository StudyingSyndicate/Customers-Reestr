using System;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;

namespace CustomersReestr.Components.Controllers
{
    class CustomerController
    {
        public static IQueryable GetCustomers()
        {
            var dataEntities = new CustomersEntities();
            var adapter = (IObjectContextAdapter)dataEntities;
            var objectContext = adapter.ObjectContext;
            ObjectSet<Customers> customers = objectContext.CreateObjectSet<Customers>();

            var query =
            from customer in customers
            select new { customer.name, customer.birthDate };

            return query;
        }

        public static void CreateNewCustomer(string name)
        {
            var myNewCustomer = new Customers
            {
                name = name,
                id = 2,                         // айдишники по идее сама модель должна генерить автоматом, надо ковырять как это правильно делается
                Id = 2,
                regDate = new DateTime(2017,12,25),         // эту дату надо брать автоматом текущую, не стал пока заморачиваться
                birthDate = new DateTime(2000, 12, 25)      // эту дату надо будет прокидывать из формы создания, по аналогии с именем
            };
            
            /** Это сделал по двум примерам:
            * http://www.entityframeworktutorial.net/save-entity-in-entity-framework.aspx
            * https://stackoverflow.com/questions/8835434/insert-data-using-entity-framework-model */
            using (var context = new CustomersEntities())
            {
                context.Customers.Add(myNewCustomer);
                context.SaveChanges();
            }
        }
    }
}
