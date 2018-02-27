using System;
using System.Data.Entity;
using CustomersReestr.Components.Models;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomersReestr.Components.Controllers
{
    class CustomerController
    {
        public static List<Customer> GetCustomers()
        {
            SetInitializerDropDbOnModelChange();
            return GetCustomersInternal().ToList();
        }
             
        public static Customer SaveEntity(Customer customer)
        {
            using (CustomerContext db = new CustomerContext())
            {
                if (customer.Id != 0)
                {
                    db.Customers.Attach(customer);
                    db.Entry(customer).State = EntityState.Modified;
                }
                else
                {
                    customer.RegDate = DateTime.Now;
                    customer.LastModified = DateTime.Now;

                    db.Customers.Add(customer);
                }

                db.SaveChanges();
            }
            return customer;
        }

        public static Customer FindCustomerByGuid(string guidString)
        {
            Customer customer = null;

            if (String.IsNullOrEmpty(guidString))
                return customer;

            Guid guid = Guid.Parse(guidString);
            using (CustomerContext db = new CustomerContext())
            {
                customer = db.Customers.Find(guid);
            }
            return customer;
        }

        public static ListCollectionView GetNotifications()
        {
            List<Customer> customersList = GetCustomersInternal().ToList();
            ListCollectionView collectionView = new ListCollectionView(customersList);

            collectionView.SortDescriptions.Clear();
            collectionView.SortDescriptions.Add(new SortDescription("NextBirthDate", ListSortDirection.Ascending));

            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("NextBirthDate"));
            return collectionView;
        }

        private static IQueryable<Customer> GetCustomersInternal(string sort = "")
        {
            CustomerContext db = new CustomerContext();
            db.Customers.Load();

            IQueryable<Customer> customers = from customer in db.Customers
                                              select customer;

            customers = SorCustomers(customers, sort);

            return customers;
        }

        private static IQueryable<Customer> SorCustomers(IQueryable<Customer> customers, string sort)
        {
            switch (sort)
            {
                /*case "nextBirthDate":
                    customers = customers.OrderBy(c => c.NextBirthDate).ThenByDescending(c => c.Id);
                    break;*/
                default:
                    customers = customers.OrderByDescending(c => c.Id);
                    break;
            }
            return customers;
        }

        /// Убрать в продакшн коде
        /// нужно для очищения таблицы при изменении в customers.cs
        private static void SetInitializerDropDbOnModelChange()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomerContext>());
        }

        /// Убрать в продакшн коде
        /// нужно для использования базы данных из гита, а не созданной приложением
        public static void InitDBSomething()
        {
            string relative = @"..\..\Customers.mdf";
            string absolute = Path.GetFullPath(relative);
            absolute = Path.GetDirectoryName(@absolute);
            AppDomain.CurrentDomain.SetData("DataDirectory", absolute);
        }
    }
}
