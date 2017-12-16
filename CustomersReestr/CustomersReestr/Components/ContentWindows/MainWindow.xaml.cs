using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomersReestr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CustomersGrid_ClickHandler(object sender, RoutedEventArgs e)
        {
            SetFrameSource("CustomersGrid.xaml");
            SetProgramTitleText(btnCustomersGridLabel.Text);
        }

        private void NotificationsGrid_ClickHandler(object sender, RoutedEventArgs e)
        {
            SetFrameSource("NotificationsGrid.xaml");
            SetProgramTitleText(btnNotificationsGridLabel.Text);
        }

        private void AddCustomer_ClickHandler(object sender, RoutedEventArgs e)
        {
            SetFrameSource("NewCustomer.xaml");
            SetProgramTitleText(btnNewCustomerLabel.Text);
        }

        private void SetProgramTitleText(string text)
        {
            ProgramTitle.Text = text;
        }

        private void SetFrameSource(string filename)
        {
            Frame.Source = new Uri(filename, UriKind.Relative);
        }
    }
}
