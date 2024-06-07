using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFDemoPractice.ViewModel;

namespace WPFDemoPractice.UserControls
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            InitializeComponent();
            LoginViewModel loginViewModel = new LoginViewModel();   
            this.DataContext = loginViewModel;
            textBoxEmail.Text = "Enter a EmailId..";
            textBoxEmail.GotFocus += RemoveText;
            textBoxEmail.LostFocus +=AddText;
            loginViewModel.ChangeWindowEvent += ChangeWindow;
        }

        public void ChangeWindow(object? sender, EventArgs e)
        {
            DashBoard dashBoard = new();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (mainWindow != null)
            {
                if (mainWindow.mainContent != null)
                {
                    mainWindow.mainContent.Content = dashBoard ;
                }
            }
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "Enter a EmailId..")
            {
                textBoxEmail.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
                textBoxEmail.Text = "Enter a EmailId..";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

        }


        private void ButtonRegisterPage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow) Window.GetWindow(this);
            mainWindow.mainContent.Content = new Registration();
        }

        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.mainContent.Content = new ForgotPassword();
        }
    }
}
