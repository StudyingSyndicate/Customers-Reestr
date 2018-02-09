using System;
using System.Globalization;
using System.Windows.Forms;

namespace CustomersReestr.Components.Controllers
{
    class FileController
    {
        public const string NULL_FOLDER_ERROR = "nullFolderError";

        public static string GetFolderFromChooserDialog()
        {
            string result = null;
            bool isNotCancelClicked;
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult dialogResult = dialog.ShowDialog();
                if (dialogResult == DialogResult.OK && !string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    result = dialog.SelectedPath;
                }

                isNotCancelClicked = (dialogResult != DialogResult.Cancel);
            }
            if (string.IsNullOrEmpty(result) && isNotCancelClicked)
                throw new ArgumentException("", NULL_FOLDER_ERROR);

            return result;
        }

        public static string GetFileNameCurrentDateTime(string fileFormat)
        {
            if (!string.IsNullOrEmpty(fileFormat))
                fileFormat = "." + fileFormat;
            return DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss", CultureInfo.InvariantCulture) + fileFormat;
        }

        public static void ImportFileExcel()
        {

            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.Filter = "Файлы Excel (*.xls; *.xlsx) | *.xls; *.xlsx"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                ExcelImportController.Import(dlg.FileName, ExcelImportController.IMPORT_TYPE_CUSTOMER);
                
            }

            
        }
    }
}
