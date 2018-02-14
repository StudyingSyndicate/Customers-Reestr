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
using System.Data.Entity.Migrations;
using System.Data.Common;
using CustomersReestr.Components.Utils;

namespace CustomersReestr.Components.Controllers
{
    class CustomerController
    {
        public static List<Customer> GetCustomers()
        {
            SetInitializerDropDbOnModelChange();
            return GetCustomersInternal().ToList();
        }

        public static void CreateNewCustomer(string name, string middleName, string lastName, string sex, string email, string phone, DateTime birthDate)
        {
            SetInitializerDropDbOnModelChange();
            var myNewCustomer = new Customer
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
                try
                {
                    db.Customers.Add(myNewCustomer);
                    db.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                    throw;
                }
            }
        }

        public static void SaveCustomer(Customer customer)
        {
            using (CustomerContext db = new CustomerContext())
            {
                customer.LastModified = DateTime.Now;

                db.Customers.Attach(customer);
                db.Entry(customer).State = EntityState.Modified;
                try
                {
                    
                    db.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                    throw;
                }
            }
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
        public static void ImportCustomerString(DbDataReader reader)
        {
            string Name = reader.GetString(1);
            string MiddleName = reader.GetString(2);
            string LastName = reader.GetString(3);
            string Sex = reader.GetString(4);
            string Email = reader.GetString(5);
            string Phone = reader.GetString(6);
            DateTime BirthDate = DateHelper.ParseRusDateTime(reader.GetString(7));
            Guid guid = Guid.Parse(reader.GetString(8));
            using (CustomerContext db = new CustomerContext())
            {
                Customer customer = db.Customers.Find(guid);
                if (customer != null)
                {
                    db.Customers.Attach(customer);
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                }


                else
                    CustomerController.CreateNewCustomer(Name, MiddleName, LastName, Sex, Email, Phone, BirthDate);
            }
        }
    }
}
