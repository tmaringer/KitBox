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
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using projectCS;
using projectCS.Tools_class;

namespace kitbox_user_interface_V1
{
    public partial class User_Interface : Form
    {
        public User_Interface()
        {
            InitializeComponent();
            string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
            MySqlConnection conn = new MySqlConnection(MyConString);
            conn.Open();
            List<string> WidthBoxList = QueryKitbox.SpecsBoxList(conn, "Width", "Ref = \"Panel B\"");
            conn.Close();
            conn.Open();
            List<string> DepthBoxList = QueryKitbox.SpecsBoxList(conn, "Depth", "Ref = \"Panel LR\"");
            conn.Close();
            conn.Open();
            List<string> BracketsColorList = QueryKitbox.SpecsBoxList(conn, "Colour", "Ref = \"AngleBracket\"");
            conn.Close();
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
            
            comboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7" });
            //TODO : get variable globale max_lockers puis boucle pour remplir combobox3
            comboBox2.Items.AddRange(WidthBoxList.Cast<object>().ToArray());
            comboBox3.Items.AddRange(DepthBoxList.Cast<object>().ToArray());
            comboBox4.Items.AddRange(BracketsColorList.Cast<object>().ToArray());
            comboBox5.Items.AddRange(HeightBoxList.Cast<object>().ToArray());
            comboBox6.Items.AddRange(ColorDoorList.Cast<object>().ToArray());
            comboBox6.Items.Add("none");
            comboBox7.Items.AddRange(ColorPannelBaList.Cast<object>().ToArray());

            //todo chercher door width et mettre la plus grande en fonction
            
            int maxHeight = 0;
            foreach (string heightB in HeightBracketsList)
            {
                int heightBP = Int32.Parse(heightB);
                if (heightBP > maxHeight)
                {
                    maxHeight = heightBP;
                }
            }
            textBox12.Text = "0";
            textBox14.Text = maxHeight.ToString();
            textBox16.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            bool choice_fill = false;

            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null && comboBox4.SelectedItem != null)
            {
                ComponentColor color1 = ColorParse.parseToEnum(comboBox4.SelectedItem.ToString());
                int numberOfLockers = Int32.Parse(comboBox1.SelectedItem.ToString());
                int width = Int32.Parse(comboBox2.SelectedItem.ToString());
                int depth = Int32.Parse(comboBox3.SelectedItem.ToString());

                ShoppingCart.addCupboardUserChoices(width, depth, numberOfLockers, color1);
                choice_fill = true;
            }
            else
            {
                MessageBox.Show("Fill every choices");
                button1.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
            }
            if (choice_fill)
            {
                int widthChosen = ShoppingCart.widthChosen;
                if (widthChosen < 62)
                {
                    comboBox6.Items.Clear();
                    comboBox6.Items.Add("none");
                }
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;
                comboBox8.Enabled = true;
                button2.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int width = ShoppingCart.widthChosen;
            int depth = ShoppingCart.depthChosen;
            int numberOfLocker = ShoppingCart.boxNumberChosen;

            // check that the object fields are filled
            if (comboBox5.SelectedItem != null && comboBox6.SelectedItem != null && comboBox7.SelectedItem != null)
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


                
                int height = Int32.Parse(comboBox5.SelectedItem.ToString());
                string doorsColor = comboBox6.SelectedItem.ToString();
                string panelColor = comboBox7.SelectedItem.ToString();

                // numéro du casier sur lequel on travail
                int currentbox = locker.ID;


                locker.panelColor = ColorParse.parseToEnum(panelColor);
                locker.doorsColor = ColorParse.parseToEnum(doorsColor);
                locker.height = height;
                locker.depth = depth;
                locker.width = width;

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

                //premier essai de calcul de prix
                float prixTotal = 0;
                foreach(CatalogueComponents component in locker.componentsList)
                {
                    try
                    {
                        string compHeight = component.size.height.ToString() ;
                        string compdepth = component.size.depth.ToString();
                        string compWidth =component.size.width.ToString() ;
                        string compColour = "white";//TODO fill with colour
                        string reference = "";
                        string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
                        MySqlConnection conn = new MySqlConnection(MyConString);
                        conn.Open();
                        List<string> prix = QueryKitbox.BigMoney(conn, reference, compHeight, compdepth, compWidth, compColour);
                        conn.Close();
                        float compoPrix = Single.Parse(prix[0]);
                        prixTotal += compoPrix;
                    }
                    catch
                    {
                        MessageBox.Show("fail");
                    }
                }





                // met dans le order preview
                dataGridView1.Rows.Add(currentbox, height, doorsColor, panelColor,prixTotal.ToString());

                int totalHeight = Int32.Parse(textBox12.Text);
                totalHeight += height + 4;
                textBox12.Text = totalHeight.ToString();
                if (currentbox == numberOfLocker)
                {
                    button2.Enabled = false;
                }
                else
                {
                    currentbox++;
                    textBox8.Text = currentbox.ToString();
                }



                int maxHeight = Int32.Parse(textBox14.Text);
                List<string> choiceRemove = new List<string>();
                foreach (string heightChoice in comboBox5.Items)
                {
                    int boxHeight = Int32.Parse(heightChoice);
                    if (maxHeight - boxHeight - 4 < totalHeight)
                    {
                        choiceRemove.Add(heightChoice);
                    }

                }
                foreach (string heightChoice in choiceRemove)
                {
                    comboBox5.Items.Remove(heightChoice);
                }
            }
            else
            {
                MessageBox.Show("Fill every choices");
            }
            if (!button2.Enabled)
            {
                button3.Visible = true;
                button3.Enabled = true;
                button5.Visible = true;
                button5.Enabled = true;
            }
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
            comboBox5.Items.Clear();
            comboBox5.Items.AddRange(HeightBoxList.Cast<object>().ToArray());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int currentLocker = Int32.Parse(textBox8.Text);

