using CustomersReestr.Components.Models;
using CustomersReestr.Components.Utils;
using System;
using System.Data.Common;
using System.Data.OleDb;

namespace CustomersReestr.Components.Controllers
{
    class ExcelImportController
    {
        public const string IMPORT_TYPE_CUSTOMER = "Customer";

        private const string EXCEL_CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0";

        public static void Import(String filepath, String importType)
        {
            string excelConnectionString = string.Format(EXCEL_CONNECTION_STRING, filepath);
            
            using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
            {
                OleDbCommand command = new OleDbCommand("Select * FROM [Table1$]", connection);

                connection.Open();
                
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        switch(importType)
                        {
                            case IMPORT_TYPE_CUSTOMER:
                                ImportCustomerString(reader);
                                break;
                        }
                    }
                }

                connection.Close();
            }
        }

        private static void ImportCustomerString(DbDataReader reader)
        {
            Customer customer = CustomerController.FindCustomerByGuid(SafeGetString(reader,9));
            if (customer == null)
            {
                customer = new Customer();
            }

            customer.Name =         SafeGetString(reader, 1);
            customer.MiddleName =   SafeGetString(reader, 2);
            customer.LastName =     SafeGetString(reader, 3);
            customer.Sex =          SafeGetString(reader, 4);
            customer.Email =        SafeGetString(reader, 5);
            customer.Phone =        SafeGetString(reader, 6);
            customer.BirthDate = DateHelper.ParseRusDateTime(SafeGetString(reader, 7));
            
            CustomerController.SaveEntity(customer);
        }

        private static string SafeGetString(DbDataReader reader, int orderNumber)
        {
            string result = "";
            if (reader[orderNumber] != DBNull.Value)
            {
                result = reader.GetString(orderNumber);
            }
            return result;
        }
    }
}
