using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kitbox_user_interface_V1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string MyConString = "SERVER=localhost;" + "DATABASE=kitbox;" + "UID=root;" + "PASSWORD=K8tB0x_sql;";
            MySqlConnection conn = new MySqlConnection(MyConString);
            conn.Open();
            List<string> WidthBoxList = QueryKitbox.SpecsBoxList(conn, "Largeur", "Ref = \"Panneau Ar\"");
            conn.Close();
            conn.Open();
            List<string> HeightBoxList = QueryKitbox.SpecsBoxList(conn, "hauteur", "Ref = \"Panneau GD\"");
            conn.Close();
            conn.Open();
            List<string> ColorBoxList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Porte\"");
            conn.Close();
            conn.Open();
            List<string> DepthBoxList = QueryKitbox.SpecsBoxList(conn, "profondeur", "Ref = \"Panneau GD\"");
            conn.Close();

            comboBox3.Items.AddRange(new object[] {"1","2","3","4","5","6","7"});
            comboBox4.Items.AddRange(WidthBoxList.Cast<object>().ToArray());
            comboBox5.Items.AddRange(DepthBoxList.Cast<object>().ToArray());
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //créer armoire
            //créer box
            //créer commande ?
            MessageBox.Show("Henlo Frien");
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
