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

            return settings != null ? settings.ConnectionString : null;
        }
        public static void CheckConnection()
        {
            SqlConnection cnn;
            cnn = new SqlConnection(GetConnectionString());
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! Error: " + ex.Message);
                throw ex;
            }
        }
    }

}
