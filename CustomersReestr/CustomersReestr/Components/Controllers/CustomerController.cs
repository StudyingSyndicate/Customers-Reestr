using System;
using System.Data.Entity;
using CustomersReestr.Components.Models;
using System.Linq;
using System.Collections.Generic;
using System.IO;

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

        public static void CreateNewCustomer(string name, string middleName, string lastName, string sex, string email, string phone, DateTime? birthDate)
        {
            SetInitializerDropDbOnModelChange();
            var myNewCustomer = new Customers
            {
                Name = name,
                MiddleName = middleName,
                LastName = lastName,
                Sex = sex,
                Email = email,
                Phone = phone,
                BirthDate = birthDate,
                RegDate = DateTime.Now
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

        /// Убрать в продакшн коде
        public static void InitDBSomething()
        {
            string relative = @"..\..\Customers.mdf";
            string absolute = Path.GetFullPath(relative);
            absolute = Path.GetDirectoryName(@absolute);
            AppDomain.CurrentDomain.SetData("DataDirectory", absolute);
        }
    }
}
