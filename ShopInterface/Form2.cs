using projectCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Threading;
using Color = System.Drawing.Color;

namespace ShopInterface
{
    public partial class Form2 : Form
    {
        private readonly List<string> _columnDay = new List<string>();
        private readonly List<string> _columnMonth = new List<string>();
        private readonly List<string> _columns = new List<string>();
        private readonly List<string> _columnYear = new List<string>();
        private readonly List<string> _elements = new List<string>();
        private readonly List<string> _types = new List<string>();
        private int _x = 1;

        public Form2(string user)
        {
            InitializeComponent();
            label28.Text = user;
            Start();
            FirstThings();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            var senderComboBox = (ComboBox)sender;

            // Change the length of the text box depending on what the user has 
            // selected and committed using the SelectionLength property.
            if (senderComboBox.SelectionLength > 0)
            {
                if (comboBox1.SelectedItem.ToString() == "year")
                    foreach (var year in _columnYear)
                        comboBox2.Items.Add(year);

                if (comboBox1.SelectedItem.ToString() == "month")
                    foreach (var month in _columnMonth)
                        comboBox2.Items.Add(month);

                if (comboBox1.SelectedItem.ToString() == "day")
                    foreach (var day in _columnDay)
                        comboBox2.Items.Add(day);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = DBUtils.UpdateDB(dataGridView1, "kitbox", comboBox12.SelectedItem.ToString(),
                "Code = \"" + comboBox11.SelectedItem + "\"", textBox3.Text);
            dataGridView1.DataSource = DBUtils.RefreshDB("kitbox");
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
            label9.Text = DBUtils.AddRow(_elements, _types, _columns, "kitbox");
            dataGridView1.DataSource = DBUtils.RefreshDB("kitbox");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _x = DBUtils.AddItem(label7, _x, dataGridView1, _columns, _types, _elements, button7, textBox4, listView1,
                button6, progressBar1, button3);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _x = DBUtils.DeleteItem(label7, _x, dataGridView1, textBox4, button6, button7, _columns, _types, _elements,
                listView1, progressBar1, button3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            if (chart1.Titles.Count > 0) chart1.Titles.RemoveAt(0);
            var values = DBUtils.SelectCondDB("sales", comboBox3.SelectedItem.ToString());
            if (comboBox1.SelectedItem.ToString() == "day")
            {
                while (chart1.Series.Count > 0) chart1.Series.RemoveAt(0);

                chart1.Series.Add(comboBox3.SelectedItem.ToString());
                chart1.Series[comboBox3.SelectedItem.ToString()].Color = Color.Black;

                foreach (var entry in values)
                    chart1.Series[comboBox3.SelectedItem.ToString()].Points.AddXY(entry.Key, entry.Value);

                chart1.Titles.Add(comboBox3.SelectedItem + " per day");
                if (comboBox2.SelectedItem != null) label14.Text = values[comboBox2.SelectedItem.ToString()].ToString();
            }
            else if (comboBox1.SelectedItem.ToString() == "month")
            {
                while (chart1.Series.Count > 0) chart1.Series.RemoveAt(0);

                chart1.Series.Add(comboBox3.SelectedItem.ToString());
                chart1.Series[comboBox3.SelectedItem.ToString()].Color = Color.Black;
                var graphMonth = new Dictionary<string, int>();
                foreach (var entry in values)
                {
                    var key = entry.Key;
                    var month = key.Split('/')[1] + "/" + key.Split('/')[2];
                    if (graphMonth.ContainsKey(month))
                        graphMonth[month] = graphMonth[month] + entry.Value;
                    else
                        graphMonth.Add(month, entry.Value);
                }

                var months = new List<string>();
                foreach (var entry in graphMonth)
                {
                    months.Add(entry.Key);
                    chart1.Series[comboBox3.SelectedItem.ToString()].Points.AddXY(entry.Key, entry.Value);
                }

                chart1.Titles.Add(comboBox3.SelectedItem + " per month");
                if (comboBox2.SelectedItem != null)
                    label14.Text = graphMonth[comboBox2.SelectedItem.ToString()].ToString();

                var all = graphMonth[months[months.Count - 2]] + graphMonth[months[months.Count - 3]] +
                          graphMonth[months[months.Count - 4]] + graphMonth[months[months.Count - 5]] +
                          graphMonth[months[months.Count - 6]] + graphMonth[months[months.Count - 7]];
                double average = all / 6;
                chart1.Series[comboBox3.SelectedItem.ToString()].Points.AddXY("Average of last 6 months", average);
                chart1.Series[comboBox3.SelectedItem.ToString()].Points.FindByValue(average).Color = Color.LimeGreen;
                chart1.Series[comboBox3.SelectedItem.ToString()].Points.FindByValue(average).IsValueShownAsLabel = true;
                chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            }
            else if (comboBox1.SelectedItem.ToString() == "year")
            {
                while (chart1.Series.Count > 0) chart1.Series.RemoveAt(0);

                chart1.Series.Add(comboBox3.SelectedItem.ToString());
                chart1.Series[comboBox3.SelectedItem.ToString()].Color = Color.Black;
                var graphMonth = new Dictionary<string, int>();
                foreach (var entry in values)
                {
                    var key = entry.Key;
                    var month = key.Split('/')[2];
                    if (graphMonth.ContainsKey(month))
                        graphMonth[month] = graphMonth[month] + entry.Value;
                    else
                        graphMonth.Add(month, entry.Value);
                }

                foreach (var entry in graphMonth)
                    chart1.Series[comboBox3.SelectedItem.ToString()].Points.AddXY(entry.Key, entry.Value);

                chart1.Titles.Add(comboBox3.SelectedItem + " per year");
                if (comboBox2.SelectedItem != null)
                    label14.Text = graphMonth[comboBox2.SelectedItem.ToString()].ToString();
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == @"Database management")
            {
                dataGridView1.DataSource = DBUtils.RefreshDB("kitbox");
                comboBox11.DataSource = DBUtils.RefList("Code", "kitbox");
                comboBox11.DisplayMember = "Code";
                comboBox11.Text = "";
                foreach (DataGridViewColumn col in dataGridView1.Columns) comboBox12.Items.Add(col.Name);
            }
            else if (tabControl1.SelectedTab.Text == @"Orders management")
            {
                Start();
            }
            else if (tabControl1.SelectedTab.Text == @"Stock management")
            {
                UpdateStock();
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.DataSource =
                    DBUtils.RefreshDBCond("listsitems", "OrderId = " + comboBox4.SelectedItem);
                foreach (DataGridViewColumn col in dataGridView3.Columns) col.Visible = true;

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
            dataGridView3.DataSource = DBUtils.RefreshDBCond("customers natural join orders natural join listsitems",
                "CustomerName = \"" + comboBox5.SelectedItem + "\"");
            foreach (DataGridViewColumn col in dataGridView3.Columns) col.Visible = true;

            dataGridView3.Columns["ListItemsId"].Visible = false;
            dataGridView3.Columns["CustomerId"].Visible = false;
            dataGridView3.Columns["CustomerName"].Visible = false;
            dataGridView3.Columns["CustomerPhone"].Visible = false;
            dataGridView3.Columns["Status"].Visible = false;
            Colours(dataGridView3, "Disponibility");
        }

        private void Colours(DataGridView dataGridView3, string column)
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
                if (row.Cells[column].Value.Equals("true"))
                    row.Cells[column].Style.BackColor = Color.LimeGreen;
                else if (row.Cells[column].Value.Equals("false"))
                    row.Cells[column].Style.BackColor = Color.Red;

                else if (row.Cells[column].Value.Equals("closed"))
                    row.Cells[column].Style.BackColor = Color.DeepSkyBlue;
                else if (row.Cells[column].Value.Equals("pending"))
                    row.Cells[column].Style.BackColor = Color.Gold;
                else if (row.Cells[column].Value.Equals("awaiting for removal"))
                    row.Cells[column].Style.BackColor = Color.Fuchsia;
        }

        private void ColoursDiff(DataGridView dataGridView3, string column, string columnB)
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (Convert.ToInt32(row.Cells[column].Value) - Convert.ToInt32(row.Cells[columnB].Value) > 0)
                    row.DefaultCellStyle.BackColor = Color.LimeGreen;
                else if (Convert.ToInt32(row.Cells[column].Value) - Convert.ToInt32(row.Cells[columnB].Value) < 0)
                    row.DefaultCellStyle.BackColor = Color.Gold;

                if (Convert.ToInt32(row.Cells[column].Value) < 4) row.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource =
                DBUtils.RefreshDBCond("listsitems", "OrderId = \"" + comboBox4.SelectedItem + "\"");
            foreach (DataGridViewColumn col in dataGridView3.Columns) col.Visible = true;

            var x = 0;
            var y = 0;
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                var enStock = DBUtils.RefList("Enstock",
                    "kitbox where Code = \"" + row.Cells["Code"].Value + "\"");
                var enstock = Convert.ToInt32(enStock[0]);
                if (enstock - Convert.ToInt32(row.Cells["Quantity"].Value) >= 0)
                {
                    row.Cells["Disponibility"].Style.BackColor = Color.LimeGreen;
                    row.Cells["Disponibility"].Value = "true";
                    DBUtils.UpdateDBV("listsitems", "Disponibility",
                        "Code = \"" + row.Cells["Code"].Value + "\" and OrderID = \"" +
                        row.Cells["OrderId"].Value + "\"", "true");
                    y += 1;
                }
                else
                {
                    row.Cells["Disponibility"].Style.BackColor = Color.Red;
                    row.Cells["Disponibility"].Value = "false";
                    DBUtils.UpdateDBV("listsitems", "Disponibility",
                        "Code = \"" + row.Cells["Code"].Value + "\" and OrderID = \"" +
                        row.Cells["OrderId"].Value + "\"", "false");
                }

                x += 1;
            }

            if (x == y)
                DBUtils.UpdateDBV("orders", "Status", "OrderId = \"" + comboBox4.SelectedItem + "\"",
                    "true");
            else
                DBUtils.UpdateDBV("orders", "Status", "OrderId = \"" + comboBox4.SelectedItem + "\"",
                    "false");

            Start();
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Updating the Label which displays the current time 
            var dateToDisplay = DateTime.Now;
            label13.Text = dateToDisplay.ToString("D", CultureInfo.CreateSpecificCulture("en-US")) + "\n" +
                           dateToDisplay.ToString("t", CultureInfo.CreateSpecificCulture("en-US"));
            //time.Split(',');
            label13.Visible = true;
        }

