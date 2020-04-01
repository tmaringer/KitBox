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

namespace kitbox_user_interface_V1
{
    public partial class Form_locker : Form
    {
        public Form_locker()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        public void button2_Click(object sender, EventArgs e)
        {
            
            //ComponentColor c =ShoppingCart.cupboard.colorAngleBracket;
            int width = ShoppingCart.cupboard.width;
            AngleBracket a = ShoppingCart.cupboard.getAngleBracket();
            //ErrorWindow test = new ErrorWindow(ColorParse.parseToStr(c)+width.ToString());
            //ErrorWindow test2 = new ErrorWindow(a.ToString());
            //test.displayWindow();
            //test2.displayWindow();
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
