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
                ComponentColor color1 = EnumParse.parseColorStrToEnum(comboBox4.SelectedItem.ToString());
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
                int height = Int32.Parse(comboBox5.SelectedItem.ToString());
                string doorsColor = comboBox6.SelectedItem.ToString();
                string panelColor = comboBox7.SelectedItem.ToString();
                int doorWidth = 0; ;
                if (doorsColor!="none")
                {
                    if (width >= 62)
                    {
                        if (width == 62)
                        {
                            doorWidth = 31;
                        }
                        else
                        {
                            doorWidth = width / 2 + 2;
                        }
                    }
                }

                Locker locker = new Locker();
               
                CatalogueDB cb = new CatalogueDB();
                
                Cleat cleat1 = (Cleat)cb.createComponents(height, 0, 0, "Cleat");
                if (doorsColor != "none")
                {
                    Door door1 = (Door)cb.createComponents(height, doorWidth, 0, EnumParse.parseColorStrToEnum(doorsColor), "Door");
                    locker.addComponent(new List<CatalogueComponents>() { door1, door1 });
                }
                Panels panelsHL = (Panels)cb.createComponents(0, width, depth, EnumParse.parseColorStrToEnum(panelColor), PanelsType.HL, "Panel");
                Panels panelsLR = (Panels)cb.createComponents(height, 0, depth, EnumParse.parseColorStrToEnum(panelColor), PanelsType.LR, "Panel");
                Panels panelsB = (Panels)cb.createComponents(height, width, 0, EnumParse.parseColorStrToEnum(panelColor), PanelsType.B, "Panel");

                CrossBar crossBarF = (CrossBar)cb.createComponents(0, width, 0, CrossBarType.F, "CrossBar");
                CrossBar crossBarB = (CrossBar)cb.createComponents(0, width, 0, CrossBarType.B, "CrossBar");
                CrossBar crossBarLR = (CrossBar)cb.createComponents(0, 0, depth, CrossBarType.LR, "CrossBar");

                
                 

                // numéro du casier sur lequel on travail
                int currentbox = locker.ID;


                locker.panelColor = EnumParse.parseColorStrToEnum(panelColor);
                locker.doorsColor = EnumParse.parseColorStrToEnum(doorsColor);
                locker.height = height;
                locker.depth = depth;
                locker.width = width;
                
                locker.addComponent(new List<CatalogueComponents>() { cleat1, cleat1, cleat1, cleat1,
                                                                        panelsHL, panelsHL, panelsLR,  panelsLR, panelsB,
                                                                        crossBarF, crossBarF, crossBarB, crossBarB,
                                                                        crossBarLR, crossBarLR, crossBarLR, crossBarLR });
                                                                        
                ShoppingCart.addCupboardComponent(locker);

                //premier essai de calcul de prix
                double prixTotal = locker.price;
                

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
                    ShoppingCart.getLockerByID(ShoppingCart.currentLocker).doorsColor = EnumParse.parseColorStrToEnum(doorsColor);
                    ShoppingCart.getLockerByID(ShoppingCart.currentLocker).panelColor = EnumParse.parseColorStrToEnum(panelColor);
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
            string ticket;
            foreach (ICupboardComponents component in ShoppingCart.cupboardComponentsList)
            {
                ticket = component.ToString();
                MessageBox.Show(ticket);
            }
            this.Hide();
            Form_purchase validation = new Form_purchase();
            validation.Show();
            validation.FormClosed += new FormClosedEventHandler(Form_purchase_FormClosed);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShoppingCart.currentLocker = dataGridView1.CurrentCell.RowIndex + 1;
            textBox8.Text = ShoppingCart.currentLocker.ToString();
        }

        void Form_purchase_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }

}
