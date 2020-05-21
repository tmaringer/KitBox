using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace projectCS
{
    public static class DbUtils
    {
        private static string MyConString = "SERVER=localhost;" + "PORT=3306;" + "DATABASE=kitbox;" + "UID=root;" + "PASSWORD=locomac6; Allow User Variables=True";

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string InsertDb(string database, string columns, string values)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(MyConString);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string sql = "Insert into " + database + " (" + columns + ") values (" + values + ");";
                adapter.InsertCommand = new MySqlCommand(sql, conn);
                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                conn.Close();
                return "Done";
            }
            catch
            {
                return "Error";
            }
        }

        public static int CheckAccess(string login, string password)
        {
            int value;
            try
            {
                MySqlConnection conn = new MySqlConnection(MyConString);
                MySqlCommand cmd = new MySqlCommand("SELECT password FROM users WHERE users = \"" + login + "\";", conn);
                conn.Open();
                string passwordDb = "";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        passwordDb = reader["password"].ToString();
                    }
                }
                conn.Close();
                if (ComputeSha256Hash(password) == passwordDb)
                {
                    value = 0;
                }
                else
                {
                    value = 1;
                }

            }
            catch
            {
                value = 2;
            }
            return value;
        }

        public static DataTable RefreshDb(string database)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT * from " + database + ";", conn);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            conn.Open();
            dataTable.Clear();
            da.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        public static DataTable RefreshDbPartial(string database, string col)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT " + col + " from " + database + ";", conn);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            conn.Open();
            dataTable.Clear();
            da.Fill(dataTable);
            conn.Close();
            return dataTable;
        }
        public static Dictionary<string, int> SelectCondDb(string database, string code)
        {
            Dictionary<string, int> values = new Dictionary<string, int>();
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT * from " + database + " where code = \"" + code + "\";", conn);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            foreach (DataColumn dc in dt.Columns)
            {
                try
                {
                    string col = dc.ColumnName;
                    int value = Convert.ToInt32(dt.Rows[0][col]);
                    values.Add(col, value);
                }
                catch
                {

                }

            }

            return values;
        }


        public static List<string> RefList(string column, string table)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            List<string> result = new List<string>();
            string sql = "Select " + column + " from kitbox." + table + ";";
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            {
                conn.Open();
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        string whereSqlAnswer = reader.GetString(reader.GetOrdinal(column));
                        result.Add(whereSqlAnswer);
                    }
                }
                conn.Close();
            }
            return result;
        }

        public static List<string> RefListNd(string column, string table)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            List<string> result = new List<string>();
            string sql = "Select " + column + " from " + table + ";";
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            {
                conn.Open();
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        string whereSqlAnswer = reader.GetString(reader.GetOrdinal(column));
                        if ((result.Contains(whereSqlAnswer)) == false)
                        {
                            result.Add(whereSqlAnswer);
                        }

                    }
                }
                conn.Close();
            }
            return result;
        }
        public static string UpdateDb(string database, string column, string cond, string value)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(MyConString);
                MySqlCommand cmd = new MySqlCommand("UPDATE kitbox." + database + " SET " + column + " =\"" + value + "\"" + " WHERE " + cond + ";", conn);
                conn.Open();
                MySqlDataReader MyReader2;
                MyReader2 = cmd.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                conn.Close();
                return "Done";
            }
            catch
            {
                return "Error";
            }

        }

        public static bool SearchDb(DataGridView dataGridView1, TextBox value)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    row.Cells[i].Style.BackColor = System.Drawing.Color.White;
                    if (row.Cells[i].Value.ToString() == value.Text)
                    {
                        row.Cells[i].Style.BackColor = System.Drawing.Color.LimeGreen;
                    }
                }
            }
            return true;
        }
        public static bool StopSearchDb(DataGridView dataGridView1, TextBox value)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    row.Cells[i].Style.BackColor = System.Drawing.Color.White;
                }
            }
            return false;
        }
        public static string DeleteRow(string database, string cond)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(MyConString);
                MySqlCommand cmd = new MySqlCommand("DELETE from " + database + " where " + cond, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Done";
            }
            catch
            {
                return "Error";
            }

        }

        public static void Arrange(string database, string id)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("CREATE TABLE `test` LIKE `" + database + "`; INSERT INTO `test` (`DoorId`, `BoxId`, `code`) SELECT * FROM kitbox." + database + " ORDER BY BoxId ASC; DROP TABLE `" + database + "`; RENAME TABLE `test` TO `" + database + "`; SET @num:= 0; UPDATE kitbox." + database + " SET " + id + "= @num := (@num + 1); ALTER TABLE kitbox." + database + " AUTO_INCREMENT = 1;", conn);
            conn.Open();
            MySqlDataReader MyReader2;
            MyReader2 = cmd.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            conn.Close();
        }

        public static int AddItem(Label label7, int x, DataGridView dataGridView1, List<string> columns, List<string> types, List<string> elements, Button button7, TextBox textBox4, ListView listView1, Button button6, ProgressBar progressBar1, Button button3)
        {
            label7.RightToLeft = RightToLeft.Yes;
            if (x == 1)
            {
                int size = dataGridView1.Columns.Count;
                progressBar1.Maximum = (size * 10) + 10;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    columns.Add(col.Name);
                    if (col.ValueType.ToString() == "System.String")
                    {
                        types.Add("String");
                    }
                    if (col.ValueType.ToString() == "System.Int32")
                    {
                        types.Add("Int");
                    }

                }
            }
            if (x >= 1 && x <= dataGridView1.ColumnCount)
            {
                button7.Enabled = true;
                button3.Enabled = false;
                elements.Add(textBox4.Text);
                string elementItems = columns[x - 1] + ": " + textBox4.Text;
                listView1.Items.Add(elementItems);
                textBox4.Text = "";
                if (x == dataGridView1.ColumnCount)
                {
                    button6.Enabled = false;
                    textBox4.Enabled = false;
                    button3.Enabled = true;
                }
                else
                {
                    label7.Text = columns[x] + " (" + types[x] + ")";

                }
                x += 1;
            }
            else
            {
                button6.Enabled = false;
            }
            progressBar1.PerformStep();
            return x;
        }
        public static int DeleteItem(Label label7, int x, DataGridView dataGridView1, TextBox textBox4, Button button6, Button button7, List<string> columns, List<string> types, List<string> elements, ListView listView1, ProgressBar progressBar1, Button button3)
        {
            label7.RightToLeft = RightToLeft.Yes;
            if (x > 1 && x <= (dataGridView1.ColumnCount + 1))
            {
                textBox4.Enabled = true;
                button6.Enabled = true;
                button3.Enabled = false;
                elements.Remove(elements[x - 2]);
                listView1.Items.RemoveAt(x - 2);
                textBox4.Text = "";
                label7.Text = columns[x - 2] + " (" + types[x - 2] + ")";
                if (x == 2)
                {
                    button7.Enabled = false;
                }
                x -= 1;
            }
            progressBar1.Increment(-10);
            return x;
        }
        public static string ConvertStringQuotes(List<string> elements)
        {
            string elementString = "";
            for (int i = 0; i < elements.Count; i++)
            {
                if (i == (elements.Count - 1))
                {
                    elementString = elementString + "\"" + elements[i] + "\"";
                }
                else
                {
                    elementString = elementString + "\"" + elements[i] + "\",";
                }
            }
            return elementString;
        }
        public static string ConvertStringNoQuotes(List<string> columns)
        {
            string columnString = "";
            for (int i = 0; i < columns.Count; i++)
            {
                if (i == (columns.Count - 1))
                {
                    columnString = columnString + columns[i] + "";
                }
                else
                {
                    columnString = columnString + columns[i] + ",";
                }
            }
            return columnString;
        }
        public static List<string> BigMoney(MySqlConnection conn, string target, string reference, string height, string depth, string width, string colour)
        {
            List<string> result = new List<string>();
            string sql;
            if (colour.Length == 0)
            {
                sql = "Select " + target + " from kitbox where Ref = \"" + reference + "\" and Height = \"" + height + "\" and Depth = \"" + depth + "\" and Width = \"" + width + "\" and  Colour = \"\"";
            }
            else
            {
                sql = "Select " + target + " from kitbox where Ref = \"" + reference + "\" and Height = \"" + height + "\" and Depth = \"" + depth + "\" and Width = \"" + width + "\" and  Colour = \"" + colour + "\"";
            }
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = sql
            };
            {
                DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        string WhereSQLAnswer = reader.GetString(reader.GetOrdinal(target));
                        if (!result.Contains(WhereSQLAnswer))
                        {
                            result.Add(WhereSQLAnswer);
                        }
                    }
                }
            }
            return result;
        }
        //"Select Code, CustPrice, Instock from kitbox where Height = 32 and Depth = 32 and Width = 32 and Colour = white and Ref= Panel LR
    }
}
