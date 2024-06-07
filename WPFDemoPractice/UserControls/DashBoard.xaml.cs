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
using WPFDemoPractice.Converter;
using WPFDemoPractice.ViewModel;

namespace WPFDemoPractice.UserControls
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();
            StudentFormViewModel studentFormViewModel = new StudentFormViewModel();
            this.DataContext = studentFormViewModel;
        }

        private void Clear()
        {
            TextBoxStudentName.Text = "";
            TextBoxAddress.Text = "";
            TextBoxAge.Text = "";
            TextBoxFatherName.Text = "";
            TextBoxSurname.Text = "";
            TextBoxStandard.Text = "";
            DoBDatePicker.Text = "";
            TextBoxContact.Text = "";
        }

        private void CreateEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void ReadEmployeesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
