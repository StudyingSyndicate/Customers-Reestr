using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Configuration;

namespace CustomersReestr
{
    class DBUtil
       
    {
        
        internal static string GetConnectionString()
        {
            ConnectionStringSettings settings =
            //ConfigurationManager.ConnectionStrings["CustomersReestr.Properties.Settings.CustomersConnectionString"];
            ConfigurationManager.ConnectionStrings["CustomersEntities"];

            return settings?.ConnectionString;
        }
    }

}
