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

        public static List<string> ColumnList(MySqlConnection conn, string Column)
        {
            List<string> result = new List<string>();
            string sql = "Select " + Column + " from kitbox";
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
                        string WhereSQLAnswer = reader.GetString(reader.GetOrdinal(Column));
                        result.Add(WhereSQLAnswer);
                    }
                }
            }
            return result;
        }
        public static string BestHeight(MySqlConnection conn, string Column, int Value)
        {
            string result = "";
            List<int> Cuttable = new List<int>();
            string sql = "Select " + Column + " from kitbox";
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            using DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    string ColumnComponent = reader.GetString(reader.GetOrdinal(Column));
                    int IntColumnComponent = Convert.ToInt32(ColumnComponent);
                    if (IntColumnComponent % 36 == 0 || IntColumnComponent % 46 == 0 || IntColumnComponent % 56 == 0)
                    {
                    }
                    else
                    {
                        Cuttable.Add(IntColumnComponent);
                    }
                }
            }
            if (Value % 36 != 0 && Value % 46 != 0 && Value % 56 != 0)
            {
                int MaxValue = 500;
                foreach (int i in Cuttable)
                {
                    if (i >= Value && i < MaxValue)
                    {
                        MaxValue = i;
                    }
                }
                result = MaxValue.ToString();
            }
            else
            {
                result = Value.ToString();
            }
            return result;  
        }

        public static void UpdateDbComponents(MySqlConnection conn, string SetSQL, string WhereSQL)
        {
            string sql = "Update kitbox set " + SetSQL + " where " + WhereSQL;
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.UpdateCommand = cmd;
                adapter.UpdateCommand.ExecuteNonQuery();
            }
        }
    }
}
