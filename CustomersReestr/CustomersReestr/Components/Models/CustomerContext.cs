using System.Data.Entity;

namespace CustomersReestr.Components.Models
{
    class CustomerContext : DbContext
    {
        public CustomerContext() : base("CustomersReestr.Properties.Settings.CustomersConnectionString")
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
