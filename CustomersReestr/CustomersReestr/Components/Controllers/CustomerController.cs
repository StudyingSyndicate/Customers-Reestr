using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using CustomersReestr.Components.Models;


namespace CustomersReestr.Components.Controllers
{
    class CustomerController
    {
       

        public static void CreateNewCustomer(string name, string sex, string email, string phone, DateTime? birthDate)
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<CustomerContext>());
            var myNewCustomer = new Customers
            {

                name = name,
                sex = sex,
                email = email,
                phone = phone,
                birthDate =  birthDate,

                regDate = DateTime.Now,         
            };
            
            
            using (CustomerContext db = new CustomerContext())
            {
                db.Customers.Add(myNewCustomer);
                db.SaveChanges();
            }
        }
    }
}
