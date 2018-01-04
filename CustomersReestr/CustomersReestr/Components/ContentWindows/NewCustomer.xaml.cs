using System;
using System.Windows;
using System.Windows.Controls;
using CustomersReestr.Components.Controllers;

namespace CustomersReestr
{
    public partial class NewCustomer : Page
    {
        public static string TITLE_TEXT = "Добавить клиента";

        public NewCustomer()
        {
            InitializeComponent();
        }

        private void ClearBoxes()
        {
            Field_Name.Clear();
            Field_MiddleName.Clear();
            Field_LastName.Clear();
            Field_Sex.SelectedItem = null;
            Field_Email.Clear();
            Field_Phone.Clear();
            Field_BirthDate.SelectedDate = null;
        }

        private void OnSaveBtnClick(object sender, RoutedEventArgs e)
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
                CustomerController.CreateNewCustomer(
                               Field_Name.Text,
                               Field_MiddleName.Text,
                               Field_LastName.Text,
                               Field_Sex.Text,
                               Field_Email.Text,
                               Field_Phone.Text,
                               Field_BirthDate.SelectedDate ?? DateTime.Now);
                MessageBox.Show("Клиент добавлен");
                ClearBoxes();
            }
        }
    }
}
