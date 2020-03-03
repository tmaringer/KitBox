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
    class DBUtils
    {
        private String MyConString = "SERVER=localhost;" + "DATABASE=kitbox;" + "UID=root;" + "PASSWORD=locomac6;";

        public void RefreshDB(DataGridView grid)
        {
            MySqlConnection conn = new MySqlConnection(this.MyConString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM kitbox;", conn);
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            conn.Open();
            dataTable.Clear();
            da.Fill(dataTable);
            grid.DataSource = dataTable;
            conn.Close();
        }

        public string UpdateDB(DataGridView grid, TextBox col, TextBox code, TextBox value)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(this.MyConString);
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
                this.RefreshDB(grid);
                conn.Close();
                return "Done";
            }

            catch
            {
                return "Error";
            }
        }
    }
}
