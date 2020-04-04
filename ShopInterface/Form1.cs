using System;
using System.Windows.Forms;
using projectCS;
using projectCS.Tools_class;

namespace ShopInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            var value = DbUtils.CheckAccess(textBox1.Text, textBox2.Text);
            if (value == 0)
            {
                var frm = new Form2(textBox1.Text);
                frm.Show();
                Hide();
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}