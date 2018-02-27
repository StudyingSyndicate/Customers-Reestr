using System;
using System.Windows.Controls;
using System.Windows.Forms;
using CustomersReestr.Components.Controllers;
using CustomersReestr.Components.Models;

namespace CustomersReestr
{
    public partial class NewCustomer : Page
    {
        public static string TITLE_TEXT = "Добавить клиента";

        private MainWindow mainWindow;

        public NewCustomer(MainWindow inputMainWindow)
        {
            InitializeComponent();
            mainWindow = inputMainWindow;
        }

        private void ClearBoxes()
        {
            Field_Name.Clear();
            Field_MiddleName.Clear();
            Field_LastName.Clear();
            Field_Sex.SelectedIndex = 0;
            Field_Email.Clear();
            Field_Phone.Clear();
            Field_BirthDate.SelectedDate = null;
        }

        private void OnSaveBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Field_Name.Text == ""
                || Field_LastName.Text == ""
                || Field_Sex.Text == ""
                || Field_BirthDate.SelectedDate == null)
            {
                MessageBox.Show("Заполните обязательные поля, отмеченныe '*'.");
            }
            else
            {
                var myNewCustomer = new Customer
                {
                    Name = Field_Name.Text,
                    MiddleName = Field_MiddleName.Text,
                    LastName = Field_LastName.Text,
                    Sex = Field_Sex.Text,
                    Email = Field_Email.Text,
                    Phone = Field_Phone.Text,
                    BirthDate = Field_BirthDate.SelectedDate ?? DateTime.Now,
                    RegDate = DateTime.Now,
                    LastModified = DateTime.Now
                };

                CustomerController.SaveEntity(myNewCustomer);
                ShowMessageAfterSave();
            }
        }

        private void ShowMessageAfterSave()
        {
            string message = "Клиент добавлен.\nХотите добавить еще одного клиента?";
            DialogResult dialogResult = MessageBox.Show(message, "Информация", MessageBoxButtons.YesNo);
            
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    ClearBoxes();
                    break;

                case DialogResult.No:
                    mainWindow.NavigateToCustomersGrid();
                    break;
            }
        }
    }
}
