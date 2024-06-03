using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemoPractice.DataBase
{
    public class GetConnection
    {
        private readonly string  connectionString;


        /// <summary>
        /// connection string.
        /// </summary>
        public GetConnection()
        {
            connectionString = "Data Source=PCA63\\SQL2022;Initial Catalog=WPFDemo;Integrated Security=True;TrustServerCertificate=True";
        }

        /// <summary>
        /// Generates Connections to DataBase.
        /// </summary>

        public SqlConnection GenerateConnection()
        {
            return new SqlConnection(connectionString);
        }


        /// <summary>
        /// return connection string to connect to database.
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return connectionString;
        }

    }

}
