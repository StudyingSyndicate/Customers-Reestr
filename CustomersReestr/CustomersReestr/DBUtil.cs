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
             
            string returnValue = null;

            
            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["CustomersReestr.Properties.Settings.CustomersConnectionString"];

            
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
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
                MessageBox.Show("Can not open connection ! ");
            }
        }
    }

}
