using System;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Collections.Generic;

namespace DbMySqlTest
{
    class Program
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
            string host = "db4free.net";
            int port = 3306;
            string database = "kitbox_kewlax";
            string username = "kewlaw";
            string password = "locomac6";

            return GetDBConnection(host, port, database, username, password);
        }

        private class QueryKitbox
        {

            public static List<string> SpecsBoxList(MySqlConnection conn, string SelectSQL, string WhereSQL)
            {
                List<string> result = new List<string>();
                string sql = "Select " + SelectSQL +" from kitbox where " + WhereSQL;
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                {
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                string WhereSQLAnswer = reader.GetString(reader.GetOrdinal(SelectSQL));
                                result.Add(WhereSQLAnswer);

                            }
                        }
                    }
                }
                return result;
            }
            public static void SelectAll(MySqlConnection conn, string SelectSQL)
            {
                string sql = "Select " + SelectSQL + " from kitbox";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                {
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                string WhereSQLAnswer = reader.GetString(reader.GetOrdinal(SelectSQL));
                                Console.WriteLine(SelectSQL + ": " + WhereSQLAnswer);

                            }
                        }
                    }
                }
            }
        }
    }
}
