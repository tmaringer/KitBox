using projectCS;
using projectCS.Tools_class;
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
    public partial class Form_locker : Form
    {
        public Form_locker()
        {
            InitializeComponent();
            string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
            MySqlConnection conn = new MySqlConnection(MyConString);
            conn.Open();
            List<string> HeightBoxList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Panel B\"");
            conn.Close();
            conn.Open();
            List<string> ColorDoorList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Door\"");
            conn.Close();
            conn.Open();
            List<string> ColorPannelBaList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"Panel B\"");
            conn.Close();
            conn.Open();
            List<string> HeightBracketsList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"AngleBracket\"");
            conn.Close();

            comboBox1.Items.AddRange(ColorDoorList.Cast<object>().ToArray());
            comboBox2.Items.AddRange(ColorPannelBaList.Cast<object>().ToArray());
            comboBox6.Items.AddRange(HeightBoxList.Cast<object>().ToArray());

            int width = ShoppingCart.widthChosen;
            int depth = ShoppingCart.depthChosen;
            int numberOfLocker = ShoppingCart.boxNumberChosen;
            if (width < 62)
            {
                comboBox1.Enabled = false;
            }

            int maxHeight = 0;
            foreach (string heightB in HeightBracketsList)
            {
                int heightBP = Int32.Parse(heightB);
                if (heightBP>maxHeight)
                {
                    maxHeight = heightBP;
                }
            }
            textBox4.Text = "max : " + maxHeight.ToString() + " cm";
            textBox2.Text = "width = " + width.ToString() + " cm";
            textBox5.Text = "depth = " + depth.ToString() + " cm";
            textBox6.Text = "height = ";
            textBox8.Text = "0";
            /*
            List<TextBox> preview= new List<TextBox>();
            preview.Add(textBox4);
            preview.Add(textBox5);
            preview.Add(textBox6);
            preview.Add(textBox7);
            preview.Add(textBox8);
            preview.Add(textBox9);
            preview.Add(textBox10);
            foreach (TextBox t in preview)
            {
                t.Hide();
            }
            */

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //ComponentColor c =ShoppingCart.cupboard.colorAngleBracket;
            int width = ShoppingCart.widthChosen;
            int depth = ShoppingCart.depthChosen;
            int numberOfLocker = ShoppingCart.boxNumberChosen;

            int currentLocker = Int32.Parse(textBox12.Text);

            

            //AngleBracket a = ShoppingCart.cupboard.getAngleBracket();
            //ErrorWindow test = new ErrorWindow(width.ToString()+" "+depth.ToString());
            //ErrorWindow test2 = new ErrorWindow(a.ToString());
            //test.displayWindow();
            //test2.displayWindow();

            string doorsColor = comboBox1.SelectedItem.ToString();
            string panelColor = comboBox2.SelectedItem.ToString();
            int height = Int32.Parse(comboBox6.SelectedItem.ToString());
            dataGridView1.Rows.Add(currentLocker, height, doorsColor,panelColor);

            int totalHeight = Int32.Parse(textBox8.Text);
            totalHeight += height;
            textBox8.Text = totalHeight.ToString();
            if (currentLocker == numberOfLocker)
            {
                button2.Enabled = false;
            }
            currentLocker++;
            textBox12.Text =currentLocker.ToString();
            
            //pas encore utile, ne pas supprimer
            /*
            this.Hide();
            Form1 form = new Form1();
            form.Show();
            */
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form_locker_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
