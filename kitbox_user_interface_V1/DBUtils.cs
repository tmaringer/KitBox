using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace kitbox_user_interface_V1
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "85.10.205.173";
            int port = 3306;
            string database = "kitbox_kewlax";
            string username = "kewlaw";
            string password = "locomac6";
            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }

    }
}