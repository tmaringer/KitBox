using MySql.Data.MySqlClient;
using projectCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ShopInterface
{
    [SuppressMessage("ReSharper", "PossibleLossOfFraction")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public partial class Form2 : Form
    {
        private readonly List<string> _columnDay = new List<string>();
        private readonly List<string> _columnMonth = new List<string>();
        private readonly List<string> _columns = new List<string>();
        private readonly List<string> _columnYear = new List<string>();
        private readonly List<string> _elements = new List<string>();
        private readonly List<string> _types = new List<string>();
        private int _x = 1;
        private StringFormat strFormat;
        private List<int> arrColumnLefts;
        private List<int> arrColumnWidths;
        private int iCellHeight;
        private int iCount;
        private bool bFirstPage;
        private bool bNewPage;
        private int iTotalWidth;
        private int iHeaderHeight;

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
            ComboBox senderComboBox = (ComboBox) sender;

            // Change the length of the text box depending on what the user has 
            // selected and committed using the SelectionLength property.
            if (senderComboBox.SelectionLength >= 0)
            {
                if (comboBox1.SelectedItem.ToString() == "year")
                {
                    foreach (string year in _columnYear)
                    {
                        comboBox2.Items.Add(year);
                    }
                }

                if (comboBox1.SelectedItem.ToString() == "month")
                {
                    foreach (string month in _columnMonth)
                    {
                        comboBox2.Items.Add(month);
                    }
                }

                if (comboBox1.SelectedItem.ToString() == "day")
                {
                    foreach (string day in _columnDay)
                    {
                        comboBox2.Items.Add(day);
                    }
                }
            }
        }

        private void comboBox21_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox22.Items.Clear();
            comboBox22.Text = "";
            ComboBox senderComboBox = (ComboBox) sender;
            if (senderComboBox.SelectionLength >= 0)
            {
                List<string> orderList = DbUtils.RefList("OrderId",
                    "customers natural join orders where CustomerName = \"" + comboBox21.SelectedItem + "\"");
                foreach (string orderId in orderList)
                {
                    comboBox22.Items.Add(orderId);
                }
            }
        }

        private void comboBox23_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox24.Items.Clear();
            ComboBox senderComboBox = (ComboBox) sender;
            if (senderComboBox.SelectionLength >= 0)
            {
                List<string> orderList2 = new List<string>();
                if (comboBox23.SelectedItem.ToString() == "Width")
                {
                    orderList2 = DbUtils.RefListNd("Width", "kitbox where Ref = \"Panels B\"");
                }
                else if (comboBox23.SelectedItem.ToString() == "Depth")
                {
                    orderList2 = DbUtils.RefListNd("Depth", "kitbox where Ref = \"Panels LR\"");
                }

                foreach (string orderId in orderList2)
                {
                    comboBox24.Items.Add(orderId);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox11.Text != "" && comboBox12.Text != "" && textBox3.Text != "")
            {
                label4.Text = DbUtils.UpdateDb("kitbox", comboBox12.SelectedItem.ToString(),
                    "Code = \"" + comboBox11.SelectedItem + "\"", textBox3.Text);
                dataGridView1.DataSource = DbUtils.RefreshDb("kitbox");
            }
            else
            {
                MessageBox.Show(@"Please select or enter every element", @"Element missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != "")
            {
                button4.Enabled = DbUtils.SearchDb(dataGridView1, textBox10);
            }
            else
            {
                MessageBox.Show(@"Please enter an element", @"Element missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            button4.Enabled = DbUtils.StopSearchDb(dataGridView1, textBox10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox10.Text != "")
            {
                label5.Text = DbUtils.DeleteRow("kitbox", comboBox10.SelectedItem.ToString());
                dataGridView1.DataSource = DbUtils.RefreshDb("kitbox");
                comboBox10.SelectedItem = "";
            }
            else
            {
                MessageBox.Show(@"Please select a Code", @"Code missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string columns = DbUtils.ConvertStringNoQuotes(_columns);
            string elements = DbUtils.ConvertStringQuotes(_elements);
            string i = DbUtils.InsertDb("kitbox", columns, elements);
            dataGridView1.DataSource = DbUtils.RefreshDb("kitbox");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                _x = DbUtils.AddItem(label7, _x, dataGridView1, _columns, _types, _elements, button7, textBox4,
                    listView1, button6, progressBar1, button3);
            }
            else
            {
                MessageBox.Show(@"Please enter a " + label7.Text, label7.Text + @" missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _x = DbUtils.DeleteItem(label7, _x, dataGridView1, textBox4, button6, button7, _columns, _types, _elements,
                listView1, progressBar1, button3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox3.Text != "")
            {
                chart1.Visible = true;
                if (chart1.Titles.Count > 0)
                {
                    chart1.Titles.RemoveAt(0);
                }

                Dictionary<string, int> values = DbUtils.SelectCondDb("sales", comboBox3.SelectedItem.ToString());
                if (comboBox1.SelectedItem.ToString() == "day")
                {
                    while (chart1.Series.Count > 0)
                    {
                        chart1.Series.RemoveAt(0);
                    }

                    chart1.Series.Add(comboBox3.SelectedItem.ToString());
                    chart1.Series[comboBox3.SelectedItem.ToString()].Color = Color.Black;

                    foreach (KeyValuePair<string, int> entry in values)
                    {
                        chart1.Series[comboBox3.SelectedItem.ToString()].Points.AddXY(entry.Key, entry.Value);
                    }

                    chart1.Titles.Add(comboBox3.SelectedItem + " per day");
                    if (comboBox2.SelectedItem != null)
                    {
                        label14.Text = values[comboBox2.SelectedItem.ToString()].ToString();
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "month")
                {
                    while (chart1.Series.Count > 0)
                    {
                        chart1.Series.RemoveAt(0);
                    }

                    chart1.Series.Add(comboBox3.SelectedItem.ToString());
                    chart1.Series[comboBox3.SelectedItem.ToString()].Color = Color.Black;
                    Dictionary<string, int> graphMonth = new Dictionary<string, int>();
                    foreach (KeyValuePair<string, int> entry in values)
                    {
                        string key = entry.Key;
                        string month = key.Split('/')[1] + "/" + key.Split('/')[2];
                        if (graphMonth.ContainsKey(month))
                        {
                            graphMonth[month] = graphMonth[month] + entry.Value;
                        }
                        else
                        {
                            graphMonth.Add(month, entry.Value);
                        }
                    }

                    List<string> months = new List<string>();
                    foreach (KeyValuePair<string, int> entry in graphMonth)
                    {
                        months.Add(entry.Key);
                        chart1.Series[comboBox3.SelectedItem.ToString()].Points.AddXY(entry.Key, entry.Value);
                    }

                    chart1.Titles.Add(comboBox3.SelectedItem + " per month");
                    if (comboBox2.SelectedItem != null)
                    {
                        label14.Text = graphMonth[comboBox2.SelectedItem.ToString()].ToString();
                    }

                    int all = graphMonth[months[months.Count - 2]] + graphMonth[months[months.Count - 3]] +
                              graphMonth[months[months.Count - 4]] + graphMonth[months[months.Count - 5]] +
                              graphMonth[months[months.Count - 6]] + graphMonth[months[months.Count - 7]];
                    double average = all / 6;
                    chart1.Series[comboBox3.SelectedItem.ToString()].Points.AddXY("Average of last 6 months", average);
                    chart1.Series[comboBox3.SelectedItem.ToString()].Points.FindByValue(average).Color =
                        Color.LimeGreen;
                    chart1.Series[comboBox3.SelectedItem.ToString()].Points.FindByValue(average).IsValueShownAsLabel =
                        true;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                }
                else if (comboBox1.SelectedItem.ToString() == "year")
                {
                    while (chart1.Series.Count > 0)
                    {
                        chart1.Series.RemoveAt(0);
                    }

                    chart1.Series.Add(comboBox3.SelectedItem.ToString());
                    chart1.Series[comboBox3.SelectedItem.ToString()].Color = Color.Black;
                    Dictionary<string, int> graphMonth = new Dictionary<string, int>();
                    foreach (KeyValuePair<string, int> entry in values)
                    {
                        string key = entry.Key;
                        string month = key.Split('/')[2];
                        if (graphMonth.ContainsKey(month))
                        {
                            graphMonth[month] = graphMonth[month] + entry.Value;
                        }
                        else
                        {
                            graphMonth.Add(month, entry.Value);
                        }
                    }

                    foreach (KeyValuePair<string, int> entry in graphMonth)
                    {
                        chart1.Series[comboBox3.SelectedItem.ToString()].Points.AddXY(entry.Key, entry.Value);
                    }

                    chart1.Titles.Add(comboBox3.SelectedItem + " per year");
                    if (comboBox2.SelectedItem != null)
                    {
                        label14.Text = graphMonth[comboBox2.SelectedItem.ToString()].ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Please select every element", @"Element missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == @"Database management")
            {
                dataGridView1.DataSource = DbUtils.RefreshDb("kitbox");
                comboBox11.DataSource = DbUtils.RefList("Code", "kitbox");
                comboBox11.DisplayMember = "Code";
                comboBox11.Text = "";
                comboBox10.Text = "";
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    comboBox12.Items.Add(col.Name);
                }
            }
            else if (tabControl1.SelectedTab.Text == @"Orders management")
            {
                Start();
            }
            else if (tabControl1.SelectedTab.Text == @"Order visualisation")
            {
                Start();
                comboBox22.Items.Clear();
                comboBox23.Text = "";
                List<string> orderList3 = DbUtils.RefListNd("Width", "kitbox where Ref = \"Panels B\"");
                foreach (string orderId in orderList3)
                {
                    comboBox24.Items.Add(orderId);
                }
            }
            else if (tabControl1.SelectedTab.Text == @"Stock management")
            {
                UpdateStock();
                foreach (string day in _columnDay)
                {
                    comboBox2.Items.Add(day);
                }

                comboBox1.Text = "";
                comboBox3.Text = "";
            }
            else if (tabControl1.SelectedTab.Text == @"Suppliers orders")
            {
                comboBox16.DataSource = DbUtils.RefList("Code", "kitbox");
                comboBox16.DisplayMember = "Code";
                comboBox16.Text = "";
                comboBox18.DataSource = DbUtils.RefList("SupplierId", "suppliers");
                comboBox18.DisplayMember = "SupplierId";
                comboBox18.Text = "";
                button18.Enabled = false;
                comboBox14.DataSource = DbUtils.RefList("SupplierOrderId", "suppliersorders");
                comboBox14.DisplayMember = "SupplierOrderId";
                comboBox14.Text = "";
                dataGridView7.DataSource = DbUtils.RefreshDb("suppliersorders");
                comboBox8.DataSource = DbUtils.RefList("SupplierOrderId", "suppliersorders where status = \"send\"");
                comboBox8.DisplayMember = "SupplierOrderId";
                comboBox8.Text = "";
            }
            else if (tabControl1.SelectedTab.Text == @"Suppliers update")
            {
                comboBox34.DataSource = DbUtils.RefList("SupplierId", "suppliers");
                comboBox34.DisplayMember = "SupplierId";
                comboBox34.Text = "";
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                dataGridView3.DataSource =
                    DbUtils.RefreshDb("customers natural join orders natural join listsitems where CustomerName = \"" +
                                      comboBox5.SelectedItem + "\"");
                foreach (DataGridViewColumn col in dataGridView3.Columns)
                {
                    col.Visible = true;
                }

                if (dataGridView3 != null)
                {
                    dataGridView3.Columns[@"CustomerId"].Visible = false;
                    dataGridView3.Columns[@"CustomerName"].Visible = false;
                    dataGridView3.Columns[@"CustomerPhone"].Visible = false;
                    dataGridView3.Columns["Status"].Visible = false;
                }
                Colours(dataGridView3, "Disponibility");
                label19.Text = @"Done";
            }
            else
            {
                MessageBox.Show(@"Please select a Customer Name", @"Customer Name missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void Colours(DataGridView dataGridView, string column)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[column].Value.Equals("true"))
                {
                    row.Cells[column].Style.BackColor = Color.LimeGreen;
                }
                else if (row.Cells[column].Value.Equals("false"))
                {
                    row.Cells[column].Style.BackColor = Color.Red;
                }
                else if (row.Cells[column].Value.ToString().Length > 11)
                {
                    if (row.Cells[column].Value.ToString().Substring(0, 11).Equals("uncompleted"))
                    {
                        row.Cells[column].Style.BackColor = Color.Red;
                    }
                    else if (row.Cells[column].Value.Equals("awaiting for removal"))
                    {
                        row.Cells[column].Style.BackColor = Color.Fuchsia;
                    }
                    else if (row.Cells[column].Value.Equals("never tested"))
                    {
                        row.Cells[column].Style.BackColor = Color.LightGray;
                    }
                }
                else if (row.Cells[column].Value.Equals("completed"))
                {
                    row.Cells[column].Style.BackColor = Color.DeepSkyBlue;
                }
                else if (row.Cells[column].Value.Equals("pending"))
                {
                    row.Cells[column].Style.BackColor = Color.Gold;
                }
                else if (row.Cells[column].Value.Equals("not ready"))
                {
                    row.Cells[column].Style.BackColor = Color.Orange;
                }
                else if (row.Cells[column].Value.Equals("validate"))
                {
                    row.Cells[column].Style.BackColor = Color.Aquamarine;
                }
            }
        }

        private void ColoursDiff(DataGridView dataGridView, string column, string columnB)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (Convert.ToInt32(row.Cells[column].Value) - Convert.ToInt32(row.Cells[columnB].Value) > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LimeGreen;
                }
                else if (Convert.ToInt32(row.Cells[column].Value) - Convert.ToInt32(row.Cells[columnB].Value) < 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Gold;
                }

                if (Convert.ToInt32(row.Cells[column].Value) < 4)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {
                Coll(DbUtils.RefList("Status", "orders where OrderId =\"" + comboBox4.SelectedItem + "\"")[0]);
                dataGridView3.DataSource =
                    DbUtils.RefreshDb("listsitems where OrderId = \"" + comboBox4.SelectedItem + "\"");
                foreach (DataGridViewColumn col in dataGridView3.Columns)
                {
                    col.Visible = true;
                }

                Colours(dataGridView3, "Disponibility");
                comboBox4.Text = "";
                Start();
            }
            else
            {
                MessageBox.Show(@"Please select an OrderId", @"OrderId missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Updating the Label which displays the current time 
            DateTime dateToDisplay = DateTime.Now;
            label13.Text = dateToDisplay.ToString("D", CultureInfo.CreateSpecificCulture("en-US")) + Environment.NewLine +
                           dateToDisplay.ToString("t", CultureInfo.CreateSpecificCulture("en-US"));
            //time.Split(',');
            label13.Visible = true;
        }

        private void Start()
        {
            comboBox4.DataSource = DbUtils.RefList("OrderId", "orders where Status != \"pending\"");
            comboBox4.DisplayMember = "OrderId";
            comboBox4.Text = "";
            comboBox10.DataSource = DbUtils.RefList("Code", "kitbox");
            comboBox10.DisplayMember = "Code";
            comboBox10.Text = "";
            comboBox5.DataSource = DbUtils.RefListNd("CustomerName", "customers natural join orders");
            comboBox5.DisplayMember = "CustomerName";
            comboBox5.Text = "";
            comboBox6.DataSource = DbUtils.RefListNd("OrderId", "orders");
            comboBox6.DisplayMember = "OrderId";
            comboBox6.Text = "";
            comboBox21.DataSource = DbUtils.RefListNd("CustomerName", "customers natural join orders");
            comboBox21.DisplayMember = "CustomerName";
            comboBox21.Text = "";
            List<string> heightValue = DbUtils.RefListNd("Height", "kitbox where Ref = \"Cleat\"");
            comboBox25.Items.Clear();
            //fix combobox25
            foreach (string i in heightValue)
            {
                string adjust = (Convert.ToInt32(i) + 4).ToString();
                comboBox25.Items.Add(adjust);
            }

            comboBox25.Text = "";
            dataGridView2.DataSource = DbUtils.RefreshDb("customers natural join orders");
            dataGridView2.Refresh();
            dataGridView2.Sort(dataGridView2.Columns["OrderId"] ?? throw new InvalidOperationException(), ListSortDirection.Descending);
            Colours(dataGridView2, "Status");
        }

        private void UpdateStock()
        {
            dataGridView4.DataSource = DbUtils.RefreshDbPartial("kitbox", "Ref, Code, Instock, MinimumStock");
            comboBox3.DataSource = DbUtils.RefList("Code", "kitbox.sales");
            comboBox3.DisplayMember = "Code";
            ColoursDiff(dataGridView4, "Instock", "MinimumStock");
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
            foreach (string i in DbUtils.RefList("Code", "kitbox"))
            {
                Dictionary<string, int> valuesIncStock = DbUtils.SelectCondDb("sales", i);
                Dictionary<string, int> graphMonthIncStock = new Dictionary<string, int>();
                foreach (KeyValuePair<string, int> entry in valuesIncStock)
                {
                    string key = entry.Key;
                    string month = key.Split('/')[1] + "/" + key.Split('/')[2];
                    if (graphMonthIncStock.ContainsKey(month))
                    {
                        graphMonthIncStock[month] = graphMonthIncStock[month] + entry.Value;
                    }
                    else
                    {
                        graphMonthIncStock.Add(month, entry.Value);
                    }
                }

                List<string> monthsIncStock = new List<string>();
                foreach (KeyValuePair<string, int> entry in graphMonthIncStock)
                {
                    monthsIncStock.Add(entry.Key);
                }

                int all = graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 2]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 3]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 4]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 5]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 6]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 7]];
                int average = all / 12;
                label67.Text = DbUtils.UpdateDb("kitbox", "MinimumStock", "Code = \"" + i + "\"", average.ToString());
                progressBar2.PerformStep();
            }

            Cursor.Current = Cursors.Default;
            button16.Enabled = true;
            UpdateStock();
            progressBar2.Value = 10;
        }

        private void AddToPendingSuppliers(string code, string quantity)
        {
            if (DbUtils.RefList("Code", "supplierspending").Contains(code))
            {
                string valueadd = (Convert.ToInt32(quantity) + Convert.ToInt32(DbUtils.RefList("Quantity",
                    "supplierspending where Code = \"" + code + "\"")[0])).ToString();
                label35.Text = DbUtils.UpdateDb("supplierspending", "Quantity", "Code = \"" + code + "\"", valueadd);
            }
            else
            {
                DbUtils.InsertDb("supplierspending", "code, quantity", "\"" + code + "\", \"" + quantity + "\"");
            }

            if (DbUtils.RefList("Quantity", "supplierspending").Contains("0"))
            {
                DbUtils.DeleteRow("supplierspending", "Quantity = \"0\"");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void FirstThings()
        {
            label28.Visible = true;
            tabControl1.SelectedIndexChanged += tabControl1_Click;
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            DataTable ninja;
            dataGridView4.DataSource = DbUtils.RefreshDbPartial("kitbox", "Ref, Code, Instock, MinimumStock");
            dataGridView1.DataSource = DbUtils.RefreshDb("kitbox");
            ninja = DbUtils.RefreshDb("sales");
            foreach (DataColumn col in ninja.Columns)
            {
                if (col.ColumnName != "Code" && col.ColumnName != "Ref")
                {
                    string value = col.ColumnName.Split('/')[2];

                    if (_columnYear.Contains(value) == false)
                    {
                        _columnYear.Add(value);
                    }

                    string valueMonth = col.ColumnName.Split('/')[1] + "/" +
                                        col.ColumnName.Split('/')[2];

                    if (_columnMonth.Contains(valueMonth) == false)
                    {
                        _columnMonth.Add(valueMonth);
                    }

                    _columnDay.Add(col.ColumnName);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            UpdateStockMin();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (comboBox16.Text != "" && textBox2.Text != "")
            {
                AddToPendingSuppliers(comboBox16.SelectedItem.ToString(), textBox2.Text);
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show(@"Please select or enter every element", @"Element missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (comboBox21.Text != "" && comboBox22.Text != "")
            {
                if (DbUtils.RefList("Status", "orders where OrderId = \"" + comboBox22.SelectedItem + "\"")[0] !=
                    "pending")
                {
                    foreach (Control cont in groupBox23.Controls)
                    {
                        if (cont is TextBox || cont is ComboBox || cont is Button)
                        {
                            cont.Enabled = false;
                        }
                    }

                    foreach (Control cont in groupBox22.Controls)
                    {
                        if (cont is TextBox || cont is ComboBox || cont is Button)
                        {
                            cont.Enabled = false;
                        }
                    }

                    foreach (Control cont in groupBox20.Controls)
                    {
                        if (cont is TextBox || cont is ComboBox || cont is Button)
                        {
                            cont.Enabled = false;
                        }
                    }
                }
                else
                {
                    foreach (Control cont in groupBox23.Controls)
                    {
                        if (cont is TextBox || cont is ComboBox || cont is Button)
                        {
                            cont.Enabled = true;
                        }
                    }

                    foreach (Control cont in groupBox22.Controls)
                    {
                        if (cont is TextBox || cont is ComboBox || cont is Button)
                        {
                            cont.Enabled = true;
                        }
                    }

                    foreach (Control cont in groupBox20.Controls)
                    {
                        if (cont is TextBox || cont is ComboBox || cont is Button)
                        {
                            cont.Enabled = true;
                        }
                    }
                }

                dataGridView6.DataSource =
                    DbUtils.RefreshDb("cupboards where OrderId=\"" + comboBox22.SelectedItem + "\"");
                comboBox26.Items.Clear();
                comboBox30.Items.Clear();
                comboBox20.Items.Clear();
                comboBox31.Items.Clear();
                comboBox27.Items.Clear();
                dataGridView11.DataSource = null;
                foreach (DataGridViewRow row in dataGridView6.Rows)
                {
                    comboBox30.Items.Add(row.Cells["CupboardId"].Value.ToString());
                    comboBox26.Items.Add(row.Cells["CupboardId"].Value.ToString());
                    comboBox20.Items.Add(row.Cells["CupboardId"].Value.ToString());
                }

                label52.Text = @"Done";
            }
            else
            {
                MessageBox.Show(@"Please select every element", @"Element missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (comboBox20.Text != "" && comboBox23.Text != "" && comboBox24.Text != "")
            {
                if (comboBox23.SelectedItem.ToString() == "Width")
                {
                    Sandbox.Width(comboBox20.SelectedItem.ToString(), Convert.ToInt32(comboBox24.SelectedItem));
                }
                else if (comboBox23.SelectedItem.ToString() == "Depth")
                {
                    Sandbox.Depth(comboBox20.SelectedItem.ToString(), Convert.ToInt32(comboBox24.SelectedItem));
                }

                dataGridView6.DataSource =
                    DbUtils.RefreshDb("cupboards where OrderId=\"" + comboBox22.SelectedItem + "\"");
                label53.Text = @"Done";
            }
            else
            {
                MessageBox.Show(@"Please select every element", @"Element missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView6.CurrentCell.ColumnIndex == 0)
            {
                dataGridView11.DataSource =
                    DbUtils.RefreshDb("boxes where CupboardId=\"" + dataGridView6.CurrentCell.Value + "\"");
                comboBox26.Text = dataGridView6.CurrentCell.Value.ToString();
                comboBox20.Text = dataGridView6.CurrentCell.Value.ToString();
                comboBox30.Text = dataGridView6.CurrentCell.Value.ToString();
                comboBox27.Items.Clear();
                comboBox31.Items.Clear();
                dataGridView12.DataSource = null;
                Sandbox.Angles(dataGridView6.CurrentCell.Value.ToString(), dataGridView12);
                foreach (DataGridViewRow row in dataGridView11.Rows)
                {
                    comboBox27.Items.Add(row.Cells["BoxId"].Value.ToString());
                    comboBox31.Items.Add(row.Cells["BoxId"].Value.ToString());
                }
            }
        }

        private void dataGridView11_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView11.CurrentCell.ColumnIndex == 0)
            {
                dataGridView12.DataSource = null;
                Sandbox.ElementList(dataGridView11.CurrentCell.Value.ToString(), dataGridView12);
                comboBox27.Text = dataGridView11.CurrentCell.Value.ToString();
                comboBox31.Text = dataGridView11.CurrentCell.Value.ToString();
            }
        }

        private void groupBox20_Enter(object sender, EventArgs e)
        {
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (comboBox25.Text != "" && comboBox26.Text != "" && comboBox27.Text != "")
            {
                Sandbox.Height(comboBox27.Text, Convert.ToInt32(comboBox25.SelectedItem.ToString()));
                dataGridView11.DataSource =
                    DbUtils.RefreshDb("boxes where CupboardId=\"" + comboBox26.SelectedItem + "\"");
                dataGridView6.DataSource =
                    DbUtils.RefreshDb("cupboards where OrderId=\"" + comboBox22.SelectedItem + "\"");
                dataGridView12.DataSource = null;
                Sandbox.ElementList(comboBox27.Text, dataGridView12);
                label57.Text = @"Done";
            }
            else
            {
                MessageBox.Show(@"Please select every element", @"Element missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void dataGridView12_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView12.CurrentCell.ColumnIndex == 1)
            {
                Form frm = new Form3(dataGridView12.CurrentCell.Value.ToString());
                frm.Show();
            }
        }

        private void comboBox32_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox) sender;
            comboBox33.Enabled = false;
            groupBox24.Visible = false;
            if (senderComboBox.SelectionLength >= 0)
            {
                if (comboBox32.SelectedItem.ToString() == "Angle")
                {
                    dataGridView12.DataSource = null;
                    Sandbox.Angles(comboBox30.SelectedItem.ToString(), dataGridView12);
                    comboBox31.Enabled = false;
                    comboBox33.Enabled = false;
                    comboBox29.Items.Clear();
                    foreach (DataGridViewRow row in dataGridView12.Rows)
                    {
                        comboBox29.Items.Add(row.Cells["Id"].Value.ToString());
                    }

                    comboBox28.Items.Clear();
                    foreach (string i in DbUtils.RefListNd("Colour", "kitbox where Ref = \"AngleBracket\""))
                    {
                        comboBox28.Items.Add(i);
                    }
                }
                else if (comboBox32.SelectedItem.ToString() == "Door")
                {
                    comboBox31.Enabled = true;
                    dataGridView12.DataSource = null;
                    Sandbox.Doors(comboBox31.SelectedItem.ToString(), dataGridView12);
                    string cupboardid = DbUtils.RefList("CupboardId",
                        "boxes where BoxId = \"" + comboBox31.SelectedItem + "\"")[0];
                    if (Convert.ToInt32(
                        DbUtils.RefList("Width", "cupboards where CupboardId = \"" + cupboardid + "\"")[0]) >= 62)
                    {
                        groupBox24.Visible = true;
                        comboBox33.Enabled = true;
                        comboBox29.Items.Clear();
                        foreach (DataGridViewRow row in dataGridView12.Rows)
                        {
                            comboBox29.Items.Add(row.Cells["Id"].Value.ToString());
                        }

                        comboBox28.Items.Clear();
                        foreach (string i in DbUtils.RefListNd("Colour", "kitbox where Ref = \"Door\""))
                        {
                            comboBox28.Items.Add(i);
                        }
                    }
                }
                else if (comboBox32.SelectedItem.ToString() == "Panels")
                {
                    groupBox24.Visible = false;
                    comboBox33.Enabled = false;
                    comboBox31.Enabled = true;
                    dataGridView12.DataSource = null;
                    Sandbox.Panels(comboBox31.SelectedItem.ToString(), dataGridView12);
                    comboBox29.Items.Clear();
                    foreach (DataGridViewRow row in dataGridView12.Rows)
                    {
                        comboBox29.Items.Add(row.Cells["Id"].Value.ToString());
                    }

                    comboBox28.Items.Clear();
                    foreach (string i in DbUtils.RefListNd("Colour", "kitbox where Ref = \"Panels LR\""))
                    {
                        comboBox28.Items.Add(i);
                    }
                }
            }
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.CurrentCell.ColumnIndex == 1)
            {
                Form frm = new Form3(dataGridView3.CurrentCell.Value.ToString());
                frm.Show();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (comboBox33.Text != "")
            {
                while (dataGridView12.Rows.Count - Convert.ToInt32(comboBox33.SelectedItem.ToString()) != 0)
                {
                    if (dataGridView12.Rows.Count < Convert.ToInt32(comboBox33.SelectedItem.ToString()))
                    {
                        string height = DbUtils.RefList("Height",
                            "boxes where BoxId = \"" + comboBox31.SelectedItem + "\"")[0];
                        string width = DbUtils.RefList("Width",
                            "cupboards where CupboardId = \"" + comboBox30.SelectedItem + "\"")[0];
                        string code = "DOO" + (Convert.ToInt32(height) - 4) + (Convert.ToInt32(width) / 10 * 5 + 2) +
                                      "WH";
                        DbUtils.InsertDb("doors", "(BoxId,Code)",
                            "\"" + comboBox31.SelectedItem + "\", \"" + code + "\"");
                        dataGridView12.DataSource = null;
                        Sandbox.Doors(comboBox31.SelectedItem.ToString(), dataGridView12);
                    }
                    else if (dataGridView12.Rows.Count > Convert.ToInt32(comboBox33.SelectedItem.ToString()))
                    {
                        List<string> id = DbUtils.RefList("DoorId",
                            "doors where BoxId = \"" + comboBox31.SelectedItem + "\"");
                        DbUtils.DeleteRow("doors", "DoorId = \"" + id[id.Count - 1] + "\"");
                        dataGridView12.DataSource = null;
                        Sandbox.Doors(comboBox31.SelectedItem.ToString(), dataGridView12);
                    }
                }

                DbUtils.Arrange("doors", "DoorId");
                dataGridView12.DataSource = null;
                Sandbox.Doors(comboBox31.SelectedItem.ToString(), dataGridView12);
            }
            else
            {
                MessageBox.Show(@"Please select a number of doors", @"Number of doors missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (comboBox34.Text != "")
            {
                dataGridView10.DataSource =
                    DbUtils.RefreshDb("supplierslistprices where SupplierId=\"" + comboBox34.SelectedItem + "\"");
                comboBox15.DataSource = DbUtils.RefList("Code",
                    "supplierslistprices where SupplierId =\"" + comboBox34.SelectedItem + "\"");
                comboBox15.DisplayMember = "Code";
                comboBox15.Text = "";
                comboBox17.DataSource = DbUtils.RefList("Code",
                    "supplierslistprices where SupplierId =\"" + comboBox34.SelectedItem + "\"");
                comboBox17.DisplayMember = "Code";
                comboBox17.Text = "";
                comboBox19.Items.Clear();
                foreach (DataGridViewColumn col in dataGridView10.Columns)
                {
                    comboBox19.Items.Add(col.Name);
                }
            }
            else
            {
                MessageBox.Show(@"Please select a SupplierId", @"SupplierId missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (comboBox34.Text != "")
            {
                if (textBox1.Text != "" && textBox5.Text != "" && textBox7.Text != "")
                {
                    string columns = "SupplierId,Code,SuppPrice,SuppDelay";
                    string elements = "\"" + comboBox34.SelectedItem + "\", \"" + textBox1.Text + "\", \"" +
                                      textBox5.Text + "\", \"" + textBox7.Text + "\"";
                    DbUtils.InsertDb("supplierslistprices", columns, elements);
                    dataGridView10.DataSource =
                        DbUtils.RefreshDb("supplierslistprices where SupplierId=\"" + comboBox34.SelectedItem + "\"");
                }
                else
                {
                    MessageBox.Show(@"Please enter every element", @"Element missing", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show(@"Please select a SupplierId", @"Element missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (comboBox34.Text != "")
            {
                if (comboBox15.Text != "")
                {
                    label38.Text = DbUtils.DeleteRow("supplierslistprices",
                        "Code = \"" + comboBox15.SelectedItem + "\" and SupplierId = \"" + comboBox34.SelectedItem +
                        "\"");
                    dataGridView10.DataSource =
                        DbUtils.RefreshDb("supplierslistprices where SupplierId=\"" + comboBox34.SelectedItem + "\"");
                }
                else
                {
                    MessageBox.Show(@"Please select a Code", @"Code missing", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show(@"Please select a SupplierId", @"Element missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (comboBox34.Text != "")
            {
                if (comboBox17.Text != "" && comboBox19.Text != "" && textBox6.Text != "")
                {
                    label44.Text = DbUtils.UpdateDb("supplierslistprices", comboBox19.SelectedItem.ToString(),
                        "Code=\"" + comboBox17.SelectedItem + "\" and SupplierId = \"" + comboBox34.SelectedItem + "\"",
                        textBox6.Text);
                    dataGridView10.DataSource =
                        DbUtils.RefreshDb("supplierslistprices where supplierId=\"" + comboBox34.SelectedItem + "\"");
                }
                else
                {
                    MessageBox.Show(@"Please select or enter every element", @"Element missing", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show(@"Please select a SupplierId", @"Element missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            progressBar3.Value = 10;
            button24.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            DataTable supplier1 = new DataTable();
            foreach (string i in DbUtils.RefList("SupplierId", "suppliers"))
            {
                if (i == "1")
                {
                    supplier1 = DbUtils.RefreshDb("supplierslistprices where SupplierId = \"" + i + "\"");
                }
                else
                {
                    foreach (string j in DbUtils.RefList("Code",
                        "supplierslistprices where SupplierId = \"" + i + "\""))
                    {
                        double value1 = Convert.ToDouble(DbUtils.RefList("SuppPrice",
                            "supplierslistprices where SupplierId = \"" + i + "\" and Code = \"" + j + "\"")[0]);
                        List<string> listcode = new List<string>();
                        foreach (DataRow row in supplier1.Rows)
                        {
                            listcode.Add(row["Code"].ToString());
                        }

                        if (listcode.Contains(j))
                        {
                            double value2 = 0;
                            foreach (DataRow row in supplier1.Rows)
                            {
                                if (row["Code"].ToString() == j)
                                {
                                    value2 = Convert.ToDouble(row["SuppPrice"].ToString());
                                }
                            }

                            if (value2 - value1 > 0)
                            {
                                for (int k = supplier1.Rows.Count - 1; k >= 0; k--)
                                {
                                    DataRow dr = supplier1.Rows[k];
                                    if (dr["Code"].ToString() == j)
                                    {
                                        dr.Delete();
                                    }
                                }

                                supplier1.AcceptChanges();
                                DataRow ligne = supplier1.NewRow();
                                ligne["SupplierId"] = i;
                                ligne["Code"] = j;
                                ligne["SuppPrice"] = value1;
                                ligne["SuppDelay"] = Convert.ToInt32(DbUtils.RefList("SuppDelay",
                                    "supplierslistprices where SupplierId = \"" + i + "\" and Code = \"" + j +
                                    "\"")[0]);
                                supplier1.Rows.Add(ligne);
                            }
                            else if (Math.Abs(value2 - value1) < 0.001)
                            {
                                int delay1 = Convert.ToInt32(DbUtils.RefList("SuppDelay",
                                    "supplierslistprices where SupplierId = \"" + i + "\" and Code = \"" + j +
                                    "\"")[0]);
                                int delay2 = 0;
                                foreach (DataRow row in supplier1.Rows)
                                {
                                    if (row["Code"].ToString() == j)
                                    {
                                        delay2 = Convert.ToInt32(row["SuppDelay"].ToString());
                                    }
                                }

                                if (delay2 - delay1 > 0)
                                {
                                    for (int k = supplier1.Rows.Count - 1; k >= 0; k--)
                                    {
                                        DataRow dr = supplier1.Rows[k];
                                        if (dr["Code"].ToString() == j)
                                        {
                                            dr.Delete();
                                        }
                                    }

                                    supplier1.AcceptChanges();
                                    DataRow ligne = supplier1.NewRow();
                                    ligne["SupplierId"] = i;
                                    ligne["Code"] = j;
                                    ligne["SuppPrice"] = value1;
                                    ligne["SuppDelay"] = delay1;
                                    supplier1.Rows.Add(ligne);
                                }
                            }
                        }
                        else
                        {
                            for (int k = supplier1.Rows.Count - 1; k >= 0; k--)
                            {
                                DataRow dr = supplier1.Rows[k];
                                if (dr["Code"].ToString() == j)
                                {
                                    dr.Delete();
                                }
                            }

                            supplier1.AcceptChanges();
                            DataRow ligne = supplier1.NewRow();
                            ligne["SupplierId"] = i;
                            ligne["Code"] = j;
                            ligne["SuppPrice"] = value1;
                            ligne["SuppDelay"] = Convert.ToInt32(DbUtils.RefList("SuppDelay",
                                "supplierslistprices where SupplierId = \"" + i + "\" and Code = \"" + j + "\"")[0]);
                            supplier1.Rows.Add(ligne);
                        }
                    }
                }

                button24.Enabled = true;
                progressBar3.Value = 10;
            }

            dataGridView9.DataSource = supplier1;
            MySqlConnection connection =
                new MySqlConnection(
                    "Server = localhost; Port = 3306; Database = kitbox; Uid = root; password = locomac6;");
            string query = "TRUNCATE TABLE suppliersprices";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            foreach (DataRow row in supplier1.Rows)
            {
                string price = row["SuppPrice"].ToString();
                string price1 = price.Replace(',', '.');
                DbUtils.InsertDb("suppliersprices", "SupplierId,Code,SuppPrice,SuppDelay",
                    "\"" + row["SupplierId"] + "\", \"" + row["Code"] + "\", \"" + price1 + "\", \"" +
                    row["SuppDelay"] + "\"");
                progressBar3.PerformStep();
            }

            label47.Text = @"Done";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (comboBox28.Text != "" && comboBox29.Text != "" && comboBox30.Text != "" && comboBox31.Text != "" &&
                comboBox32.Text != "")
            {
                string elementId = comboBox29.SelectedItem.ToString();
                string code = "";
                foreach (DataGridViewRow row in dataGridView12.Rows)
                {
                    if (row.Cells["Id"].Value.ToString() == elementId)
                    {
                        code = row.Cells["Code"].Value.ToString();
                    }
                }

                string couleur = comboBox28.SelectedItem.ToString();
                if (comboBox32.Text == @"Angle")
                {
                    string cupboardId = comboBox30.Text;
                    List<string> angleId =
                        DbUtils.RefList("AngleId", "angles where cupboardId = \"" + cupboardId + "\"");
                    string height = DbUtils.RefList("Height", "kitbox where Code =\"" + code + "\"")[0];
                    string newCode = DbUtils.RefList("Code",
                        "kitbox where Height =\"" + height + "\" and Ref = \"AngleBracket\" and Colour = \"" + couleur +
                        "\"")[0];
                    label61.Text = DbUtils.UpdateDb("angles", "Code",
                        "AngleId = \"" + angleId[Convert.ToInt32(elementId) - 1] + "\" and CupboardId = \"" +
                        cupboardId + "\"", newCode);
                    dataGridView12.DataSource = null;
                    Sandbox.Angles(comboBox30.SelectedItem.ToString(), dataGridView12);
                }
                else if (comboBox32.Text == @"Door")
                {
                    string boxId = comboBox31.Text;
                    List<string> doorId = DbUtils.RefList("DoorId", "doors where BoxId = \"" + boxId + "\"");
                    string height = DbUtils.RefList("Height", "kitbox where Code =\"" + code + "\"")[0];
                    string width = DbUtils.RefList("Width", "kitbox where Code =\"" + code + "\"")[0];
                    string newCode = DbUtils.RefList("Code",
                        "kitbox where Height =\"" + height + "\"and Width = \"" + width +
                        "\" and Ref = \"Door\" and Colour = \"" + couleur + "\"")[0];
                    label61.Text = DbUtils.UpdateDb("doors", "Code",
                        "DoorId = \"" + doorId[Convert.ToInt32(elementId) - 1] + "\" and BoxId = \"" + boxId + "\"",
                        newCode);
                    dataGridView12.DataSource = null;
                    Sandbox.Doors(comboBox31.SelectedItem.ToString(), dataGridView12);
                }
                else if (comboBox32.Text == @"Panels")
                {
                    var boxId = comboBox31.Text;
                    string position = "";
                    foreach (DataGridViewRow row in dataGridView12.Rows)
                    {
                        if (row.Cells["Id"].Value.ToString() == elementId)
                        {
                            position = row.Cells["Position"].Value.ToString();
                        }
                    }

                    List<string> panelId = DbUtils.RefList("PanelId", "panels where BoxId = \"" + boxId + "\"");
                    string suffix;
                    if (couleur == "White")
                    {
                        suffix = "WH";
                    }
                    else
                    {
                        suffix = "BR";
                    }

                    string newCode = code.Substring(0, code.Length - 2) + suffix;
                    label61.Text = DbUtils.UpdateDb("panels", "Code",
                        "PanelId = \"" + panelId[Convert.ToInt32(elementId) - 1] + "\" and BoxId = \"" + boxId +
                        "\" and Position = \"" + position + "\"", newCode);
                    dataGridView12.DataSource = null;
                    Sandbox.Panels(comboBox31.SelectedItem.ToString(), dataGridView12);
                }
            }
            else
            {
                MessageBox.Show(@"Please select every element", @"Element missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text != "" && comboBox7.Text != "")
            {
                string orderId = comboBox6.SelectedItem.ToString();
                string action = comboBox7.SelectedItem.ToString();
                if (action == "validate")
                {
                    Sandbox.SandBox(orderId);
                    List<string> codeList = DbUtils.RefList("Code", "listsitems where OrderId = \"" + orderId + "\"");
                    foreach (string i in codeList)
                    {
                        label25.Text = DbUtils.UpdateDb("listsitems", "Disponibility",
                            "OrderId = \"" + orderId + "\" and Code = \"" + i + "\"", "never tested");
                    }

                    label25.Text = DbUtils.UpdateDb("orders", "Status", "OrderId = \"" + orderId + "\"", "validate");
                }
                else if (action == "print")
                {
                    dataGridView3.DataSource = DbUtils.RefreshDb("listsitems where OrderId = \"" + orderId + "\"");
                    foreach (DataGridViewColumn col in dataGridView3.Columns)
                    {
                        col.Visible = true;
                    }

                    Colours(dataGridView3, "Disponibility");
                    //Open the print dialog
                    PrintDialog printDialog = new PrintDialog();
                    printDialog.Document = printDocument1;
                    printDialog.UseEXDialog = true;
                    //Get the document
                    if (DialogResult.OK == printDialog.ShowDialog())
                    {
                        printDocument1.DocumentName = "Test Page Print";
                        printDocument1.Print();
                    }
                }
                else if (action == "test availability")
                {
                    int isalltrue = 0;
                    int all = 0;
                    List<string> codeList = DbUtils.RefList("Code",
                        "listsitems where OrderId = \"" + orderId + "\" and Disponibility <> \"completed\"");
                    foreach (string i in codeList)
                    {
                        string number = DbUtils.RefList("Quantity",
                            "listsitems where OrderId = \"" + orderId + "\" and Code = \"" + i + "\"")[0];
                        if (DbUtils.RefList("Disponibility",
                                "listsitems where OrderId = \"" + orderId + "\" and Code = \"" + i + "\"")[0] !=
                            "completed")
                        {
                            if (Convert.ToInt32(DbUtils.RefList("Instock", "kitbox where Code = \"" + i + "\"")[0]) -
                                Convert.ToInt32(number) > 4)
                            {
                                isalltrue += 1;
                                label25.Text = DbUtils.UpdateDb("listsitems", "Disponibility",
                                    "OrderId = \"" + orderId + "\" and Code = \"" + i + "\"", "true");
                            }
                            else
                            {
                                label25.Text = DbUtils.UpdateDb("listsitems", "Disponibility",
                                    "OrderId = \"" + orderId + "\" and Code = \"" + i + "\"", "false");
                            }

                            all += 1;
                        }
                    }

                    if (isalltrue == all)
                    {
                        label25.Text = DbUtils.UpdateDb("orders", "Status", "OrderId = \"" + orderId + "\"",
                            "awaiting for removal");
                        foreach (string i in codeList)
                        {
                            if (DbUtils.RefList("Disponibility",
                                    "listsitems where OrderId = \"" + orderId + "\" and Code = \"" + i + "\"")[0] !=
                                "completed")
                            {
                                string quantity = DbUtils.RefList("Quantity",
                                    "listsitems where OrderId = \"" + orderId + "\" and Code = \"" + i + "\"")[0];
                                string stock = DbUtils.RefList("Instock", "kitbox where Code = \"" + i + "\"")[0];
                                int stockNow = Convert.ToInt32(stock) - Convert.ToInt32(quantity);
                                label25.Text = DbUtils.UpdateDb("kitbox", "Instock", "Code =\"" + i + "\"",
                                    stockNow.ToString());
                                label25.Text = DbUtils.UpdateDb("listsitems", "Disponibility",
                                    "OrderId = \"" + orderId + "\" and Code = \"" + i + "\"", "completed");
                            }
                        }
                    }
                    else
                    {
                        label25.Text = DbUtils.UpdateDb("orders", "Status", "OrderId = \"" + orderId + "\"",
                            "not ready");
                    }
                }
                else if (action == "remove now")
                {
                    label25.Text = DbUtils.UpdateDb("orders", "Status", "OrderId = \"" + orderId + "\"", "completed");
                }
                else if (action == "partial removal")
                {
                    int isalltrue = 0;
                    int all = 0;
                    List<string> codeAllList =
                        DbUtils.RefList("Code", "listsitems where OrderId = \"" + orderId + "\"");
                    foreach (string i in codeAllList)
                    {
                        if (DbUtils.RefList("Disponibility",
                                "listsitems where OrderId = \"" + orderId + "\" and Code = \"" + i + "\"")[0] !=
                            "completed")
                        {
                            string number = DbUtils.RefList("Quantity",
                                "listsitems where OrderId = \"" + orderId + "\" and Code = \"" + i + "\"")[0];
                            if (Convert.ToInt32(DbUtils.RefList("Instock", "kitbox where Code = \"" + i + "\"")[0]) -
                                Convert.ToInt32(number) > 4)
                            {
                                string quantity = DbUtils.RefList("Quantity",
                                    "listsitems where OrderId = \"" + orderId + "\" and Code = \"" + i + "\"")[0];
                                string stock = DbUtils.RefList("Instock", "kitbox where Code = \"" + i + "\"")[0];
                                int stockNow = Convert.ToInt32(stock) - Convert.ToInt32(quantity);
                                label25.Text = DbUtils.UpdateDb("kibox", "Instock", "Code =\"" + i + "\"",
                                    stockNow.ToString());
                                label25.Text = DbUtils.UpdateDb("listsitems", "Disponibility",
                                    "OrderId = \"" + orderId + "\" and Code = \"" + i + "\"", "completed");
                                isalltrue += 1;
                            }
                            else
                            {
                                if (DbUtils.RefList("Disponibility",
                                        "listsitems where OrderId = \"" + orderId + "\" and Code = \"" + i + "\"")[0] !=
                                    "added")
                                {
                                    string quantity = DbUtils.RefList("Quantity",
                                        "listsitems where OrderId = \"" + orderId + "\" and Code = \"" + i + "\"")[0];
                                    AddToPendingSuppliers(i, quantity);
                                    label25.Text = DbUtils.UpdateDb("listsitems", "Disponibility",
                                        "OrderId = \"" + orderId + "\" and Code = \"" + i + "\"", "added");
                                }
                            }
                        }
                        else if (DbUtils.RefList("Disponibility",
                                     "listsitems where OrderId = \"" + orderId + "\" and Code = \"" + i + "\"")[0] ==
                                 "completed")
                        {
                            isalltrue += 1;
                        }
                    }

                    foreach (string unused in codeAllList)
                    {
                        all += 1;
                    }

                    float alll = isalltrue;
                    float kn = all;
                    float procent = alll / kn * 100;
                    int procentint = (int) procent;
                    label25.Text = DbUtils.UpdateDb("orders", "Status", "OrderId = \"" + orderId + "\"",
                        "uncompleted, " + procentint + "%");
                }
                else if (action == "delete this order")
                {
                    label25.Text = DbUtils.DeleteRow("orders", "OrderId = \"" + orderId + "\"");
                }

                Coll(DbUtils.RefList("Status", "orders where OrderId =\"" + orderId + "\"")[0]);
                dataGridView3.DataSource = DbUtils.RefreshDb("listsitems where OrderId = \"" + orderId + "\"");
                foreach (DataGridViewColumn col in dataGridView3.Columns)
                {
                    col.Visible = true;
                }

                Colours(dataGridView3, "Disponibility");
                Start();
                comboBox6.Text = "";
                comboBox7.Text = "";
            }
            else
            {
                MessageBox.Show(@"Please select every element", @"Element missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void Coll(string status)
        {
            if (status == "pending")
            {
                label23.ForeColor = Color.Gold;
                label24.ForeColor = Color.White;
                label26.ForeColor = Color.White;
                label69.ForeColor = Color.White;
                label29.ForeColor = Color.White;
                label68.ForeColor = Color.White;
                progressBar4.Value = 0;
                progressBar5.Value = 0;
                progressBar6.Value = 0;
                progressBar7.Value = 0;
            }
            else if (status == "validate")
            {
                label23.ForeColor = Color.White;
                label24.ForeColor = Color.Aquamarine;
                label26.ForeColor = Color.White;
                label69.ForeColor = Color.White;
                label29.ForeColor = Color.White;
                label68.ForeColor = Color.White;
                progressBar4.Value = 100;
                progressBar5.Value = 0;
                progressBar6.Value = 0;
                progressBar7.Value = 0;
            }
            else if (status.Length > 11)
            {
                if (status.Substring(0, 11) == "uncompleted")
                {
                    label23.ForeColor = Color.White;
                    label24.ForeColor = Color.White;
                    label26.ForeColor = Color.White;
                    label69.ForeColor = Color.White;
                    label29.ForeColor = Color.Red;
                    label68.ForeColor = Color.White;
                    progressBar4.Value = 100;
                    progressBar5.Value = 100;
                    progressBar6.Value = 100;
                    progressBar7.Value = 0;
                }
                else if (status == "awaiting for removal")
                {
                    label23.ForeColor = Color.White;
                    label24.ForeColor = Color.White;
                    label26.ForeColor = Color.Fuchsia;
                    label69.ForeColor = Color.White;
                    label29.ForeColor = Color.White;
                    label68.ForeColor = Color.White;
                    progressBar4.Value = 100;
                    progressBar5.Value = 100;
                    progressBar6.Value = 0;
                    progressBar7.Value = 0;
                }
            }
            else if (status == "not ready")
            {
                label23.ForeColor = Color.White;
                label24.ForeColor = Color.White;
                label26.ForeColor = Color.White;
                label69.ForeColor = Color.Orange;
                label29.ForeColor = Color.White;
                label68.ForeColor = Color.White;
                progressBar4.Value = 100;
                progressBar5.Value = 100;
                progressBar6.Value = 0;
                progressBar7.Value = 0;
            }
            else if (status == "completed")
            {
                label23.ForeColor = Color.White;
                label24.ForeColor = Color.White;
                label26.ForeColor = Color.White;
                label69.ForeColor = Color.White;
                label29.ForeColor = Color.White;
                label68.ForeColor = Color.DeepSkyBlue;
                progressBar4.Value = 100;
                progressBar5.Value = 100;
                progressBar6.Value = 100;
                progressBar7.Value = 100;
            }
        }

        private void comboBox6_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();
            comboBox7.Text = "";
            ComboBox senderComboBox = (ComboBox) sender;
            // Change the length of the text box depending on what the user has 
            // selected and committed using the SelectionLength property.
            if (senderComboBox.SelectionLength >= 0)
            {
                var orderId = comboBox6.SelectedItem.ToString();
                string status = DbUtils.RefList("Status", "orders where OrderId = \"" + orderId + "\"")[0];
                Coll(status);
                if (status == "pending")
                {
                    comboBox7.Items.Add("validate");
                    comboBox7.Items.Add("delete this order");
                }
                else if (status == "completed")
                {
                    comboBox7.Items.Add("print");
                }
                else if (status == "validate")
                {
                    comboBox7.Items.Add("test availability");
                }
                else if (status.Length > 11)
                {
                    if (status.Substring(0, 11) == "uncompleted")
                    {
                        comboBox7.Items.Add("test availability");
                    }
                    else if (status == "awaiting for removal")
                    {
                        comboBox7.Items.Add("remove now");
                    }
                }
                else if (status == "not ready")
                {
                    comboBox7.Items.Add("partial removal");
                    comboBox7.Items.Add("test availability");
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (comboBox18.Text != "")
            {
                DataTable elements = new DataTable();
                DataColumn dtColumn = new DataColumn
                {
                    DataType = typeof(int),
                    ColumnName = "Id",
                    ReadOnly = true,
                    Unique = true
                };
                elements.Columns.Add(dtColumn);
                DataColumn dtColumn1 = new DataColumn
                {
                    DataType = typeof(string),
                    ColumnName = "Code",
                    ReadOnly = true,
                    Unique = false
                };
                elements.Columns.Add(dtColumn1);
                DataColumn dtColumn2 = new DataColumn
                {
                    DataType = typeof(int),
                    ColumnName = "Quantity",
                    ReadOnly = true,
                    Unique = false
                };
                elements.Columns.Add(dtColumn2);
                int index = 1;
                double amount = 0;
                foreach (string i in DbUtils.RefList("Code", "supplierspending"))
                {
                    string supplierId = DbUtils.RefList("SupplierId", "suppliersprices where Code = \"" + i + "\"")[0];
                    if (supplierId == comboBox18.SelectedItem.ToString())
                    {
                        string quantity = DbUtils.RefList("Quantity", "supplierspending where Code = \"" + i + "\"")[0];
                        string price = DbUtils.RefList("SuppPrice", "suppliersprices where Code = \"" + i + "\"")[0];
                        double priceDouble = Convert.ToDouble(price);
                        int quantityInt = Convert.ToInt32(quantity);
                        amount += priceDouble * quantityInt;
                        DataRow myDataRow;
                        myDataRow = elements.NewRow();
                        myDataRow["Id"] = index;
                        myDataRow["Code"] = i;
                        myDataRow["Quantity"] = quantity;
                        index += 1;
                        elements.Rows.Add(myDataRow);
                    }
                }

                dataGridView5.DataSource = elements;
                label34.Text = @"Amount: " + amount + @"€";
                if (Math.Abs(amount) > 0.00)
                {
                    button18.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(@"Please select a SupplierId", @"SupplierId missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string columns = "SupplierId,Amount,Date,Status";
            string amount = label34.Text.Split(' ')[1];
            string amount1 = amount.Split('€')[0];
            string realamount = amount1.Replace(',', '.');
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");
            string values = "\"" + comboBox18.Text + "\", \"" + realamount + "\", \"" + sqlFormattedDate + "\", \"" +
                            "send" + "\"";
            DbUtils.InsertDb("suppliersorders", columns, values);
            List<string> idList = DbUtils.RefList("SupplierOrderId", "suppliersorders");
            int x = 0;
            foreach (string i in idList)
            {
                if (Convert.ToInt32(i) > x)
                {
                    x = Convert.ToInt32(i);
                }
            }

            string supplierOrderId = x.ToString();
            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                string code = row.Cells["Code"].Value.ToString();
                string quantity = row.Cells["Quantity"].Value.ToString();
                string col = "SupplierOrderId,Code,Quantity";
                string val = "\"" + supplierOrderId + "\", \"" + code + "\", \"" + quantity + "\"";
                DbUtils.InsertDb("supplierslistsitems", col, val);
                label34.Text = DbUtils.DeleteRow("supplierspending",
                    "Code = \"" + code + "\"and Quantity = \"" + quantity + "\"");
            }

            dataGridView5.DataSource = null;
            label34.Text = @"Amount: 0€";
            button18.Enabled = false;
            comboBox18.Text = "";
            dataGridView8.DataSource = null;
            dataGridView7.DataSource = DbUtils.RefreshDb("suppliersorders");
            comboBox14.DataSource = DbUtils.RefList("SupplierOrderId", "suppliersorders");
            comboBox14.DisplayMember = "SupplierOrderId";
            comboBox14.Text = "";
            comboBox8.DataSource = DbUtils.RefList("SupplierOrderId", "suppliersorders where status = \"send\"");
            comboBox8.DisplayMember = "SupplierOrderId";
            comboBox8.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (comboBox14.Text != "")
            {
                dataGridView8.DataSource =
                    DbUtils.RefreshDb("supplierslistsitems where SupplierOrderId = \"" + comboBox14.Text + "\"");
            }
            else
            {
                MessageBox.Show(@"Please select a SupplierOrderId", @"SupplierOrderId missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (comboBox8.Text != "")
            {
                foreach (string i in DbUtils.RefList("Code",
                    "supplierslistsitems where SupplierOrderId = \"" + comboBox8.SelectedItem + "\""))
                {
                    string quantity = DbUtils.RefList("Quantity",
                        "supplierslistsitems where SupplierOrderId = \"" + comboBox8.SelectedItem + "\"and Code = \"" +
                        i + "\"")[0];
                    string instock = DbUtils.RefList("Instock", "kitbox where Code = \"" + i + "\"")[0];
                    int newquantity = Convert.ToInt32(quantity) + Convert.ToInt32(instock);
                    label30.Text = DbUtils.UpdateDb("kitbox", "Instock", "Code = \"" + i + "\"",
                        newquantity.ToString());
                    label30.Text = DbUtils.UpdateDb("suppliersorders", "Status",
                        "SupplierOrderId = \"" + comboBox8.SelectedItem + "\"", "received");
                    comboBox8.Text = "";
                    dataGridView7.DataSource = DbUtils.RefreshDb("suppliersorders");
                }
            }
            else
            {
                MessageBox.Show(@"Please select a SupplierOrderId", @"SupplierOrderId missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                if (Convert.ToInt32(row.Cells["Instock"].Value.ToString()) <
                    Convert.ToInt32(row.Cells["MinimumStock"].Value.ToString()))
                {
                    AddToPendingSuppliers(row.Cells["Code"].Value.ToString(), "1000");
                }
            }
        }
        private void printDocument1_BeginPrint(object sender,
    System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;
                arrColumnLefts = new List<int>();
                arrColumnLefts.Clear();
                arrColumnWidths = new List<int>();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iCount = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView3.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void printDocument1_PrintPage(object sender,
    System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView3.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                            (double)iTotalWidth * (double)iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                int iRow = 0;
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView3.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView3.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            string orderId = GridRow.Cells["OrderId"].Value.ToString();
                            e.Graphics.DrawString("Kitbox \nCustomer: " + DbUtils.RefList("CustomerName", "orders natural join customers where OrderId =\"" + orderId + "\"")[0],
                                new Font(dataGridView3.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString("Kitbox \nCustomer: " + DbUtils.RefList("CustomerName", "orders natural join customers where OrderId =\"" + orderId + "\"")[0],
                                new Font(dataGridView3.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);
                            DateTime now = DateTime.Now;
                            string strDate = now.ToString("dddd, yyyy MMMM dd", CultureInfo.CreateSpecificCulture("en-US"));
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(dataGridView3.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(dataGridView3.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString("Kitbox \nCustomer: " + DbUtils.RefList("CustomerName", "orders natural join customers where OrderId =\"" + orderId + "\"")[0],
                                new Font(new Font(dataGridView3.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView3.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(),
                                    Cel.InheritedStyle.Font,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }
    }
}