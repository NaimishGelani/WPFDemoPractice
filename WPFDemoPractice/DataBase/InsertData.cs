using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDemoPractice.Model;

namespace WPFDemoPractice.DataBase
{
    internal class InsertData
    {
        protected GetConnection connection = new GetConnection();

        public bool RegistrationData(Registration registration)
        {
            // define INSERT query with parameters
            string query = "INSERT INTO Users (FirstName, LastName, EmailId, Password, Address) " +
                           "VALUES (@FirstName, @LastName, @EmailId, @Password, @Address) ";
            try
            {
                // create connection and command
                using (SqlConnection con = new(connection.GetConnectionString()))
                using (SqlCommand cmd = new(query, con))
                {
                    // define parameters and their values
                    cmd.Parameters.AddWithValue("@FirstName", registration.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", registration.LastName);
                    cmd.Parameters.AddWithValue("@EmailId", registration.Email);
                    cmd.Parameters.AddWithValue("@Password", registration.Password);
                    cmd.Parameters.AddWithValue("@Address", registration.Address);

                    // open connection, execute INSERT, close connection
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in insert data in database", "Error");
                return false;
            }
        }

    }
}
