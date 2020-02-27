using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kitbox_user_interface_V1;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace kitbox_user_interface_V1
{
    class QueryDataExample
    {
        static void Main(string[] args)
        {
            // Obtenez de l'objet Connection qui se connecte à DB.
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                QueryBox(conn);
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

        private static void QueryBox(MySqlConnection conn)
        {
            string sql = "Select Ref from kitbox";
            /*
            // Créez un objet Command.
            MySqlCommand cmd = new MySqlCommand();

            // Établissez la connexion de la commande.
            cmd.Connection = conn;
            cmd.CommandText = sql;
            DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    Console.WriteLine(reader.GetString(1));
                }
                
            }
            */
            string connectionString ="Server=db4free.net;Database=kitbox_kewlax;port=3306;UserId=kewlaw;password=locomac6;old guids=true";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(
                             "SELECT Ref FROM kitbox WHERE Code=PAH3262BR", connection))
                {
                    connection.Open();
                    string result = (string)command.ExecuteScalar();
                    DbDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(1));
                        }

                    }
                    Console.WriteLine("Ref = " + result);
                }
            }
        }
    }

}