        private void Start()
        {
            comboBox4.DataSource =
                DBUtils.RefList("OrderId", "orders where Status = \"pending\" or Status = \"false\"");
            comboBox4.DisplayMember = "OrderId";
            comboBox4.Text = "";
            comboBox6.DataSource = DBUtils.RefList("OrderId", "orders where Status = \"pending\"");
            comboBox6.DisplayMember = "OrderId";
            comboBox6.Text = "";
            comboBox7.DataSource = DBUtils.RefList("OrderId", "orders where Status = \"awaiting for removal\"");
            comboBox7.DisplayMember = "OrderId";
            comboBox7.Text = "";
            comboBox8.DataSource = DBUtils.RefList("OrderId", "orders where Status = \"pending\"");
            comboBox8.DisplayMember = "OrderId";
            comboBox8.Text = "";
            comboBox9.DataSource = DBUtils.RefList("OrderId", "orders where Status = \"true\"");
            comboBox9.DisplayMember = "OrderId";
            comboBox9.Text = "";
            comboBox10.DataSource = DBUtils.RefList("Code", "kitbox");
            comboBox10.DisplayMember = "Code";
            comboBox10.Text = "";
            comboBox5.DataSource = DBUtils.RefListND("CustomerName", "customers natural join orders");
            comboBox5.DisplayMember = "CustomerName";
            comboBox5.Text = "";
            dataGridView2.DataSource = DBUtils.RefreshDB("customers natural join orders");
            dataGridView2.Refresh();
            dataGridView2.Sort(dataGridView2.Columns["OrderId"], ListSortDirection.Descending);
            Colours(dataGridView2, "Status");
        }

