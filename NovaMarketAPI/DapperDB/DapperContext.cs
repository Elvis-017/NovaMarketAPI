using System.Data;
using Microsoft.Data.SqlClient;

namespace NovaMarketAPI.DapperDB
{
    public class DapperContext
    {
        private readonly  IConfiguration _configuration;
        private readonly string connectionString;
        public DapperContext(IConfiguration configuration) {
            _configuration = configuration;
            connectionString = configuration.GetConnectionString("connection");
        }

        public IDbConnection CreateDbConnection() { 
            return new SqlConnection(connectionString);
        }
    }
}
