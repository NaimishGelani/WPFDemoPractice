using Microsoft.Data.SqlClient;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Data;
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
using WPFDemoPractice.UserControls;

namespace WPFDemoPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainContent.Content = new LoginPage();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // if (txtSearch.Text != "")
            // {

            //     txtSearch.Text = "FirstName";

            //= Visibility.Hidden;

            // }
            // else
            // {

            //     txtSearchPlaceholder.Visibility

            // = Visibility.Visible;

            // }
        }



        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //1.address of thr sql server and database.
        //    string connectionString = "Data Source=PCA63\\SQL2022;Initial Catalog=WPFDemo;Integrated Security=True;TrustServerCertificate=True";

        //    //2.establish connection.
        //    SqlConnection con = new SqlConnection(connectionString);

        //    //3.open connection.
        //    con.Open();

        //    //4.prepare query.
        //    string firstName = tbFirstName.Text;
        //    string lastname = tbLastName.Text;

        //    if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastname))
        //    {
        //        MessageBox.Show("please fill data....");
        //        errormessage.Text = "Enter an data.";
        //        tbFirstName.Focus();
        //        con.Close();
        //    }
        //    else
        //    {
        //        string querySelect = "SELECT * FROM Names WHERE FirstName = '" + firstName + "' AND LastName = '" + lastname + "'";
        //        SqlCommand sqlCommand1 = new SqlCommand(querySelect, con);
        //        sqlCommand1.CommandType = CommandType.Text;
        //        SqlDataAdapter adapter = new SqlDataAdapter();
        //        adapter.SelectCommand = sqlCommand1;
        //        DataSet dataSet = new DataSet();
        //        adapter.Fill(dataSet);

        //        if (dataSet.Tables[0].Rows.Count == 0)
        //        {
        //            string queryAlter = "INSERT INTO Names(FirstName ,LastName)VALUES('" + firstName + "','" + lastname + "')";

        //            //5.execute query.
        //            SqlCommand sqlCommand = new SqlCommand(queryAlter, con);
        //            sqlCommand.ExecuteNonQuery();

        //            //6.close.
        //            con.Close();
        //            MessageBox.Show("data entered");
        //        }
        //        else
        //        {
        //            MessageBox.Show("data all ready there.");
        //            con.Close();
        //        }
        //    }
        //}
    }
}
