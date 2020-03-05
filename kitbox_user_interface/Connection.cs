using System;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Collections.Generic;

namespace kitbox_user_interface_V1
{

    public class Connection
    {
        public static MySqlConnection
        GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password + "; old guids=true";

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "kitbox";
            string username = "root";
            string password = "K8tB0x_sql";

            return GetDBConnection(host, port, database, username, password);
        }
    }
}
