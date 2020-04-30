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
        private static int currentLockerSelected;

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

            //todo chercher door width et mettre la plus grande en fonction

            if (width < 62)
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("none");
            }

            int maxHeight = 0;
            foreach (string heightB in HeightBracketsList)
            {
                int heightBP = Int32.Parse(heightB);
                if (heightBP > maxHeight)
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

        /// <summary>
        ///     Add locker button.
        /// </summary>
        public void button2_Click(object sender, EventArgs e)
        {
            int width = ShoppingCart.widthChosen;
            int depth = ShoppingCart.depthChosen;
            int numberOfLocker = ShoppingCart.boxNumberChosen;

            // check that the object fields are filled
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox6.SelectedItem != null)
            {
                Locker locker = new Locker();

                Cleat cleat1 = new Cleat();
                Door door1 = new Door();

                Panels panelsHB = new Panels();
                Panels panelsGD = new Panels();
                Panels panelsAR = new Panels();

                CrossBar crossBarAV = new CrossBar();
                CrossBar crossBarAR = new CrossBar();
                CrossBar crossBarGD = new CrossBar();


                string doorsColor = comboBox1.SelectedItem.ToString();
                string panelColor = comboBox2.SelectedItem.ToString();
                int height = Int32.Parse(comboBox6.SelectedItem.ToString());

                // numéro du casier sur lequel on travail
                int currentbox = locker.lockerID;

                cleat1.size = new ComponentSize(height, width, 0);
                door1.size = new ComponentSize(height, width, 0);

                panelsHB.size = new ComponentSize(0, width, depth);
                panelsHB.type = PanelsType.top;
                panelsGD.size = new ComponentSize(height, 0, depth);
                panelsGD.type = PanelsType.side;
                panelsAR.size = new ComponentSize(height, width, 0);
                panelsAR.type = PanelsType.back;

                crossBarAV.size = new ComponentSize(0, width, 0);
                crossBarAV.type = CrossBarType.front_back;
                crossBarAR.size = new ComponentSize(0, width, 0);
                crossBarAR.type = CrossBarType.front_back;
                crossBarGD.size = new ComponentSize(0, 0, depth);
                crossBarGD.type = CrossBarType.side;

                locker.addComponent(new List<CatalogueComponents>() { cleat1, cleat1, cleat1, cleat1, 
                                                                        door1, door1,
                                                                        panelsHB, panelsHB, panelsGD,  panelsGD, panelsAR,
                                                                        crossBarAV, crossBarAV, crossBarAR, crossBarAR,
                                                                        crossBarGD, crossBarGD, crossBarGD, crossBarGD });
                ShoppingCart.addCupboardComponent(locker);

                // met dans le order preveiw
                dataGridView1.Rows.Add(currentbox, height, doorsColor, panelColor);

                int totalHeight = Int32.Parse(textBox8.Text);
                totalHeight += height + 4;
                textBox8.Text = totalHeight.ToString();
                if (currentbox == numberOfLocker)
                {
                    button2.Enabled = false;
                }
                else
                {
                    currentbox++;
                    textBox12.Text = currentbox.ToString();
                }



                int maxHeight = Int32.Parse(textBox9.Text);
                List<string> choiceRemove = new List<string>();
                foreach (string heightChoice in comboBox6.Items)
                {
                    int boxHeight = Int32.Parse(heightChoice);
                    if (maxHeight - boxHeight - 4 < totalHeight)
                    {
                        choiceRemove.Add(heightChoice);
                    }

                }
                foreach (string heightChoice in choiceRemove)
                {
                    comboBox6.Items.Remove(heightChoice);
                }
            }
            else
            {
                MessageBox.Show("Fill every choices");
            }
            if (!button2.Enabled)
            {
                button1.Visible = true;
                button1.Enabled = true;
                button3.Visible = true;
                button3.Enabled = true;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentLockerSelected = (dataGridView1.CurrentCell.RowIndex + 1);
            textBox12.Text = currentLockerSelected.ToString();
        }

        private void Form_locker_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///     Validate cupboard button.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 form_1 = new Form1();
            form_1.Show();
        }

        /// <summary>
        ///     Modify cupboard button.
        /// </summary>
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

        /// <summary>
        ///     Save changes button.
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            /*
             * button 4 hides button 2 in form_locker.designer
             */

            int currentLocker = Int32.Parse(textBox12.Text);

            int formerHeight = Int32.Parse(dataGridView1[1, currentLocker - 1].Value.ToString());
            int totalHeight = Int32.Parse(textBox8.Text);
            int maxHeight = Int32.Parse(textBox9.Text);

            Locker locker = new Locker();

            foreach(ICupboardComponents component in ShoppingCart.cupboardComponentsList)
            {
                if(component is Locker)
                    if(((Locker)component).lockerID == currentLockerSelected)
                        locker = (Locker)component;
            }

            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox6.SelectedItem != null)
            {
                string doorsColor = comboBox1.SelectedItem.ToString();
                string panelColor = comboBox2.SelectedItem.ToString();
                int height = Int32.Parse(comboBox6.SelectedItem.ToString());

                if (totalHeight - formerHeight - 4 + height < maxHeight)
                {
                    //save changes
                    totalHeight -= formerHeight;
                    totalHeight += height;
                    textBox8.Text = totalHeight.ToString();
                    dataGridView1.Rows[currentLocker - 1].SetValues(currentLocker, height, doorsColor, panelColor);

                    locker.height = height;
                    locker.doorsColor = ColorParse.parseToEnum(doorsColor);
                    locker.panelColor = ColorParse.parseToEnum(panelColor);
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
