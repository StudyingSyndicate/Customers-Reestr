using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace CustomersReestr
{
    class DBUtil
       
    {
        public static void CheckConnection()
        {
            MessageBox.Show("DB Connected!!");
        }
    }
}
