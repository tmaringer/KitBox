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
        public Form2(Form1 form1)
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_Click);
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            DataTable ninja = new DataTable();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
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

            dataGridView2.DataSource = DBUtils.RefreshDB("customers natural join orders");
            
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Updating the Label which displays the current time 
            DateTime dateToDisplay = DateTime.Now;
            label13.Text = dateToDisplay.ToString("F", CultureInfo.CreateSpecificCulture("en-US"));
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
            this.label4.Text = DBUtils.UpdateDB(dataGridView1, "kitbox", textBox1, textBox2, textBox3);
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
            label5.Text = DBUtils.DeleteRow(dataGridView1, "kitbox", textBox6);
            dataGridView1.DataSource = DBUtils.RefreshDB("kitbox");
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
            Dictionary<string, int> Values = DBUtils.SelectCondDB("sales", textBox5.Text);
            if (comboBox1.SelectedItem == "day")
            {
                while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
                chart1.Series.Add(textBox5.Text);
                chart1.Series[textBox5.Text].Color = Color.Black;

                foreach (KeyValuePair<string, int> entry in Values)
                {
                    chart1.Series[textBox5.Text].Points.AddXY(entry.Key, entry.Value);
                }
                chart1.Titles.Add(textBox5.Text + " per day");
                if (comboBox2.SelectedItem != null)
                {
                    label14.Text = Values[comboBox2.SelectedItem.ToString()].ToString();
                }
            }
            else if (comboBox1.SelectedItem == "month")
            {
                while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
                chart1.Series.Add(textBox5.Text);
                chart1.Series[textBox5.Text].Color = Color.Black;
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
                    chart1.Series[textBox5.Text].Points.AddXY(entry.Key, entry.Value);
                }
                chart1.Titles.Add(textBox5.Text + " per month");
                if (comboBox2.SelectedItem != null)
                {
                    label14.Text = GraphMonth[comboBox2.SelectedItem.ToString()].ToString();
                }
                int all = GraphMonth[months[months.Count-2]] + GraphMonth[months[(months.Count - 3)]] + GraphMonth[months[(months.Count - 4)]] + GraphMonth[months[(months.Count - 5)]] + GraphMonth[months[(months.Count - 6)]] + GraphMonth[months[(months.Count - 7)]];
                double average = all / 6;
                chart1.Series[textBox5.Text].Points.AddXY("Average of last 6 months", average);
                chart1.Series[textBox5.Text].Points.FindByValue(average).Color = Color.LimeGreen;
                chart1.Series[textBox5.Text].Points.FindByValue(average).IsValueShownAsLabel = true;
                chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            }
            else if (comboBox1.SelectedItem == "year")
            {
                while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
                chart1.Series.Add(textBox5.Text);
                chart1.Series[textBox5.Text].Color = Color.Black;
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
                    chart1.Series[textBox5.Text].Points.AddXY(entry.Key, entry.Value);
                }
                chart1.Titles.Add(textBox5.Text + " per year");
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
            }
            else if (tabControl1.SelectedTab.Text == "Orders management")
            {
                dataGridView2.DataSource = DBUtils.RefreshDB("customers natural join orders");
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells["Status"].Value.Equals("true"))
                    {
                        row.Cells["Status"].Style.BackColor = Color.LimeGreen;
                    }
                    else if (row.Cells["Status"].Value.Equals("false"))
                    {
                        row.Cells["Status"].Style.BackColor = Color.Red;
                    }

                    else if (row.Cells["Status"].Value.Equals("done"))
                    {
                        row.Cells["Status"].Style.BackColor = Color.DeepSkyBlue;
                    }

                }
            }
            else if (tabControl1.SelectedTab.Text == "Stock management")
            {
                dataGridView4.Visible = false;
                groupBox5.Visible = false;
                label15.Visible = true;
                dataGridView4.DataSource = DBUtils.RefreshDBPartial("kitbox", "Ref, Code, EnStock, StockMinimum");
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
                dataGridView3.DataSource = DBUtils.RefreshDBCond("listsitems", "OrderId = " + textBox7.Text);
                dataGridView3.Columns["OrderId"].Visible = false;
                dataGridView3.CurrentCell.Selected = false;
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Cells["Disponibility"].Value.Equals("true"))
                    {
                        row.Cells["Disponibility"].Style.BackColor = Color.LimeGreen;
                    }
                    else if (row.Cells["Disponibility"].Value.Equals("false"))
                    {
                        row.Cells["Disponibility"].Style.BackColor = Color.Red;
                    }

                    else if (row.Cells["Disponibility"].Value.Equals("done"))
                    {
                        row.Cells["Disponibility"].Style.BackColor = Color.DeepSkyBlue;
                    }
                }
                label17.Text = "Done";
            }
            catch
            {
                label17.Text = "Error";
            }
        }
    }
}
