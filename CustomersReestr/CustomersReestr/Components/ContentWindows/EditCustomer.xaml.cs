using System;
using System.Windows.Forms;
using System.Windows.Controls;
using CustomersReestr.Components.Controllers;
using CustomersReestr.Components.Models;

namespace CustomersReestr
{
    public partial class EditCustomer : Page
    {
        public static string TITLE_TEXT = "Редактировать клиента";

        private Customer currentCustomer;
        private MainWindow mainWindow;

        public EditCustomer(Customer customer, MainWindow inputMainWindow)
        {
            InitializeComponent();
            SetFields(customer);
            mainWindow = inputMainWindow;
        }

        private void SetFields(Customer customer)
        {
            currentCustomer = customer;

            Label_ClientNumber.Content = "Клиент №" + customer.Id;
            Field_Name.Text = currentCustomer.Name;
            Field_MiddleName.Text = currentCustomer.MiddleName;
            Field_LastName.Text = currentCustomer.LastName;
            Field_Sex.SelectedValue = currentCustomer.Sex;
            Field_Email.Text = currentCustomer.Email;
            Field_Phone.Text = currentCustomer.Phone;
            Field_BirthDate.SelectedDate = currentCustomer.BirthDate;
        }

        private void DeleteCustomer (Customer customer)
        {
            string message = "Вы уверены,что хотите удалить клиента?";
            DialogResult dialogResult = MessageBox.Show(message, "Информация", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                CustomerController.DeleteEntity(customer);
                MessageBox.Show("Запись удалена");
            }
        }

        private Customer GetCustomer()
        {
            if (currentCustomer.Name != Field_Name.Text)
            {
                currentCustomer.Name = Field_Name.Text;
            }
            if (currentCustomer.MiddleName != Field_MiddleName.Text)
            {
                currentCustomer.MiddleName = Field_MiddleName.Text;
            }
            if (currentCustomer.LastName != Field_LastName.Text)
            {
                currentCustomer.LastName = Field_LastName.Text;
            }
            if (currentCustomer.Sex != Field_Sex.Text)
            {
                currentCustomer.Sex = Field_Sex.Text;
            }
            if (currentCustomer.Email != Field_Email.Text)
            {
                currentCustomer.Email = Field_Email.Text;
            }
            if (currentCustomer.Phone != Field_Phone.Text)
            {
                currentCustomer.Phone = Field_Phone.Text;
            }
            if (currentCustomer.BirthDate != Field_BirthDate.SelectedDate)
            {
                currentCustomer.BirthDate = Field_BirthDate.SelectedDate ?? DateTime.Now;
            }
            return currentCustomer;
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
                Customer customer = GetCustomer();
                CustomerController.SaveEntity(customer);

                ShowMessageAfterSave();
            }

        }

        private void ShowMessageAfterSave()
        {
            string message = "Клиент отредактирован.\nХотите открыть реестр клиентов?";
            DialogResult dialogResult = MessageBox.Show(message, "Информация", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                mainWindow.NavigateToCustomersGrid();
            }
        }

        private void OnDelBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Customer customer = GetCustomer();
            DeleteCustomer(customer);
            mainWindow.NavigateToCustomersGrid();
        }
    }
}