        private void UpdateStock()
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

        private void UpdateStockMin()
        {
            progressBar2.Value = 10;
            button16.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            var code = DBUtils.RefList("Code", "kitbox");
            foreach (var i in code)
            {
                var valuesIncStock = DBUtils.SelectCondDB("sales", i);
                var graphMonthIncStock = new Dictionary<string, int>();
                foreach (var entry in valuesIncStock)
                {
                    var key = entry.Key;
                    var month = key.Split('/')[1] + "/" + key.Split('/')[2];
                    if (graphMonthIncStock.ContainsKey(month))
                        graphMonthIncStock[month] = graphMonthIncStock[month] + entry.Value;
                    else
                        graphMonthIncStock.Add(month, entry.Value);
                }

                var monthsIncStock = new List<string>();
                foreach (var entry in graphMonthIncStock) monthsIncStock.Add(entry.Key);

                var all = graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 2]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 3]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 4]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 5]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 6]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 7]];
                var average = all / 12;
                DBUtils.UpdateDBV("kitbox", "StockMinimum", "Code = \"" + i + "\"", average.ToString());
                progressBar2.PerformStep();
            }

            Cursor.Current = Cursors.Default;
            button16.Enabled = true;
            UpdateStock();
            progressBar2.Value = 10;
        }


        private void button14_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            label21.Text = DBUtils.UpdateDB(dataGridView2, "customers natural join orders", "Status",
                "OrderId = \"" + comboBox6.SelectedItem + "\"", "false");
            Start();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label26.Text = DBUtils.UpdateDB(dataGridView2, "customers natural join orders", "Status",
                "OrderId = \"" + comboBox7.SelectedItem + "\"", "closed");
            Start();
        }

        private void FirstThings()
        {
            label28.Visible = true;
            tabControl1.SelectedIndexChanged += tabControl1_Click;
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            var ninja = new DataTable();
            dataGridView4.DataSource = DBUtils.RefreshDBPartial("kitbox", "Ref, Code, EnStock, StockMinimum");
            dataGridView1.DataSource = DBUtils.RefreshDB("kitbox");
            ninja = DBUtils.RefreshDB("sales");
            foreach (DataColumn col in ninja.Columns)
                if (col.ColumnName != "Code" && col.ColumnName != "Ref")
                {
                    var value = col.ColumnName.Split('/')[2];

                    if (_columnYear.Contains(value) == false) _columnYear.Add(value);

                    var valueMonth = col.ColumnName.Split('/')[1] + "/" +
                                     col.ColumnName.Split('/')[2];

                    if (_columnMonth.Contains(valueMonth) == false) _columnMonth.Add(valueMonth);

                    _columnDay.Add(col.ColumnName);
                }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            UpdateStockMin();
        }
    }
}