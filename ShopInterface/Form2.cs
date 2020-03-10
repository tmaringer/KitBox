using projectCS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Threading;
using Color = System.Drawing.Color;

namespace ShopInterface
{
    public partial class Form2 : Form
    {
        private int x = 1;
        private List<string> Columns = new List<string>();
        private List<string> Types = new List<string>();
        private List<string> Elements = new List<string>();
        private List<string> ColumnYear = new List<string>();
        private List<string> ColumnMonth = new List<string>();
        private List<string> ColumnDay = new List<string>();
        public Form2(Form1 form1, string user)
        {
            InitializeComponent();
            label28.Text = user;
            label28.Visible = true;
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_Click);
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            DataTable ninja = new DataTable();
            dataGridView4.DataSource = DBUtils.RefreshDBPartial("kitbox", "Ref, Code, EnStock, StockMinimum");
            dataGridView1.DataSource = DBUtils.RefreshDB("kitbox");
            ninja = DBUtils.RefreshDB("sales");
            foreach (DataColumn col in ninja.Columns)
            {
                if (col.ColumnName.ToString() != "Code" && col.ColumnName.ToString() != "Ref")
                {
                    string value = col.ColumnName.Split('/')[2].ToString();
                    
                    if (ColumnYear.Contains(value) == false)
                    {
                        ColumnYear.Add(value);
                    }
                    string valueMonth = col.ColumnName.Split('/')[1].ToString() + "/" +col.ColumnName.Split('/')[2].ToString();

                    if (ColumnMonth.Contains(valueMonth) == false)
                    {
                        ColumnMonth.Add(valueMonth);
                    }
                    ColumnDay.Add(col.ColumnName.ToString());
                }
                
            }
            Start();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            ComboBox senderComboBox = (ComboBox)sender;

