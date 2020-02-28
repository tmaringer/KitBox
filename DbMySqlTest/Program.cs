using System;
using MySql.Data.MySqlClient;
using System.Data.Common;

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

            public static void Ninja(MySqlConnection conn, string askSql)
            {
                string sql = "Select " + askSql +" from kitbox";
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
                                string askSqlAnswer = reader.GetString(reader.GetOrdinal(askSql));
                                Console.WriteLine(askSql + ": " + askSqlAnswer);

                            }
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            
            MySqlConnection conn = GetDBConnection();
            conn.Open();
            try
            {
                Console.Write("Enter a SQL Request - ");
                string Mysql = Console.ReadLine();
                QueryKitbox.Ninja(conn, Mysql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Terminez la connexion.
                conn.Close();
                // Disposez un objet, libérez des ressources.
                conn.Dispose();
            }
            Console.Read();
        }
    }
}
