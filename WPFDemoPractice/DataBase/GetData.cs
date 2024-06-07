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
        protected GetConnection connection = new();

        public string ExecuteLogin(string username, string password)
        {
            // define INSERT query with parameters
            string query = "SELECT EmailId,Password FROM Users WHERE EmailId LIKE @Email AND Password = @Password ";
            string code = String.Empty;

            try
            {
                // create connection and command
                using (SqlConnection con = new(connection.GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand command = new(query, con))
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

        public void ExecuteStoredProcedure(string procedureName, string email, string password)
        {
            string code = string.Empty;

            if (string.IsNullOrEmpty(procedureName))
                MessageBox.Show("Error in fetching data from storeprocedure", "Error");

            using (SqlConnection con = new(connection.GetConnectionString()))
            {
                con.Open();
                using (SqlCommand cmd = new(procedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command if provided

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password;
                    cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    string emailId = Convert.ToString(cmd.Parameters["@Code"].Value);
                    using (SqlDataAdapter adapter = new(cmd))
                    {
                        DataTable dataTable = new();
                        adapter.Fill(dataTable);
                        con.Close();
                    }
                }
            }
        }
    }
}