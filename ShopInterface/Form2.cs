using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projectCS;

namespace ShopInterface
{
    public partial class Form2 : Form
    {
        public Form2(Form1 form1)
        {
            InitializeComponent();
            projectCS.DBUtils.RefreshDB();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String MyConString = InitializeDB();
                MySqlConnection conn = new MySqlConnection(MyConString);
                String Column = this.textBox1.Text;
                String Code = this.textBox2.Text;
                String Value = this.textBox3.Text;
                MySqlCommand cmd = new MySqlCommand("UPDATE kitbox.kitbox SET " + Column + " =\"" + Value + "\"" + " WHERE Code= \"" + Code + "\";", conn);
                conn.Open();
                MySqlDataReader MyReader2;
                MyReader2 = cmd.ExecuteReader();
                this.label4.Text = "Done";
                while (MyReader2.Read())
                {
                }
                RefreshDB();
                conn.Close();
            }
            catch
            {
                this.label4.Text = "Error";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