            // Change the length of the text box depending on what the user has 
            // selected and committed using the SelectionLength property.
            if (senderComboBox.SelectionLength > 0)
            {
                if (comboBox1.SelectedItem == "year")
                {
                    foreach (string year in ColumnYear)
                    {
                        comboBox2.Items.Add(year);
                    }
                }
                if (comboBox1.SelectedItem == "month")
                {
                    foreach (string month in ColumnMonth)
                    {
                        comboBox2.Items.Add(month);
                    }
                }
                if (comboBox1.SelectedItem == "day")
                {
                    foreach (string day in ColumnDay)
                    {
                        comboBox2.Items.Add(day);
                    }
                }
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label4.Text = DBUtils.UpdateDB(dataGridView1, "kitbox", comboBox12.SelectedItem.ToString(), "Code = \"" + comboBox11.SelectedItem.ToString() + "\"", textBox3.Text);
            dataGridView1.DataSource = DBUtils.RefreshDB("kitbox");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Enabled = DBUtils.SearchDB(dataGridView1, textBox10);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            button4.Enabled = DBUtils.StopSearchDB(dataGridView1, textBox10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = DBUtils.DeleteRow(dataGridView1, "kitbox", comboBox10.SelectedItem.ToString());
            dataGridView1.DataSource = DBUtils.RefreshDB("kitbox");
            comboBox10.SelectedItem = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label9.Text = DBUtils.AddRow(Elements, Types, Columns, "kitbox");
            dataGridView1.DataSource = DBUtils.RefreshDB("kitbox");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            x = DBUtils.AddItem(label7, x, dataGridView1, Columns, Types, Elements, button7, textBox4, listView1, button6, progressBar1, button3);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            x = DBUtils.DeleteItem(label7, x, dataGridView1, textBox4, button6, button7, Columns, Types, Elements, listView1, progressBar1, button3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            if (chart1.Titles.Count > 0) { chart1.Titles.RemoveAt(0); };
            Dictionary<string, int> Values = DBUtils.SelectCondDB("sales", comboBox3.SelectedItem.ToString());
            if (comboBox1.SelectedItem == "day")
            {
                while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
                chart1.Series.Add(comboBox3.SelectedItem.ToString());
                chart1.Series[comboBox3.SelectedItem.ToString()].Color = Color.Black;

                foreach (KeyValuePair<string, int> entry in Values)
                {
                    chart1.Series[comboBox3.SelectedItem.ToString()].Points.AddXY(entry.Key, entry.Value);
                }
                chart1.Titles.Add(comboBox3.SelectedItem.ToString() + " per day");
                if (comboBox2.SelectedItem != null)
                {
                    label14.Text = Values[comboBox2.SelectedItem.ToString()].ToString();
                }
            }
            else if (comboBox1.SelectedItem == "month")
            {
                while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
                chart1.Series.Add(comboBox3.SelectedItem.ToString());
                chart1.Series[comboBox3.SelectedItem.ToString()].Color = Color.Black;
                Dictionary<string, int> GraphMonth = new Dictionary<string, int>();
                foreach (KeyValuePair<string, int> entry in Values)
                {
                    string key = entry.Key;
                    string month = key.Split('/')[1] + "/" + key.Split('/')[2];
                    if (GraphMonth.ContainsKey(month))
                    {
                        GraphMonth[month] = GraphMonth[month] + entry.Value;
                    }
                    else
                    {
                        GraphMonth.Add(month, entry.Value);
                    }
                }
                List<string> months = new List<string>();
                foreach (KeyValuePair<string, int> entry in GraphMonth)
                {
                    months.Add(entry.Key);
                    chart1.Series[comboBox3.SelectedItem.ToString()].Points.AddXY(entry.Key, entry.Value);
                }
                chart1.Titles.Add(comboBox3.SelectedItem.ToString() + " per month");
                if (comboBox2.SelectedItem != null)
                {
                    label14.Text = GraphMonth[comboBox2.SelectedItem.ToString()].ToString();
                }
                int all = GraphMonth[months[months.Count-2]] + GraphMonth[months[(months.Count - 3)]] + GraphMonth[months[(months.Count - 4)]] + GraphMonth[months[(months.Count - 5)]] + GraphMonth[months[(months.Count - 6)]] + GraphMonth[months[(months.Count - 7)]];
                double average = all / 6;
                chart1.Series[comboBox3.SelectedItem.ToString()].Points.AddXY("Average of last 6 months", average);
                chart1.Series[comboBox3.SelectedItem.ToString()].Points.FindByValue(average).Color = Color.LimeGreen;
                chart1.Series[comboBox3.SelectedItem.ToString()].Points.FindByValue(average).IsValueShownAsLabel = true;
                chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            }
            else if (comboBox1.SelectedItem == "year")
            {
                while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
                chart1.Series.Add(comboBox3.SelectedItem.ToString());
                chart1.Series[comboBox3.SelectedItem.ToString()].Color = Color.Black;
                Dictionary<string, int> GraphMonth = new Dictionary<string, int>();
                foreach (KeyValuePair<string, int> entry in Values)
                {
                    string key = entry.Key;
                    string month = key.Split('/')[2];
                    if (GraphMonth.ContainsKey(month))
                    {
                        GraphMonth[month] = GraphMonth[month] + entry.Value;
                    }
                    else
                    {
                        GraphMonth.Add(month, entry.Value);
                    }
                }
                foreach (KeyValuePair<string, int> entry in GraphMonth)
                {
                    chart1.Series[comboBox3.SelectedItem.ToString()].Points.AddXY(entry.Key, entry.Value);
                }
                chart1.Titles.Add(comboBox3.SelectedItem.ToString() + " per year");
                if (comboBox2.SelectedItem != null)
                {
                    label14.Text = GraphMonth[comboBox2.SelectedItem.ToString()].ToString();
                }
            }
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Database management")
            {
                dataGridView1.DataSource = DBUtils.RefreshDB("kitbox");
                comboBox11.DataSource = DBUtils.RefList("Code", "kitbox");
                comboBox11.DisplayMember = "Code";
                comboBox11.Text = "";
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    comboBox12.Items.Add(col.Name.ToString());
                }
            }
            else if (tabControl1.SelectedTab.Text == "Orders management")
            {
                Start();
            }
            else if (tabControl1.SelectedTab.Text == "Stock management")
            {
                dataGridView4.DataSource = DBUtils.RefreshDBPartial("kitbox", "Ref, Code, EnStock, StockMinimum");
                comboBox3.DataSource = DBUtils.RefList("Code", "kitbox.sales");
                comboBox3.DisplayMember = "Code";
                ColoursDiff(dataGridView4, "EnStock", "StockMinimum");
                dataGridView4.CurrentCell.Selected = false;
                label15.Visible = false;
                dataGridView4.Visible = true;
                groupBox5.Visible = true;
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.DataSource = DBUtils.RefreshDBCond("listsitems", "OrderId = " + comboBox4.SelectedItem.ToString());
                foreach (DataGridViewColumn col in dataGridView3.Columns)
                {
                    col.Visible = true;
                }
                dataGridView3.Columns["OrderId"].Visible = false;
                dataGridView3.CurrentCell.Selected = false;
                Colours(dataGridView3, "Disponibility");
                label17.Text = "Done";
            }
            catch
            {
                label17.Text = "Error";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = DBUtils.RefreshDBCond("customers natural join orders natural join listsitems", "CustomerName = \"" + comboBox5.SelectedItem.ToString() + "\"");
            foreach(DataGridViewColumn col in dataGridView3.Columns)
            {
                col.Visible = true;
            }
            dataGridView3.Columns["ListItemsId"].Visible = false;
            dataGridView3.Columns["CustomerId"].Visible = false;
            dataGridView3.Columns["CustomerName"].Visible = false;
            dataGridView3.Columns["CustomerPhone"].Visible = false;
            dataGridView3.Columns["Status"].Visible = false;
            Colours(dataGridView3, "Disponibility");

        }
        private void Colours(DataGridView dataGridView3, string Column)
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Cells[Column].Value.Equals("true"))
                {
                    row.Cells[Column].Style.BackColor = Color.LimeGreen;
                }
                else if (row.Cells[Column].Value.Equals("false"))
                {
                    row.Cells[Column].Style.BackColor = Color.Red;
                }

                else if (row.Cells[Column].Value.Equals("closed"))
                {
                    row.Cells[Column].Style.BackColor = Color.DeepSkyBlue;
                }
                else if (row.Cells[Column].Value.Equals("pending"))
                {
                    row.Cells[Column].Style.BackColor = Color.Gold;
                }
                else if (row.Cells[Column].Value.Equals("awaiting for removal"))
                {
                    row.Cells[Column].Style.BackColor = Color.Fuchsia;
                }
            }
        }
        private void ColoursDiff(DataGridView dataGridView3, string Column, string ColumnB)
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if ((Convert.ToInt32(row.Cells[Column].Value) - Convert.ToInt32(row.Cells[ColumnB].Value)) > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LimeGreen;
                }
                else if ((Convert.ToInt32(row.Cells[Column].Value) - Convert.ToInt32(row.Cells[ColumnB].Value)) < 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }

