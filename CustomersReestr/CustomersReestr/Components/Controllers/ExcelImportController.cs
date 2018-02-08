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


        public void Import(String filepath, String importType)
        {
            // if you have Excel 2007 uncomment this line of code
            //  string excelConnectionString =string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0",path);

            string ExcelContentType = "application/vnd.ms-excel";
            string Excel2010ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            if (FileUpload1.HasFile)
            {
                //Check the Content Type of the file
                if (FileUpload1.PostedFile.ContentType == ExcelContentType || FileUpload1.PostedFile.ContentType == Excel2010ContentType)
                {
                    try
                    {
                        //Save file path
                        string path = string.Concat(Server.MapPath("~/TempFiles/"), FileUpload1.FileName);
                        //Save File as Temp then you can delete it if you want
                        FileUpload1.SaveAs(path);
                        //string path = @"C:\Users\Johnney\Desktop\ExcelData.xls";
                        //For Office Excel 2010  please take a look to the followng link  http://social.msdn.microsoft.com/Forums/en-US/exceldev/thread/0f03c2de-3ee2-475f-b6a2-f4efb97de302/#ae1e6748-297d-4c6e-8f1e-8108f438e62e
                        string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);

                        // Create Connection to Excel Workbook
                        using (OleDbConnection connection =
                                     new OleDbConnection(excelConnectionString))
                        {
                            OleDbCommand command = new OleDbCommand
                                    ("Select * FROM [Sheet1$]", connection);

                            connection.Open();

                            // Create DbDataReader to Data Worksheet
                            using (DbDataReader reader = command.ExecuteReader())
                            {
                                object[] meta = new object[100];

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
            }
        }

        private void ImportCustomerString(object[] values)
        {
            for (int i = 0; i < CUSTOMER_FIELDS_COUNT; i++)
            {
                Customer customer = new Customer
                {
                    Name = (String)values[1],
                    MiddleName = (String)values[2]
                    /// bla bla bla
                };

                CustomerController.SaveCustomer(customer);
            }
        }
    }
}
