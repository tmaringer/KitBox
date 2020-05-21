﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using projectCS;
using projectCS.Tools_class;

namespace kitbox_user_interface_V1
{
    public partial class Form_purchase : Form
    {
        public Form_purchase()
        {
            InitializeComponent();

            int totalHeight = 0;
            Locker locker;
            foreach(ICupboardComponents cupCompo in ShoppingCart.cupboardComponentsList)
            {
                if(cupCompo is Locker)
                {
                    locker = (Locker)cupCompo;

                    int currentbox = locker.ID;
                    string height = locker.height.ToString();
                    //string depth = locker.depth.ToString();
                    string doorsColor = EnumParse.parseColorEnumToStr(locker.doorsColor);
                    string panelColor = EnumParse.parseColorEnumToStr(locker.panelColor);
                    string price = locker.price.ToString();

                    totalHeight += locker.height;

                    dataGridView1.Rows.Add(currentbox, height, doorsColor,false, panelColor, price);
                }
            }
            string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
            MySqlConnection conn = new MySqlConnection(MyConString);
            conn.Open();
            List<string> HeightBracketsList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"AngleBracket\"");
            conn.Close();
            int angleBracketHeight=0;
            int diff;
            int minDiff=1000;
            foreach(string heightBracket in HeightBracketsList)
            {
                diff = Int32.Parse(heightBracket) - totalHeight;
                if (diff > 0 && diff <minDiff)
                {
                    minDiff = diff;
                    angleBracketHeight = Int32.Parse(heightBracket);
                }
            }
            MessageBox.Show(angleBracketHeight.ToString());
            //TODO create object anglebracket with color1
            //TODO request price
            //TODO add anglebrackets Price
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string fname =textBox3.Text;
            string lname = textBox5.Text;

            //TODO create client in form order
            //TODO add client to DB

            //TODO shoppingCart.reset()

            this.Close();
        }

    }
}
