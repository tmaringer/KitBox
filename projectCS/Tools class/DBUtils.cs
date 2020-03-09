using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;

namespace projectCS
{
    public class DBUtils
    {
        private static String MyConString = "SERVER=localhost;" + "PORT=3306;" + "DATABASE=kitbox;" + "UID=root;" + "PASSWORD=locomac6;";

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

        public static int CheckAccess(TextBox login, TextBox password)
        {
            int Value; 
            try
            {
                MySqlConnection conn = new MySqlConnection(MyConString);
                MySqlCommand cmd = new MySqlCommand("SELECT password FROM users WHERE users = \"" + login.Text + "\";", conn);
                conn.Open();
                string passwordDB = "";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        passwordDB = reader["password"].ToString();
                    }
                }
                conn.Close();
                if (ComputeSha256Hash(password.Text) == passwordDB)
                {
                    Value = 0;
                }
                else
                {
                    Value = 1;
                }

            }
            catch
            {
                Value = 2;
            }
            return Value;
        }

        public static DataTable RefreshDB(string database)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT * from " + database  + ";", conn);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            conn.Open();
            dataTable.Clear();
            da.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        public static DataTable RefreshDBCond(string database, string cond)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT * from " + database + " where " + cond + ";", conn);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            conn.Open();
            dataTable.Clear();
            da.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        public static DataTable RefreshDBPartial(string database, string col)
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
        public static Dictionary<string,int> SelectCondDB(string database, string Code)
        {
            Dictionary<string, int> values = new Dictionary<string, int>();
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT * from " + database + " where Code = \"" + Code + "\";", conn);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            foreach (DataColumn dc in dt.Columns)
            {
                try
                {
                    string col = dc.ColumnName.ToString();
                    int value = Convert.ToInt32(dt.Rows[0][col]);
                    values.Add(col, value);
                }
                catch
                {

                }
            };
            return values;
        }
        public static Dictionary<string, string> SelectCondDBBis(string database, string Code)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT * from " + database + " where Code = \"" + Code + "\";", conn);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            foreach (DataColumn dc in dt.Columns)
            {
                try
                {
                    string col = dc.ColumnName.ToString();
                    string value = dt.Rows[0][col].ToString();
                    values.Add(col, value);
                }
                catch
                {

                }
            };
            return values;
        }
        public static List<string> RowValueList(string Column, string table, string Ref)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            List<string> result = new List<string>();
            string sql = "Select " + Column + " from " + table + " where Ref =\"" + Ref + "\";";
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
                        string WhereSQLAnswer = reader.GetString(reader.GetOrdinal(Column));
                        result.Add(WhereSQLAnswer);
                    }
                }
            }
            return result;
        }

        public static List<string> RefList(string Column, string table)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            List<string> result = new List<string>();
            string sql = "Select " + Column + " from " + table + ";";
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
                        string WhereSQLAnswer = reader.GetString(reader.GetOrdinal(Column));
                        result.Add(WhereSQLAnswer);
                    }
                }
                conn.Close();
            }
            return result;
        }

        public static List<string> RefListND(string Column, string table)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            List<string> result = new List<string>();
            string sql = "Select " + Column + " from " + table + ";";
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
                        string WhereSQLAnswer = reader.GetString(reader.GetOrdinal(Column));
                        if ((result.Contains(WhereSQLAnswer)) == false)
                        {
                            result.Add(WhereSQLAnswer);
                        }

                    }
                }
                conn.Close();
            }
            return result;
        }

        public static string UpdateDB(DataGridView grid,String database, TextBox col, TextBox code, TextBox value)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(MyConString);
                String Column = col.Text;
                String Code = code.Text;
                String Value = value.Text;
                MySqlCommand cmd = new MySqlCommand("UPDATE kitbox." + database + " SET " + Column + " =\"" + Value + "\"" + " WHERE Code= \"" + Code + "\";", conn);
                conn.Open();
                MySqlDataReader MyReader2;
                MyReader2 = cmd.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                grid.DataSource = RefreshDB(database);
                conn.Close();
                return "Done";
            }
            catch
            {
                return "Error";
            }
            col.Text = "";
            code.Text = "";
            value.Text = "";
        }
        public static bool SearchDB(DataGridView dataGridView1,TextBox value)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    row.Cells[i].Style.BackColor = System.Drawing.Color.White;
                    if (row.Cells[i].Value.ToString() == value.Text.ToString())
                    {
                        row.Cells[i].Style.BackColor = System.Drawing.Color.LimeGreen;
                    }
                }
            }
            return true;
        }
        public static bool StopSearchDB(DataGridView dataGridView1, TextBox value)
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
        public static string DeleteRow(DataGridView dataGridView,String database, TextBox Code)
        {
            string value;
            try
            {
                MySqlConnection conn = new MySqlConnection(MyConString);
                MySqlCommand cmd = new MySqlCommand("DELETE from " + database+ " where Code=\"" + Code.Text + "\"", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                value = "Done";
            }
            catch
            {
                value = "Error";

            }
            Code.Text = "";
            return value;
        }
        public static int AddItem(Label label7, int x, DataGridView dataGridView1, List<string> Columns, List<string> Types, List<string> Elements, Button button7, TextBox textBox4, ListView listView1, Button button6, ProgressBar progressBar1, Button button3) 
        {
            label7.RightToLeft = RightToLeft.Yes;
            if (x == 1)
            {
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    Columns.Add(col.Name.ToString());
                    if (col.ValueType.ToString() == "System.String")
                    {
                        Types.Add("String");
                    }
                    if (col.ValueType.ToString() == "System.Int32")
                    {
                        Types.Add("Int");
                    }

                }
            }
            //TODO: check type
            /*
            int number;
            try
            {
                number = Convert.ToInt32(textBox4.Text);
            }
            catch
            {

            }
            */
            if (x >= 1 && x <= dataGridView1.ColumnCount)
            {
                button7.Enabled = true;
                button3.Enabled = false;
                Elements.Add(textBox4.Text.ToString());
                string ElementItems = Columns[x-1] + ": " + textBox4.Text;
                listView1.Items.Add(ElementItems);
                textBox4.Text = "";
                if (x == dataGridView1.ColumnCount)
                {
                    button6.Enabled = false;
                    textBox4.Enabled = false;
                    button3.Enabled = true;
                }
                else
                {
                    label7.Text = Columns[x] + " (" + Types[x] + ")";

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
        public static int DeleteItem(Label label7, int x, DataGridView dataGridView1, TextBox textBox4, Button button6, Button button7, List<string> Columns, List<string> Types, List<string> Elements, ListView listView1, ProgressBar progressBar1, Button button3)
        {
            label7.RightToLeft = RightToLeft.Yes;
            if (x > 1 && x <= (dataGridView1.ColumnCount + 1))
            {
                textBox4.Enabled = true;
                button6.Enabled = true;
                button3.Enabled = false;
                Elements.Remove(Elements[x - 2]);
                listView1.Items.RemoveAt(x - 2);
                textBox4.Text = "";
                label7.Text = Columns[x - 2] + " (" + Types[x-2] + ")";
                if (x == 2)
                {
                    button7.Enabled = false;
                }
                x -= 1;
            }
            progressBar1.Increment(-10);
            return x;
        }
        public static string ConvertSQL(List<string> Elements, List<string> Types)
        {
            string ElementString = "";
            for(int i=0; i < Elements.Count; i++)
            {
                if (i == (Elements.Count - 1))
                {
                    if (Types[i] == "String")
                    {
                        ElementString = ElementString + "\"" + Elements[i] + "\"";
                    }
                    else
                    {
                        ElementString = ElementString + Elements[i] + "";
                    }
                }
                else
                {
                    if (Types[i] == "String")
                    {
                        ElementString = ElementString + "\"" + Elements[i] + "\",";
                    }
                    else
                    {
                        ElementString = ElementString + Elements[i] + ",";
                    }
                }
            }
            return ElementString;
        }
        public static string ConvertSQLBis(List<string> Columns)
        {
            string ColumnString = "";
            for (int i = 0; i < Columns.Count; i++)
            {
                if (i == (Columns.Count - 1))
                {
                    ColumnString = ColumnString + Columns[i] + "";
                }
                else
                {
                    ColumnString = ColumnString + Columns[i] + ",";
                }
            }
            return ColumnString;
        }
        public static string AddRow(List<string> Elements, List<string> Types, List<string> Columns, String database)
        {
            string value = "";
            string ElementString = ConvertSQL(Elements, Types);
            string ColumnString = ConvertSQLBis(Columns);
            try
            {
                MySqlConnection conn = new MySqlConnection(MyConString);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string sql = "Insert into "+ database + " (" + ColumnString + ") values (" + ElementString + ");";
                //MySqlCommand cmd = new MySqlCommand(sql, conn);
                adapter.InsertCommand = new MySqlCommand(sql, conn);
                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                conn.Close();
                value = "Done";
            }
            catch (MySqlException e)
            {
                value = e.ToString();

            }
            return value;
        }
    }
}
