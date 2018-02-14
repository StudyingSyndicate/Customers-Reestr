using System;
using System.Data.Common;
using System.Data.OleDb;

namespace CustomersReestr.Components.Controllers
{
    class ExcelImportController
    {
        public const String IMPORT_TYPE_CUSTOMER = "Customer";

        public static void Import(String filepath, String importType)
        {
            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", filepath);

            // Create Connection to Excel Workbook
            using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
            {
                OleDbCommand command = new OleDbCommand("Select * FROM [Table1$]", connection);

                connection.Open();

                // Create DbDataReader to Data Worksheet
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        switch(importType)
                        {
                            case IMPORT_TYPE_CUSTOMER:
                                CustomerController.ImportCustomerString(reader);
                                break;
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
