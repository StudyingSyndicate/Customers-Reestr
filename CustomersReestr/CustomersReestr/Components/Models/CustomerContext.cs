using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CustomersReestr.Components.Models
{
    class CustomerContext : DbContext
    {
        public CustomerContext() : base("CustomersEntities")
        {

        }
        public DbSet<Customers> Customers { get; set; }
    }
}
