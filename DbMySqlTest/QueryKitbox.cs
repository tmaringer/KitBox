using System;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Collections.Generic;

namespace DbLibrary
{
    public class QueryKitbox
    {

        public static List<string> SpecsBoxList(MySqlConnection conn, string SelectSQL, string WhereSQL)
        {
            List<string> result = new List<string>();
            string sql = "Select " + SelectSQL +" from kitbox where " + WhereSQL;
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            {
                using DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        string WhereSQLAnswer = reader.GetString(reader.GetOrdinal(SelectSQL));
                        if (result.Contains(WhereSQLAnswer))
                        {
                        }
                        else
                        {
                            result.Add(WhereSQLAnswer);
                        }
                    }
                }
            }
            return result;
        }
    }
}
