using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DbWorker.Tools
{
    public class DbConnection
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString =
                "server=localhost;database=my_online_bank;user=root;password=123;charset=utf8;port=50000";

            return new MySqlConnection(connectionString);
        }

    }
}

