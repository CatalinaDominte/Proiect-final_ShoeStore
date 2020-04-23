using Project.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public static class ConnectionManager
    {
       
        private static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            if (connection != null)
            {
                return connection;
            }

            connection = new SqlConnection
            {
                ConnectionString = ConnectionString
            };

            connection.Open();

            return connection;
        }
    }
}
