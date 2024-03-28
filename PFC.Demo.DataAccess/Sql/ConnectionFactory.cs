using System.Data.SqlClient;

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
