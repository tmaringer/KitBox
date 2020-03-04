using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace projectCS
{
    public class DBUtils
    {
        private static String MyConString = "SERVER=localhost;" + "DATABASE=kitbox;" + "UID=root;" + "PASSWORD=locomac6;";

        public static void RefreshDB(DataGridView grid)
        {
            MySqlConnection conn = new MySqlConnection(MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM kitbox;", conn);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            conn.Open();
            dataTable.Clear();
            da.Fill(dataTable);
            grid.DataSource = dataTable;
            conn.Close();
        }

        public static string UpdateDB(DataGridView grid, TextBox col, TextBox code, TextBox value)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(MyConString);
                String Column = col.Text;
                String Code = code.Text;
                String Value = value.Text;
                MySqlCommand cmd = new MySqlCommand("UPDATE kitbox.kitbox SET " + Column + " =\"" + Value + "\"" + " WHERE Code= \"" + Code + "\";", conn);
                conn.Open();
                MySqlDataReader MyReader2;
                MyReader2 = cmd.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                RefreshDB(grid);
                conn.Close();
                return "Done";
            }

            catch
            {
                return "Error";
            }
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
                        row.Cells[i].Style.BackColor = System.Drawing.Color.Green;
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
    }
}
