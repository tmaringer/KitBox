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

            button4.Visible = false;
            button4.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        public void button2_Click(object sender, EventArgs e)
        {
            /*
             * le button 4 cache le button 2 dans form_locker.designer
             */

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
                else
                {
                    currentLocker++;
                    textBox12.Text = currentLocker.ToString();
                }
                


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
            if(!button2.Enabled)
            {
                button1.Visible = true;
                button1.Enabled = true;
                button3.Visible = true;
                button3.Enabled = true;
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
            
            textBox12.Text = (dataGridView1.CurrentCell.RowIndex + 1).ToString();
        }

        private void Form_locker_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //créer les objets
            this.Hide();
            Form1 form_1 = new Form1();
            form_1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button2.Enabled = false;
            button4.Visible = true;
            button4.Enabled = true;
            string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
            MySqlConnection conn = new MySqlConnection(MyConString);
            conn.Open();
            List<string> HeightBoxList = QueryKitbox.SpecsBoxList(conn, "Height", "Ref = \"Panel B\"");
            conn.Close();
            comboBox6.Items.Clear();
            comboBox6.Items.AddRange(HeightBoxList.Cast<object>().ToArray());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
             * le button 4 cache le button 2 dans form_locker.designer
             */
            

            int currentLocker = Int32.Parse(textBox12.Text);
            int formerHeight = Int32.Parse(dataGridView1[1, currentLocker - 1].Value.ToString());
            int totalHeight = Int32.Parse(textBox8.Text);
            int maxHeight = Int32.Parse(textBox9.Text);

            //vérifier que tout soit rempli [OK]
            //proposer toutes les hauteurs [OK]
            /*
             * pour ce faire : supprimer toutes les entrées de combobox6
             * puis refaire une requête et ajouter toutes les entrée
             * le tout après avoir appuyé sur button3
             */
            //gérer si choix de hauteur inadéquat -> message box (+hauteur max red ?)

            //une fois un choix correct effectué
            //supprimer formerHeight+4 de la hauteur totale
            //ajouter la nouvelle hauteur
            //enregistrer les autres modifications dans la datagridview


            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox6.SelectedItem != null)
            {
                string doorsColor = comboBox1.SelectedItem.ToString();
                string panelColor = comboBox2.SelectedItem.ToString();
                int height = Int32.Parse(comboBox6.SelectedItem.ToString());
                if (totalHeight - formerHeight - 4 + height < maxHeight)
                {
                    //save changes
                }
                else
                    MessageBox.Show("Maximal height reached");
            }
            else
            {
                MessageBox.Show("Fill every choices");
            }
        }
    }
}
