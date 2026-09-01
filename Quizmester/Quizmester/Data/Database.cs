using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmester.Data
{
    public static class Database //create new connection with database
    {
        private const string ConnectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=quizmester;" +
            "Uid=root;" +
            "Pwd=;";

            public static MySqlConnection GetConnection()
            {
                return new MySqlConnection(ConnectionString);
            }
    }
}