            int formerHeight = Int32.Parse(dataGridView1[1, currentLocker - 1].Value.ToString());
            int totalHeight = Int32.Parse(textBox12.Text);
            int maxHeight = Int32.Parse(textBox14.Text);

            int incre = 1;

            if (ShoppingCart.currentLocker == 0)
                ShoppingCart.currentLocker = ShoppingCart.cupboardComponentsList.Count;


            if (comboBox5.SelectedItem != null && comboBox6.SelectedItem != null && comboBox7.SelectedItem != null)
            {

                int height = Int32.Parse(comboBox5.SelectedItem.ToString());
                string doorsColor = comboBox6.SelectedItem.ToString();
                string panelColor = comboBox7.SelectedItem.ToString();

                if (totalHeight - formerHeight - 4 + height < maxHeight)
                {
                    //save changes
                    totalHeight -= formerHeight;
                    totalHeight += height;
                    textBox12.Text = totalHeight.ToString();
                    dataGridView1.Rows[currentLocker - 1].SetValues(currentLocker, height, doorsColor, panelColor);

                    ShoppingCart.getLockerByID(ShoppingCart.currentLocker).height = height;
                    ShoppingCart.getLockerByID(ShoppingCart.currentLocker).doorsColor = ColorParse.parseToEnum(doorsColor);
                    ShoppingCart.getLockerByID(ShoppingCart.currentLocker).panelColor = ColorParse.parseToEnum(panelColor);
                    ShoppingCart.getLockerByID(ShoppingCart.currentLocker);
                }
                else
                    MessageBox.Show("Maximal height reached");
            }
            else
            {
                MessageBox.Show("Fill every choices");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ticket = "";
            foreach (ICupboardComponents component in ShoppingCart.cupboardComponentsList)
            {
                ticket = component.ToString();
                MessageBox.Show(ticket);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShoppingCart.currentLocker = dataGridView1.CurrentCell.RowIndex + 1;
            textBox8.Text = ShoppingCart.currentLocker.ToString();
        }

        
    }

}
