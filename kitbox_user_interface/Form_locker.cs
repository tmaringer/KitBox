﻿using projectCS;
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
            comboBox1.Items.Add("none");
            comboBox2.Items.AddRange(ColorPannelBaList.Cast<object>().ToArray());
            comboBox6.Items.AddRange(HeightBoxList.Cast<object>().ToArray());

            int width = ShoppingCart.widthChosen;
            int depth = ShoppingCart.depthChosen;
            int numberOfLocker = ShoppingCart.boxNumberChosen;
            if (width < 62)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("none");
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
            textBox9.Text = maxHeight.ToString();
            textBox2.Text = "width = " + width.ToString() + " cm";
            textBox5.Text = "depth = " + depth.ToString() + " cm";
            textBox6.Text = "height = ";
            textBox8.Text = "0";

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

            /* -------------------------------------------------------------   exemple de comment faire
            Door dorxxxx = new Door();
            Panels panelxxxx = new Panels();

            dorxxxx.color = ColorParse.parseToEnum(comboBox1.SelectedItem.ToString());
            panelxxxx.color = ColorParse.parseToEnum(comboBox2.SelectedItem.ToString());
            //attention ne prends pas en compte le choix "none"
            // -------------------------------------------------------------   exemple de comment faire
            */


            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox6.SelectedItem != null)
            {
                string doorsColor = comboBox1.SelectedItem.ToString();
                string panelColor = comboBox2.SelectedItem.ToString();
                int height = Int32.Parse(comboBox6.SelectedItem.ToString());
                dataGridView1.Rows.Add(currentLocker, height, doorsColor, panelColor);
                
                int totalHeight = Int32.Parse(textBox8.Text);
                totalHeight += height +4;
                textBox8.Text = totalHeight.ToString();
                if (currentLocker == numberOfLocker)
                {
                    button2.Enabled = false;
                }
                currentLocker++;
                textBox12.Text = currentLocker.ToString();


                int maxHeight = Int32.Parse(textBox9.Text);
                List<string> choiceRemove = new List<string>();
                foreach(string heightChoice in comboBox6.Items)
                {
                    int boxHeight = Int32.Parse(heightChoice);
                    if (maxHeight - boxHeight -4 < totalHeight)
                    {
                        choiceRemove.Add(heightChoice);
                    }
                    
                }
                foreach(string heightChoice in choiceRemove)
                {
                    comboBox6.Items.Remove(heightChoice);
                }
            }
            else
            {
                MessageBox.Show("Fill every choices");
            }


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
            MessageBox.Show(dataGridView1.CurrentCell.RowIndex.ToString());
        }

        private void Form_locker_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
