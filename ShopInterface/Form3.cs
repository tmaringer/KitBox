using System.Windows.Forms;
using projectCS;

namespace ShopInterface
{
    public partial class Form3 : Form
    {
        public Form3(string value)
        {
            InitializeComponent();
            GetPicture(value);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void GetPicture(string value)
        {
            label1.Text = value;
            label5.Text = DbUtils.RefList("Ref", "kitbox where Code = \"" + value + "\"")[0];
            label6.Text = DbUtils.RefList("Dimensions", "kitbox where Code = \"" + value + "\"")[0];
            label7.Text = DbUtils.RefList("Colour", "kitbox where Code = \"" + value + "\"")[0];
            if (label5.Text == @"AngleBracket")
            {
                if (label7.Text == @"White")
                {
                    pictureBox1.Image = Properties.Resources.Corniere_blanc;
                }
                else if (label7.Text == @"Brown")
                {
                    pictureBox1.Image = Properties.Resources.Corniere_brown;
                }
                else if (label7.Text == @"Galvanised")
                {
                    pictureBox1.Image = Properties.Resources.Corniere_galv;
                }
                else if (label7.Text == @"Black")
                {
                    pictureBox1.Image = Properties.Resources.Corniere_black;
                }
            }
            else if (label5.Text == @"Panels LR" || label5.Text == @"Panels HL" || label5.Text == @"Panels B")
            {
                if (label7.Text == @"White")
                {
                    pictureBox1.Image = Properties.Resources.panel_white;
                }
                else if (label7.Text == @"Brown")
                {
                    pictureBox1.Image = Properties.Resources.panel_brown;
                }
            }
            else if (label5.Text == @"Crossbar LR" || label5.Text == @"Crossbar B")
            {
                pictureBox1.Image = Properties.Resources.traverse;
            }
            else if (label5.Text == @"Crossbar F")
            {
                pictureBox1.Image = Properties.Resources.traverse_av;
            }
            else if (label5.Text == @"Cleat")
            {
                pictureBox1.Image = Properties.Resources.Tasseau;
            }
            else if (label5.Text == @"Cup")
            {
                pictureBox1.Image = Properties.Resources.coupelle;
            }
            else if (label5.Text == @"Door")
            {
                if (label7.Text == @"White")
                {
                    pictureBox1.Image = Properties.Resources.porte_blanc;
                }
                else if (label7.Text == @"Brown")
                {
                    pictureBox1.Image = Properties.Resources.porte_brown;
                }
                else if (label7.Text == @"Glass")
                {
                    pictureBox1.Image = Properties.Resources.porte_verre;
                }
            }
        }
    }
}
