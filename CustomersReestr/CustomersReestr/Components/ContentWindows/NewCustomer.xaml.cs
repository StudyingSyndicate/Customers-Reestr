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

        private void OnSaveBtnClick(object sender, RoutedEventArgs e)
        {
            CustomerController.CreateNewCustomer(InputTextField_Name.Text);
        }
    }
}
