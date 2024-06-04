using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDemoPractice.Model;
using static Azure.Core.HttpHeader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WPFDemoPractice.DataBase
{
    internal class GetData
    {
        protected GetConnection connection = new GetConnection();

        public string ExecuteLogin(string username, string password)
        {
            // define INSERT query with parameters
            string query = "SELECT EmailId,Password FROM Users WHERE EmailId LIKE @Email AND Password = @Password ";
            string code = String.Empty;

            try
            {
                // create connection and command
                using (SqlConnection conn = new(connection.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand command = new(query, conn))
                    {
                        command.Parameters.AddWithValue("@Email", username);
                        command.Parameters.AddWithValue("@Password", password);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                code = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                                string x = reader.GetString(0);
                                string y = reader.GetString(1);
                            }
                        }
                    }
                }
                return code!;
            }
            catch (Exception)
            {
                MessageBox.Show("Error in fetching data from database", "Error");
                return string.Empty;
            }
        }
    }
}
