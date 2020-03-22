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
using projectCS;

namespace kitbox_user_interface_V1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
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
            conn.Open();
            List<string> BracketsColorList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Cornieres\"");
            conn.Close();
            /*
            conn.Open();
            List<string> ColorcrossList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Traverse AR\"");
            conn.Close();
            */

            comboBox3.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7" });
            comboBox4.Items.AddRange(WidthBoxList.Cast<object>().ToArray());
            comboBox5.Items.AddRange(DepthBoxList.Cast<object>().ToArray());
            comboBox6.Items.AddRange(HeightBoxList.Cast<object>().ToArray());
            comboBox7.Items.AddRange(BracketsColorList.Cast<object>().ToArray());
            comboBox2.Items.AddRange(ColorBoxList.Cast<object>().ToArray());

            ShoppingCart basket = new ShoppingCart();

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
            button1.Enabled = false;

            //TODO taille standadisée validée


            Cupboard cupboard = new Cupboard();

            //CrossBar traverses = new CrossBar();
            //TODO créer objet armoire intermédiaire 
            /*
            if (comboBox3.SelectedIndex == 6)
            {
                comboBox6.Items.RemoveAt(2);
                //si d'autres hauteurs peuvent être créées faire une recherche parmi
                //les éléments de combobox6 et supprimer ceux plus grand que 52
                //sinon l'extension n'est pas privilégiée
            }
            //gérer dynamiquement la hauteur des box et la hauteur max
            */
            if(comboBox4.SelectedItem != null && comboBox5.SelectedItem != null)
            {
                int width = Int32.Parse(comboBox4.SelectedItem.ToString());//ça a l'air con mais ça marche
                int depth = Int32.Parse(comboBox5.SelectedItem.ToString());
                projectCS.Color color = projectCS.Color.black;
                projectCS.Size sier = new projectCS.Size(0, 0, 0);
                CrossBar traverseAV = new CrossBar(0, "null", "0000", sier, false, width, color);
                CrossBar traverseAR = new CrossBar(0, "null", "0000", sier, false, width, color);
                //Panel panneauH = new Panel(0, "null", "0000", new Size(0/*width*/, 0 /*depth*/, 0), false, 0, Color.black);
                //Panel panneauB = new Panel(0, "null", "0000", new Size(0, 0, 0), false, 0, Color.black);
                //Panel panneauG = new Panel(0, "null", "0000", new Size(0/*width*/, 0 /*depth*/, 0), false, 0, Color.black);
                //Panel panneauD = new Panel(0, "null", "0000", new Size(0, 0, 0), false, 0, Color.black);
                //TODO size est défini où et comment ?  normalement Lxlxh soit width x depth x height
                // ou alors depth x width x height ?
                if(width<62)
                {
                    //comboBox1.Items.RemoveAt(2);
                    //TODO retirer le bon item
                }
            }


            //MessageBox.Show(comboBox4.SelectedItem.ToString());

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
            //int height = comboBox6.SelectedIndex;
            //combobox1 : type doors
            //combobox2 : panel colors
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //refresh combobox height
            string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
            MySqlConnection conn = new MySqlConnection(MyConString);
            conn.Open();
            List<string> HeightBoxList = QueryKitbox.SpecsBoxList(conn, "hauteur", "Ref = \"Panneau GD\"");
            conn.Close();
            comboBox6.Items.Clear();
            comboBox6.Items.AddRange(HeightBoxList.Cast<object>().ToArray());
            //allow to create new cupboard
            button1.Enabled = true;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
