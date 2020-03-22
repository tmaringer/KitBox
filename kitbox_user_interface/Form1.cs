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
             Cornieres
             */

            conn.Open();
            List<string> HightBracketsList = QueryKitbox.SpecsBoxList(conn, "Hauteur", "Ref = \"Cornieres\"");
            conn.Close();

            conn.Open();
            List<string> DepthBracketsList = QueryKitbox.SpecsBoxList(conn, "Profondeur", "Ref = \"Cornieres\"");
            conn.Close();

            conn.Open();
            List<string> WidthBracketsList = QueryKitbox.SpecsBoxList(conn, "Largeur", "Ref = \"Cornieres\"");
            conn.Close();

            conn.Open();
            List<string> ColorBracketsList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Cornieres\"");
            conn.Close();

            /*
             Panneau GD
             */

            conn.Open();
            List<string> HightPannelLRList = QueryKitbox.SpecsBoxList(conn, "Hauteur", "Ref = \"Panneau GD\"");
            conn.Close();
                        
            conn.Open();
            List<string> DepthPannelLRList = QueryKitbox.SpecsBoxList(conn, "Profondeur", "Ref = \"Panneau GD\"");
            conn.Close();

            conn.Open();
            List<string> WidthPannelLRList = QueryKitbox.SpecsBoxList(conn, "Largeur", "Ref = \"Panneau GD\"");
            conn.Close();

            conn.Open();
            List<string> ColorPannelLRList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Panneau GD\"");
            conn.Close();

            /*
             Panneau HB
             */

            conn.Open();
            List<string> HightPannelTBList = QueryKitbox.SpecsBoxList(conn, "Hauteur", "Ref = \"Panneau HB\"");
            conn.Close();

            conn.Open();
            List<string> DepthPannelTBList = QueryKitbox.SpecsBoxList(conn, "Profondeur", "Ref = \"Panneau HB\"");
            conn.Close();

            conn.Open();
            List<string> WidthPannelTBList = QueryKitbox.SpecsBoxList(conn, "Largeur", "Ref = \"Panneau HB\"");
            conn.Close();

            conn.Open();
            List<string> ColorPannelTBList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Panneau HB\"");
            conn.Close();

            /*
             Panneau Ar
             */

            conn.Open();
            List<string> HightPannelBaList = QueryKitbox.SpecsBoxList(conn, "Hauteur", "Ref = \"Panneau Ar\"");
            conn.Close();

            conn.Open();
            List<string> DepthPannelBaList = QueryKitbox.SpecsBoxList(conn, "Profondeur", "Ref = \"Panneau Ar\"");
            conn.Close();

            conn.Open();
            List<string> WidthPannelBaList = QueryKitbox.SpecsBoxList(conn, "Largeur", "Ref = \"Panneau Ar\"");
            conn.Close();

            conn.Open();
            List<string> ColorPannelBaList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Panneau Ar\"");
            conn.Close();

            /*
             Porte
             */

            conn.Open();
            List<string> HightDoorList = QueryKitbox.SpecsBoxList(conn, "Hauteur", "Ref = \"Porte\"");
            conn.Close();

            conn.Open();
            List<string> DepthDoorList = QueryKitbox.SpecsBoxList(conn, "Profondeur", "Ref = \"Porte\"");
            conn.Close();

            conn.Open();
            List<string> WidthDoorList = QueryKitbox.SpecsBoxList(conn, "Largeur", "Ref = \"Porte\"");
            conn.Close();

            conn.Open();
            List<string> ColorDoorList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Porte\"");
            conn.Close();

            /*
             Tasseau
             */

            conn.Open();
            List<string> HightCleatsList = QueryKitbox.SpecsBoxList(conn, "Hauteur", "Ref = \"Tasseau\"");
            conn.Close();

            conn.Open();
            List<string> DepthCleatsList = QueryKitbox.SpecsBoxList(conn, "Profondeur", "Ref = \"Tasseau\"");
            conn.Close();

            conn.Open();
            List<string> WidthCleatsList = QueryKitbox.SpecsBoxList(conn, "Largeur", "Ref = \"Tasseau\"");
            conn.Close();

            conn.Open();
            List<string> ColorCleatsList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Tasseau\"");
            conn.Close();

            /*
             Traverse Av
             */

            conn.Open();
            List<string> HightCrossbarFrList = QueryKitbox.SpecsBoxList(conn, "Hauteur", "Ref = \"Traverse Av\"");
            conn.Close();

            conn.Open();
            List<string> DepthCrossbarFrList = QueryKitbox.SpecsBoxList(conn, "Profondeur", "Ref = \"Traverse Av\"");
            conn.Close();

            conn.Open();
            List<string> WidthCrossbarFrList = QueryKitbox.SpecsBoxList(conn, "Largeur", "Ref = \"Traverse Av\"");
            conn.Close();

            conn.Open();
            List<string> ColorCrossbarFrList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Traverse Av\"");
            conn.Close();

            /*
             Traverse GD
             */

            conn.Open();
            List<string> HightCrossbarLRList = QueryKitbox.SpecsBoxList(conn, "Hauteur", "Ref = \"Traverse GD\"");
            conn.Close();

            conn.Open();
            List<string> DepthCrossbarLRList = QueryKitbox.SpecsBoxList(conn, "Profondeur", "Ref = \"Traverse GD\"");
            conn.Close();

            conn.Open();
            List<string> WidthCrossbarLRList = QueryKitbox.SpecsBoxList(conn, "Largeur", "Ref = \"Traverse GD\"");
            conn.Close();

            conn.Open();
            List<string> ColorCrossbarLRList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Traverse GD\"");
            conn.Close();
            
            /*
             Traverse Ar
             */

            conn.Open();
            List<string> HightCrossbarBaList = QueryKitbox.SpecsBoxList(conn, "Hauteur", "Ref = \"Traverse Ar\"");
            conn.Close();

            conn.Open();
            List<string> DepthCrossbarBaList = QueryKitbox.SpecsBoxList(conn, "Profondeur", "Ref = \"Traverse Ar\"");
            conn.Close();

            conn.Open();
            List<string> WidthCrossbarBaList = QueryKitbox.SpecsBoxList(conn, "Largeur", "Ref = \"Traverse Ar\"");
            conn.Close();

            conn.Open();
            List<string> ColorCrossbarBaList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Traverse Ar\"");
            conn.Close();






            comboBox3.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7" });
            comboBox4.Items.AddRange(WidthBoxList.Cast<object>().ToArray());
            comboBox5.Items.AddRange(DepthBoxList.Cast<object>().ToArray());
            comboBox6.Items.AddRange(HeightBoxList.Cast<object>().ToArray());
            comboBox7.Items.AddRange(BracketsColorList.Cast<object>().ToArray());
            comboBox2.Items.AddRange(ColorBoxList.Cast<object>().ToArray());
            comboBox1.Items.AddRange(ColorDoorList.Cast<object>().ToArray());

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

                projectCS.Color default_color = projectCS.Color.black;
                projectCS.Size default_size = new projectCS.Size(0, 0, 0);
                projectCS.Size traverse_size = new projectCS.Size(0, 0, 0);
                projectCS.Size panneau_size = new projectCS.Size(0, width, depth);
                //Size (height, width, depth) 
                CrossBar traverseAV = new CrossBar(0, "null", "0000", traverse_size, false, width, default_color);
                CrossBar traverseAR = new CrossBar(0, "null", "0000", traverse_size, false, width, default_color);
                Pannel panneauH = new Pannel(0, "null", "0000", panneau_size, false, 0, default_color);
                Pannel panneauB = new Pannel(0, "null", "0000", panneau_size, false, 0, default_color);
                Pannel panneauG = new Pannel(0, "null", "0000", default_size, false, 0, default_color);
                Pannel panneauD = new Pannel(0, "null", "0000", default_size, false, 0, default_color);
                
                
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
