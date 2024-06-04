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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : UserControl
    {
        public Registration()
        {
            InitializeComponent();
            RegistrationViewModel registrationViewModel = new RegistrationViewModel();
            this.DataContext = registrationViewModel;
            registrationViewModel.ChangeWindowEvent += ChangeWindow;
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

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonReSet_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        public void Close()
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Close();
        }

        public void Reset()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            passwordBox1.Text = "";
            passwordBoxConfirm.Text = "";
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonLoginPage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.mainContent.Content = new LoginPage();
        }

    }
}
