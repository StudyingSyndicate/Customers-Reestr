using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
