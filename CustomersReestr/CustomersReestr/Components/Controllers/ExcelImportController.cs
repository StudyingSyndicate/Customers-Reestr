using CustomersReestr.Components.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomersReestr.Components.Controllers
{
    class ExcelImportController
    {
        private const int CUSTOMER_FIELDS_COUNT = 7;

        public const String IMPORT_TYPE_CUSTOMER = "Customer";


        public static void Import(String filepath, String importType)
        {
                       
                    try
                    {
                        
                        string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", filepath);

                        // Create Connection to Excel Workbook
                        using (OleDbConnection connection =
                                     new OleDbConnection(excelConnectionString))
                        {
                            OleDbCommand command = new OleDbCommand
                                    ("Select * FROM [Table1$]", connection);

                            connection.Open();

                            // Create DbDataReader to Data Worksheet
                            using (DbDataReader reader = command.ExecuteReader())
                            {
                                object[] meta = new object[10];

                                while (reader.HasRows)
                                {
                                    reader.Read();
                                    reader.GetValues(meta);
                                    switch(importType)
                                    {
                                        case IMPORT_TYPE_CUSTOMER:
                                            ImportCustomerString(meta);
                                            break;
                                        default:
                                            break;
                                    }
                                }


                                // SQL Server Connection String
                                /*string sqlConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=ExcelDB;Integrated Security=True";

                                // Bulk Copy to SQL Server
                                using (SqlBulkCopy bulkCopy =
                                           new SqlBulkCopy(sqlConnectionString))
                                {
                                    bulkCopy.DestinationTableName = "Employee";
                                    bulkCopy.WriteToServer(dr);
                                    Label1.Text = "The data has been exported succefuly from Excel to SQL";
                                }*/
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла ошибка: " + ex.Message);
                    }
                
        }

        private static void ImportCustomerString(object[] values)
        {
            for (int i = 0; i < CUSTOMER_FIELDS_COUNT; i++)
            {
                Customer customer = new Customer
                {
                    Name = (String)values[1],
                    MiddleName = (String)values[2],
                    LastName = (String)values[3],
                    Sex = (String)values[4],
                    Email = (String)values[5],
                    Phone = (String)values[6],
                   

                };

                CustomerController.SaveCustomer(customer);
            }
        }
    }
}
