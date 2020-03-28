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
using projectCS.Tools_class;

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
            List<string> WidthBoxList = QueryKitbox.SpecsBoxList(conn, "Width", "Ref = \"Panel B\"");
            conn.Close();
            conn.Open();
            List<string> HeightBoxList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Panel B\"");
            conn.Close();
            conn.Open();
            List<string> ColorBoxList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Door\"");
            conn.Close();
            conn.Open();
            List<string> DepthBoxList = QueryKitbox.SpecsBoxList(conn, "Depth", "Ref = \"Panel LR\"");
            conn.Close();
            conn.Open();
            List<string> BracketsColorList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"AngleBracket\"");
            conn.Close();
           

            /*
             Cornieres
             */

            conn.Open();
            List<string> HightBracketsList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Cornieres\"");
            conn.Close();

            conn.Open();
            List<string> DepthBracketsList = QueryKitbox.SpecsBoxList(conn, "Depth", "Ref = \"Cornieres\"");
            conn.Close();

            conn.Open();
            List<string> WidthBracketsList = QueryKitbox.SpecsBoxList(conn, "Width", "Ref = \"Cornieres\"");
            conn.Close();

            conn.Open();
            List<string> ColorBracketsList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Cornieres\"");
            conn.Close();

            conn.Open();
            List<string> PriceBracketsList = QueryKitbox.SpecsBoxList(conn, "CustPrice", "Ref = \"Cornieres\"");
            conn.Close();

            conn.Open();
            List<string> CodeBracketsList = QueryKitbox.SpecsBoxList(conn, "Code", "Ref = \"Cornieres\"");
            conn.Close();

            /*
             Panneau GD
             */

            conn.Open();
            List<string> HightPannelLRList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Panneau GD\"");
            conn.Close();
                        
            conn.Open();
            List<string> DepthPannelLRList = QueryKitbox.SpecsBoxList(conn, "Depth", "Ref = \"Panneau GD\"");
            conn.Close();

            conn.Open();
            List<string> WidthPannelLRList = QueryKitbox.SpecsBoxList(conn, "Width", "Ref = \"Panneau GD\"");
            conn.Close();

            conn.Open();
            List<string> ColorPannelLRList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Panneau GD\"");
            conn.Close();

            conn.Open();
            List<string> PricePannelLRList = QueryKitbox.SpecsBoxList(conn, "CustPrice", "Ref = \"Panneau GD\"");
            conn.Close();

            conn.Open();
            List<string> CodePannelLRList = QueryKitbox.SpecsBoxList(conn, "Code", "Ref = \"Panneau GD\"");
            conn.Close();

            /*
             Panneau HB
             */

            conn.Open();
            List<string> HightPannelTBList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Panneau HB\"");
            conn.Close();

            conn.Open();
            List<string> DepthPannelTBList = QueryKitbox.SpecsBoxList(conn, "Depth", "Ref = \"Panneau HB\"");
            conn.Close();

            conn.Open();
            List<string> WidthPannelTBList = QueryKitbox.SpecsBoxList(conn, "Width", "Ref = \"Panneau HB\"");
            conn.Close();

            conn.Open();
            List<string> ColorPannelTBList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Panneau HB\"");
            conn.Close();

            conn.Open();
            List<string> PricePannelTBList = QueryKitbox.SpecsBoxList(conn, "CustPrice", "Ref = \"Panneau HB\"");
            conn.Close();

            conn.Open();
            List<string> CodePannelTBList = QueryKitbox.SpecsBoxList(conn, "Code", "Ref = \"Panneau HB\"");
            conn.Close();

            /*
             Panneau Ar
             */

            conn.Open();
            List<string> HightPannelBaList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Panneau Ar\"");
            conn.Close();

            conn.Open();
            List<string> DepthPannelBaList = QueryKitbox.SpecsBoxList(conn, "Depth", "Ref = \"Panneau Ar\"");
            conn.Close();

            conn.Open();
            List<string> WidthPannelBaList = QueryKitbox.SpecsBoxList(conn, "Width", "Ref = \"Panneau Ar\"");
            conn.Close();

            conn.Open();
            List<string> ColorPannelBaList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Panneau Ar\"");
            conn.Close();

            conn.Open();
            List<string> PricePannelBaList = QueryKitbox.SpecsBoxList(conn, "CustPrice", "Ref = \"Panneau Ar\"");
            conn.Close();

            conn.Open();
            List<string> CodePannelBaList = QueryKitbox.SpecsBoxList(conn, "Code", "Ref = \"Panneau Ar\"");
            conn.Close();

            /*
             Porte
             */

            conn.Open();
            List<string> HightDoorList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Door\"");
            conn.Close();

            conn.Open();
            List<string> DepthDoorList = QueryKitbox.SpecsBoxList(conn, "Depth", "Ref = \"Door\"");
            conn.Close();

            conn.Open();
            List<string> WidthDoorList = QueryKitbox.SpecsBoxList(conn, "Width", "Ref = \"Door\"");
            conn.Close();

            conn.Open();
            List<string> ColorDoorList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Door\"");
            conn.Close();

            conn.Open();
            List<string> PriceDoorList = QueryKitbox.SpecsBoxList(conn, "CustPrice", "Ref = \"Door\"");
            conn.Close();

            conn.Open();
            List<string> CodeDoorList = QueryKitbox.SpecsBoxList(conn, "Code", "Ref = \"Door\"");
            conn.Close();

            /*
             Tasseau
             */

            conn.Open();
            List<string> HightCleatsList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Tasseau\"");
            conn.Close();

            conn.Open();
            List<string> DepthCleatsList = QueryKitbox.SpecsBoxList(conn, "Depth", "Ref = \"Tasseau\"");
            conn.Close();

            conn.Open();
            List<string> WidthCleatsList = QueryKitbox.SpecsBoxList(conn, "Width", "Ref = \"Tasseau\"");
            conn.Close();

            conn.Open();
            List<string> ColorCleatsList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Tasseau\"");
            conn.Close();

            conn.Open();
            List<string> PriceCleatsList = QueryKitbox.SpecsBoxList(conn, "CustPrice", "Ref = \"Tasseau\"");
            conn.Close();

            conn.Open();
            List<string> CodeCleatsList = QueryKitbox.SpecsBoxList(conn, "Code", "Ref = \"Tasseau\"");
            conn.Close();

            /*
             Traverse Av
             */

            conn.Open();
            List<string> HightCrossbarFrList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Traverse Av\"");
            conn.Close();

            conn.Open();
            List<string> DepthCrossbarFrList = QueryKitbox.SpecsBoxList(conn, "Depth", "Ref = \"Traverse Av\"");
            conn.Close();

            conn.Open();
            List<string> WidthCrossbarFrList = QueryKitbox.SpecsBoxList(conn, "Width", "Ref = \"Traverse Av\"");
            conn.Close();

            conn.Open();
            List<string> ColorCrossbarFrList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Traverse Av\"");
            conn.Close();

            conn.Open();
            List<string> PriceCrossbarFrList = QueryKitbox.SpecsBoxList(conn, "CustPrice", "Ref = \"Traverse Av\"");
            conn.Close();

            conn.Open();
            List<string> CodeCrossbarFrList = QueryKitbox.SpecsBoxList(conn, "Code", "Ref = \"Traverse Av\"");
            conn.Close();


            /*
             Traverse GD
             */

            conn.Open();
            List<string> HightCrossbarLRList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Traverse GD\"");
            conn.Close();

            conn.Open();
            List<string> DepthCrossbarLRList = QueryKitbox.SpecsBoxList(conn, "Depth", "Ref = \"Traverse GD\"");
            conn.Close();

            conn.Open();
            List<string> WidthCrossbarLRList = QueryKitbox.SpecsBoxList(conn, "Width", "Ref = \"Traverse GD\"");
            conn.Close();

            conn.Open();
            List<string> ColorCrossbarLRList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Traverse GD\"");
            conn.Close();

            conn.Open();
            List<string> PriceCrossbarLRList = QueryKitbox.SpecsBoxList(conn, "CustPrice", "Ref = \"Traverse GD\"");
            conn.Close();

            conn.Open();
            List<string> CodeCrossbarLRList = QueryKitbox.SpecsBoxList(conn, "Code", "Ref = \"Traverse GD\"");
            conn.Close();

            /*
             Traverse Ar
             */

            conn.Open();
            List<string> HightCrossbarBaList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Traverse Ar\"");
            conn.Close();

            conn.Open();
            List<string> DepthCrossbarBaList = QueryKitbox.SpecsBoxList(conn, "Depth", "Ref = \"Traverse Ar\"");
            conn.Close();

            conn.Open();
            List<string> WidthCrossbarBaList = QueryKitbox.SpecsBoxList(conn, "Width", "Ref = \"Traverse Ar\"");
            conn.Close();

            conn.Open();
            List<string> ColorCrossbarBaList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Traverse Ar\"");
            conn.Close();

            conn.Open();
            List<string> PriceCrossbarBaList = QueryKitbox.SpecsBoxList(conn, "CustPrice", "Ref = \"Traverse Ar\"");
            conn.Close();

            conn.Open();
            List<string> CodeCrossbarBaList = QueryKitbox.SpecsBoxList(conn, "Code", "Ref = \"Traverse Ar\"");
            conn.Close();

            /*
             ---------------------------------------
             */





            comboBox3.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7" });
            comboBox4.Items.AddRange(WidthBoxList.Cast<object>().ToArray());
            comboBox5.Items.AddRange(DepthBoxList.Cast<object>().ToArray());
            comboBox6.Items.AddRange(HeightBoxList.Cast<object>().ToArray());
            comboBox7.Items.AddRange(BracketsColorList.Cast<object>().ToArray());
            comboBox2.Items.AddRange(ColorBoxList.Cast<object>().ToArray());
            comboBox1.Items.AddRange(ColorDoorList.Cast<object>().ToArray());

            //ShoppingCart basket = new ShoppingCart();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        public void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            bool choice_fill = false;
            
            Cupboard cupboard = new Cupboard();
            Locker locker = new Locker();
            cupboard.addCupboardComponent(locker);

            if(comboBox3.SelectedItem != null && comboBox4.SelectedItem != null && comboBox5.SelectedItem != null && comboBox7.SelectedItem != null)
            {
                int numberOfLockers = Int32.Parse(comboBox3.SelectedItem.ToString());
                int width = Int32.Parse(comboBox4.SelectedItem.ToString());//ça a l'air con mais ça marche
                int depth = Int32.Parse(comboBox5.SelectedItem.ToString());
                //anglebrackets color
                ComponentColor color1 = ColorParse.parseToEnum(comboBox7.SelectedItem.ToString());

                ComponentSize cupboardSize = new ComponentSize(width, depth, 0);
                ShoppingCart.buildCupboard(cupboardSize.width, cupboardSize.depth, numberOfLockers, color1);


                ComponentColor default_color = ComponentColor.black;
                ComponentSize default_size = new ComponentSize(0, 0, 0);
                ComponentSize traverseA_size = new ComponentSize(0, width, 0);
                ComponentSize traverseGD_size = new ComponentSize(0, 0, depth);
                ComponentSize panneau_size = new ComponentSize(0, width, depth);
                //Size (height, width, depth)


                CrossBar traverseAV = new CrossBar();
                CrossBar traverseAR = new CrossBar();
                CrossBar traverseG = new CrossBar();
                CrossBar traverseD = new CrossBar();
                projectCS.Panel panneauH = new projectCS.Panel();//panneau_size
                projectCS.Panel panneauB = new projectCS.Panel();//panneau_size
                projectCS.Panel panneauG = new projectCS.Panel();
                projectCS.Panel panneauD = new projectCS.Panel();
                projectCS.Panel panneauAR = new projectCS.Panel();
                Cleat tasseau = new Cleat();

                locker.addComponent(traverseAV);
                locker.addComponent(traverseAR);
                locker.addComponent(traverseG);
                locker.addComponent(traverseD);
                locker.addComponent(panneauH);
                locker.addComponent(panneauB);
                locker.addComponent(panneauG);
                locker.addComponent(panneauD);
                locker.addComponent(panneauAR);
                locker.addComponent(tasseau);

                MessageBox.Show(locker.ToString());
                choice_fill = true;
                if (width<62)
                {
                    //comboBox1.Items.RemoveAt(2);
                    //TODO retirer le bon item
                }
                
            }
            else
            {
                MessageBox.Show("Fill every choices");
                button1.Enabled = true;
            }


            //MessageBox.Show(comboBox4.SelectedItem.ToString());
            if(choice_fill)
            {
                this.Hide();
                Form_locker form_locker_1 = new Form_locker();
                form_locker_1.Show();
            }
            

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

        public void button2_Click(object sender, EventArgs e)
        {
            //int height = comboBox6.SelectedIndex;
            //combobox1 : type doors
            //combobox2 : panel colors
            int width = Int32.Parse(comboBox4.SelectedItem.ToString());//ça a l'air con mais ça marche
            int depth = Int32.Parse(comboBox5.SelectedItem.ToString());
            string color1 = comboBox7.SelectedItem.ToString();//va servir à créer les anglebrackets
            MessageBox.Show(width.ToString());
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
