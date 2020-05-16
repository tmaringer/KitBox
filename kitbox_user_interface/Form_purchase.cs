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
using projectCS.Tools_class;

namespace kitbox_user_interface_V1
{
    public partial class Form_purchase : Form
    {
        public Form_purchase()
        {
            InitializeComponent();
            int i;
            for(i=1;i< ShoppingCart.cupboardComponentsList.Count;i++)
            {
                Locker box = ShoppingCart.getLockerByID(i);
                string currentbox = i.ToString();
                string height = box.height.ToString();

                //TODO : ajouter les doorsColor et panelColor aux locker?

                //string doorsColor =  EnumParse.parseColorEnumToStr(box.doorsColor);
                //string panelColor = EnumParse.parseColorEnumToStr(box.panelColor);

                string price = box.price.ToString();

                //dataGridView1.Rows.Add(currentbox, height, doorsColor, panelColor, price);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string fname =textBox3.Text;
            string lname = textBox5.Text;

            //TODO : voir avec Thibaut quoi faire du nom

            //shoppingCart.rest() ?

            this.Close();
        }

    }
}
