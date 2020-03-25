using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projectCS;

namespace ShopInterface
{
    public partial class Form3 : Form
    {
        public Form3(string value)
        {
            InitializeComponent();
            ninja(value);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void ninja(string value)
        {
            label1.Text = value;
            label5.Text = DBUtils.RefList("Ref", "kitbox where Code = \"" + value + "\"")[0];
            label6.Text = DBUtils.RefList("Dimensions", "kitbox where Code = \"" + value + "\"")[0];
            label7.Text = DBUtils.RefList("Colour", "kitbox where Code = \"" + value + "\"")[0];
            if (label5.Text == "AngleBracket")
            {
                if (label7.Text == "White")
                {
                    pictureBox1.Image = Properties.Resources.Corniere_blanc;
                }
                else if (label7.Text == "Brown")
                {
                    pictureBox1.Image = Properties.Resources.Corniere_brown;
                }
                else if (label7.Text == "Galvanised")
                {
                    pictureBox1.Image = Properties.Resources.Corniere_galv;
                }
                else if (label7.Text == "Black")
                {
                    pictureBox1.Image = Properties.Resources.Corniere_black;
                }
            }
            else if (label5.Text == "Panel LR" || label5.Text == "Panel HL" || label5.Text == "Panel B")
            {
                if (label7.Text == "White")
                {
                    pictureBox1.Image = Properties.Resources.panel_white;
                }
                else if (label7.Text == "Brown")
                {
                    pictureBox1.Image = Properties.Resources.panel_brown;
                }
            }
            else if (label5.Text == "Crossbar LR" || label5.Text == "Crossbar B")
            {
                pictureBox1.Image = Properties.Resources.traverse;
            }
            else if (label5.Text == "Crossbar F")
            {
                pictureBox1.Image = (Image) Properties.Resources.traverse_av;
            }
            else if (label5.Text == "Cleat")
            {
                pictureBox1.Image = Properties.Resources.Tasseau;
            }
            else if (label5.Text == "Cup")
            {
                pictureBox1.Image = Properties.Resources.coupelle;
            }
            else if (label5.Text == "Door")
            {
                if (label7.Text == "White")
                {
                    pictureBox1.Image = Properties.Resources.porte_blanc;
                }
                else if (label7.Text == "Brown")
                {
                    pictureBox1.Image = Properties.Resources.porte_brown;
                }
                else if (label7.Text == "Glass")
                {
                    pictureBox1.Image = Properties.Resources.porte_verre;
                }
            }
        }
    }
}
