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
        private int x = 1;
        private List<string> Columns = new List<string>();
        private List<string> Types = new List<string>();
        private List<string> Elements = new List<string>();
        public Form2(Form1 form1)
        {
            InitializeComponent();
            DBUtils.RefreshDB("kitbox", dataGridView1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label4.Text = DBUtils.UpdateDB(dataGridView1, "kitbox", textBox1, textBox2, textBox3);
            DBUtils.RefreshDB("kitbox", dataGridView1);
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

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Enabled = DBUtils.SearchDB(dataGridView1, textBox10);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            button4.Enabled = DBUtils.StopSearchDB(dataGridView1, textBox10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = DBUtils.DeleteRow(dataGridView1, "kitbox", textBox6);
            DBUtils.RefreshDB("kitbox", dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label9.Text = DBUtils.AddRow(Elements, Types, Columns, "kitbox");
            DBUtils.RefreshDB("kitbox", dataGridView1);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            x = DBUtils.AddItem(label7, x, dataGridView1, Columns, Types, Elements, button7, textBox4, listView1, button6, progressBar1, button3);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            x = DBUtils.DeleteItem(label7, x, dataGridView1, textBox4, button6, button7, Columns, Types, Elements, listView1, progressBar1, button3);
        }
    }
}
