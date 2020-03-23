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
            label7.Text = DBUtils.RefList("Couleur", "kitbox where Code = \"" + value + "\"")[0];
            if (label5.Text == "Cornieres")
            {
                if (label7.Text == "Blanc")
                {
                    pictureBox1.Image = Properties.Resources.Corniere_blanc;
                }
                else if (label7.Text == "Brun")
                {
                    pictureBox1.Image = Properties.Resources.Corniere_brown;
                }
                else if (label7.Text == "Galvanise")
                {
                    pictureBox1.Image = Properties.Resources.Corniere_galv;
                }
                else if (label7.Text == "Noir")
                {
                    pictureBox1.Image = Properties.Resources.Corniere_black;
                }
            }
            else if (label5.Text == "Panneau GD" || label5.Text == "Panneau HB" || label5.Text == "Panneau Ar")
            {
                if (label7.Text == "Blanc")
                {
                    pictureBox1.Image = Properties.Resources.panel_white;
                }
                else if (label7.Text == "Brun")
                {
                    pictureBox1.Image = Properties.Resources.porte_brown;
                }
            }
            else if (label5.Text == "Traverse GD" || label5.Text == "Traverse Ar")
            {
                pictureBox1.Image = Properties.Resources.traverse;
            }
            else if (label5.Text == "Traverse Av")
            {
                pictureBox1.Image = (Image) Properties.Resources.Tasseau;
            }
            else if (label5.Text == "Tasseau")
            {
                pictureBox1.Image = Properties.Resources.Tasseau;
            }
            else if (label5.Text == "Porte")
            {
                if (label7.Text == "Blanc")
                {
                    pictureBox1.Image = Properties.Resources.porte_blanc;
                }
                else if (label7.Text == "Brun")
                {
                    pictureBox1.Image = Properties.Resources.porte_brown;
                }
                else if (label7.Text == "Verre")
                {
                    pictureBox1.Image = Properties.Resources.porte_verre;
                }
            }
        }
    }
}
