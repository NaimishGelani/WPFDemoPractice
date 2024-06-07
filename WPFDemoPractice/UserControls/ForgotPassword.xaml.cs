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
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : UserControl
    {
        public ForgotPassword()
        {
            InitializeComponent();
            ForgotPasswordViewModel forgotPasswordViewModel = new();
            this.DataContext = forgotPasswordViewModel;
            forgotPasswordViewModel.ChangeWindowEvent += ChangeWindow;
        }

        public void ChangeWindow(object? sender, EventArgs e)
        {
            LoginPage loginPage = new();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);

            if (mainWindow != null)
            {
                if (mainWindow.mainContent != null)
                {
                    mainWindow.mainContent.Content = loginPage;
                }
            }
        }

        private void ForgotButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.mainContent.Content = new LoginPage();
        }
    }
}
