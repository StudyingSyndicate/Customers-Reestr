using System.Windows;
using System.Windows.Controls;
using CustomersReestr.Components.Controllers;

namespace CustomersReestr
{
    public partial class NewCustomer : Page
    {
        public NewCustomer()
        {

            InitializeComponent();

        }
        private void ClearBoxes()
        {
            InputTextField_Name.Clear();
            InputTextField_Email.Clear();
            InputTextField_Phone.Clear();
            DateTimePicker_BirthDate.Text = null;
            ComboInputPicker_Sex.Text = null;
        }
        private void OnSaveBtnClick(object sender, RoutedEventArgs e)
        {
            if (InputTextField_Name.Text == "" 
                || ComboInputPicker_Sex.Text == "" 
                || InputTextField_Email.Text == "" 
                || InputTextField_Phone.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                CustomerController.CreateNewCustomer(
                               InputTextField_Name.Text,
                               InputTextField_MiddleName.Text,
                               InputTextField_LastName.Text,
                               ComboInputPicker_Sex.Text,
                               InputTextField_Email.Text,
                               InputTextField_Phone.Text,
                               DateTimePicker_BirthDate.SelectedDate);
                MessageBox.Show("Клиент добавлен");
                ClearBoxes();
            }

        }
    }
}
