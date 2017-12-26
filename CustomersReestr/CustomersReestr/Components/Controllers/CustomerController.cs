using System;
using System.Data.Entity;
using CustomersReestr.Components.Models;
using System.Linq;
using System.Collections.Generic;

namespace CustomersReestr.Components.Controllers
{
    class CustomerController
    {
        public static List<Customers> GetCustomers()
        {
            SetInitializerDropDbOnModelChange();
            CustomerContext db = new CustomerContext();
            db.Customers.Load();
            return db.Customers.Local.ToList();
        }

        public static void CreateNewCustomer(string name, string sex, string email, string phone, DateTime? birthDate)
        {
            SetInitializerDropDbOnModelChange();
            var myNewCustomer = new Customers
            {
                name = name,
                sex = sex,
                email = email,
                phone = phone,
                birthDate = birthDate,
                regDate = DateTime.Now
            };

            using (CustomerContext db = new CustomerContext())
            {
                db.Customers.Add(myNewCustomer);
                db.SaveChanges();
            }
        }

        private static void SetInitializerDropDbOnModelChange()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomerContext>());// строка нужна для очищения таблицы при изменении в customers.cs
        }
    }
}