                else if ((Convert.ToInt32(row.Cells[Column].Value) - Convert.ToInt32(row.Cells[ColumnB].Value)) == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Gold;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            dataGridView3.DataSource = DBUtils.RefreshDBCond("listsitems", "OrderId = \"" + comboBox4.SelectedItem.ToString() + "\"");
            foreach (DataGridViewColumn col in dataGridView3.Columns)
            {
                col.Visible = true;
            }
            int x = 0;
            int y = 0;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                List<string> EnStock = DBUtils.RefList("Enstock", "kitbox where Code = \"" + row.Cells["Code"].Value.ToString() + "\"");
                int Enstock = Convert.ToInt32(EnStock[0]);
                if ((Enstock - Convert.ToInt32(row.Cells["Quantity"].Value)) >= 0)
                {
                    row.Cells["Disponibility"].Style.BackColor = Color.LimeGreen;
                    row.Cells["Disponibility"].Value = "true";
                    DBUtils.UpdateDBV("listsitems", "Disponibility", "Code = \"" + row.Cells["Code"].Value.ToString() + "\"", "true");
                    y += 1;
                }
                else
                {
                    row.Cells["Disponibility"].Style.BackColor = Color.Red;
                    row.Cells["Disponibility"].Value = "false";
                    DBUtils.UpdateDBV("listsitems", "Disponibility", "Code = \"" + row.Cells["Code"].Value.ToString() + "\"", "false");
                }
                x += 1;
            }
            if (x == y)
            {
                DBUtils.UpdateDBV("orders", "Status", "OrderId = \"" + comboBox4.SelectedItem.ToString() + "\"", "true");
            }
            else
            {
                DBUtils.UpdateDBV("orders", "Status", "OrderId = \"" + comboBox4.SelectedItem.ToString() + "\"", "false");
            }
            Start();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Updating the Label which displays the current time 
            DateTime dateToDisplay = DateTime.Now;
            label13.Text = dateToDisplay.ToString("D", CultureInfo.CreateSpecificCulture("en-US")) + "\n" + dateToDisplay.ToString("t", CultureInfo.CreateSpecificCulture("en-US"));
            //time.Split(',');
            label13.Visible = true;
        }

        private void Start()
        {
            comboBox4.DataSource = DBUtils.RefList("OrderId", "orders where Status = \"pending\" or Status = \"false\"");
            comboBox4.DisplayMember = "OrderId";
            comboBox4.Text = "";
            comboBox6.DataSource = DBUtils.RefList("OrderId", "orders where Status = \"pending\"");
            comboBox6.DisplayMember = "OrderId";
            comboBox6.Text = "";
            comboBox7.DataSource = DBUtils.RefList("OrderId", "orders where Status = \"awaiting for removal\"");
            comboBox7.DisplayMember = "OrderId";
            comboBox7.Text = "";
            comboBox8.DataSource = DBUtils.RefList("OrderId", "orders");
            comboBox8.DisplayMember = "OrderId";
            comboBox8.Text = "";
            comboBox10.DataSource = DBUtils.RefList("Code", "kitbox");
            comboBox10.DisplayMember = "Code";
            comboBox10.Text = "";
            comboBox5.DataSource = DBUtils.RefListND("CustomerName", "customers natural join orders");
            comboBox5.DisplayMember = "CustomerName";
            comboBox5.Text = "";
            dataGridView2.DataSource = DBUtils.RefreshDB("customers natural join orders");
            dataGridView2.Refresh();
            dataGridView2.Sort(dataGridView2.Columns["OrderId"], System.ComponentModel.ListSortDirection.Descending);
            Colours(dataGridView2, "Status");
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            label21.Text = DBUtils.UpdateDB(dataGridView2, "customers natural join orders", "Status", "OrderId = \"" + comboBox6.SelectedItem.ToString() + "\"", "false");
            Start();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label26.Text = DBUtils.UpdateDB(dataGridView2, "customers natural join orders", "Status", "OrderId = \"" + comboBox7.SelectedItem.ToString() + "\"", "closed");
            Start();
        }
    }
}
