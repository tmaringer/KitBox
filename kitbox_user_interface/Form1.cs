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
           

            comboBox3.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7" });
            //TODO : get variable globale max_lockers puis boucle pour remplir combobox3
            comboBox4.Items.AddRange(WidthBoxList.Cast<object>().ToArray());
            comboBox5.Items.AddRange(DepthBoxList.Cast<object>().ToArray());
            comboBox7.Items.AddRange(BracketsColorList.Cast<object>().ToArray());

            //ShoppingCart basket = new ShoppingCart();

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
            //------------------------------------------------------------ exemple 
            // enregsitre les choix dans les variables

            ComponentColor c = ComponentColor.brown; // choix de la boc
            ComponentSize s = new ComponentSize(0, 0, 0); // choix
            int numboflocker = 5;

            if (comboBox3.SelectedItem != null && comboBox4.SelectedItem != null && comboBox5.SelectedItem != null && comboBox7.SelectedItem != null)
            {
                ComponentColor color1 = ColorParse.parseToEnum(comboBox7.SelectedItem.ToString());
                int numberOfLockers = Int32.Parse(comboBox3.SelectedItem.ToString());
                int width = Int32.Parse(comboBox4.SelectedItem.ToString());
                int depth = Int32.Parse(comboBox5.SelectedItem.ToString());

                ShoppingCart.addCupboardUserChoices(width, depth, numberOfLockers, color1);
                choice_fill = true;
            }
            else
            {
                MessageBox.Show("Fill every choices");
                button1.Enabled = true;
            }
            if (choice_fill)
            {
                this.Hide();
                Form_locker form_locker_1 = new Form_locker();
                form_locker_1.Show();
            }
            //------------------------------------------------------------ fin
            /*
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

                string dataString;
                dataString = comboBox3.SelectedItem.ToString() + "\n" + comboBox4.SelectedItem.ToString() + "\n" + comboBox5.SelectedItem.ToString() + "\n" + comboBox7.SelectedItem.ToString() + "\n";
                //System.IO.File.WriteAllText("C:\\Users\\natha\\KitBox\\kitboxData.txt", dataString);


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
                projectCS.Panels panneauH = new projectCS.Panels();//panneau_size
                projectCS.Panels panneauB = new projectCS.Panels();//panneau_size
                projectCS.Panels panneauG = new projectCS.Panels();
                projectCS.Panels panneauD = new projectCS.Panels();
                projectCS.Panels panneauAR = new projectCS.Panels();
                Cleat tasseau = new Cleat();

                //projecCS. pas nécessaire

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
            */

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
