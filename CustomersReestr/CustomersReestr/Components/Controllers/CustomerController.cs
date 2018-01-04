using System;
using System.Data.Entity;
using CustomersReestr.Components.Models;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Data;

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

        public static void CreateNewCustomer(string name, string middleName, string lastName, string sex, string email, string phone, DateTime birthDate)
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
                RegDate = DateTime.Now,
                LastModified  = DateTime.Now
            };

            using (CustomerContext db = new CustomerContext())
            {
                db.Customers.Add(myNewCustomer);
                db.SaveChanges();
            }
        }

        public static void SaveCustomer(Customers customer)
        {
            using (CustomerContext db = new CustomerContext())
            {
                customer.LastModified = DateTime.Now;

                db.Customers.Attach(customer);
                db.Entry(customer).State = EntityState.Modified;
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
