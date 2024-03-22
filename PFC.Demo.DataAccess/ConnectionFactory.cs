using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFC.Demo.DataAccess
{
    public static class ConnectionFactory
    {
        public static SqlConnection CreateConnection()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Demo"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }  
    }
}
