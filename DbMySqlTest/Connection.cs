using System;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Collections.Generic;

namespace DbLibrary
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
            string host = "remotemysql.com";
            int port = 3306;
            string database = "HHFtMTewie";
            string username = "HHFtMTewie";
            string password = "yVUAYh6xqO";

            return GetDBConnection(host, port, database, username, password);
        }
    }
}
