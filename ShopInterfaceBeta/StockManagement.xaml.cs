using Microsoft.Toolkit.Uwp.UI.Controls;
using ShopInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using static ShopInterfaceBeta.StockManagement;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace ShopInterfaceBeta
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class StockManagement : Page
    {
        private readonly List<string> _columnDay = new List<string>();
        private readonly List<string> _columnMonth = new List<string>();
        private readonly List<string> _columnYear = new List<string>();
        public StockManagement()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);
            FillDataGrid(DbUtils.RefreshDb("kitbox"), DataGrid1);
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        public class Records
        {
            public string Interval
            {
                get;
                set;
            }
            public int Number
            {
                get;
                set;
            }
        }

        public static void FillDataGrid(DataTable table, DataGrid DataGrid1)
        {
            table.Columns.Remove("Ref");
            table.Columns.Remove("Dimensions");
            table.Columns.Remove("Height");
            table.Columns.Remove("Width");
            table.Columns.Remove("Depth");
            table.Columns.Remove("Colour");
            table.Columns.Remove("NbPartsBox");
            table.Columns.Remove("CustPrice");
            table.Columns.Add("Avaibility", typeof(String));
            List<StockPart> stockParts = new List<StockPart>();
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["Instock"]) > Convert.ToInt32(row["MinimumStock"]))
                {
                    row["Avaibility"] = "\xE8FB";
                }
                else if (Convert.ToInt32(row["Instock"]) < 4)
                {
                    row["Avaibility"] = "\xE711";
                }
                else

                {
                    row["Avaibility"] = "\xE7BA";
                }
                Dictionary<string, int> graphMonth = new Dictionary<string, int>();
                Dictionary<string, int> values = DbUtils.SelectCondDb("sales", row["Code"].ToString());
                foreach (KeyValuePair<string, int> entry in values)
                {
                    string key = entry.Key;
                    //string year = key.Split('/')[1];
                    string month = key.Split('-')[0] + "/" + key.Split('-')[1];
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
                List<Records> records2 = new List<Records>();
                Dictionary<string, int> graphYear = new Dictionary<string, int>();
                foreach (KeyValuePair<string, int> entry in graphMonth)
                {
                    string key = entry.Key;
                    string year = "20" + key.Split('/')[1];
                    if (graphYear.ContainsKey(year))
                    {
                        graphYear[year] = graphYear[year] + entry.Value;
                    }
                    else
                    {
                        graphYear.Add(year, entry.Value);
                    }
                }

                foreach (KeyValuePair<string, int> entry in graphYear)
                {
                    records2.Add(new Records()
                    {
                        Interval = entry.Key,
                        Number = entry.Value
                    });
                }
                List<Records> records = new List<Records>();
                for(int x = graphMonth.Count-12; x < graphMonth.Count; x++)
                {
                    months.Add(graphMonth.Keys.ElementAt(x));
                    records.Add(new Records()
                    {
                        Interval = graphMonth.Keys.ElementAt(x).Split('/')[0],
                        Number = graphMonth.Values.ElementAt(x)
                    });
                }
                List<Records> records1 = new List<Records>();
                for (int x = graphMonth.Count - 24; x < graphMonth.Count-12; x++)
                {
                    months.Add(graphMonth.Keys.ElementAt(x));
                    records1.Add(new Records()
                    {
                        Interval = graphMonth.Keys.ElementAt(x).Split('/')[0],
                        Number = graphMonth.Values.ElementAt(x)
                    });
                }
                stockParts.Add(new StockPart()
                {
                    Code = row["Code"].ToString(),
                    MinimumStock = row["MinimumStock"].ToString(),
                    Instock = row["Instock"].ToString(),
                    Avaibility = row["Avaibility"].ToString(),
                    Records = records,
                    Records1 = records1,
                    Records2 = records2
                }) ;
            }
            DataGrid1.ItemsSource = stockParts;
            DataGrid1.AutoGenerateColumns = false;
        }

        /*

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Average.Text = "";
            List<Records> records = new List<Records>();
            if (ComboBox1.SelectedItem.ToString() != "" && ComboBox2.SelectedItem.ToString() != "")
            {

                Dictionary<string, int> values = DbUtils.SelectCondDb("sales", ComboBox1.SelectedItem.ToString());
                if (ComboBox2.SelectedItem.ToString() == "Month")
                {
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
                    records.Clear();
                    foreach (KeyValuePair<string, int> entry in graphMonth)
                    {
                        months.Add(entry.Key);
                        records.Add(new Records()
                        {
                            Interval = entry.Key,
                            Number = entry.Value
                        });
                    }
                    int all = graphMonth[months[months.Count - 2]] + graphMonth[months[months.Count - 3]] +
                                graphMonth[months[months.Count - 4]] + graphMonth[months[months.Count - 5]] +
                                graphMonth[months[months.Count - 6]] + graphMonth[months[months.Count - 7]];
                    double average = all / 6;
                    Average.Text = "The average of the last six months equals " + ((Int32)average).ToString() + ".";
                }
                else if (ComboBox2.SelectedItem.ToString() == "Year")
                {
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
                        records.Add(new Records()
                        {
                            Interval = entry.Key,
                            Number = entry.Value
                        });
                    }
                }
                (ColumnChart.Series[0] as ColumnSeries).ItemsSource = records;
            }
        }

        private void FirstThings()
        {
            DataTable ninja = DbUtils.RefreshDb("sales");
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
            ComboBox1.Items.Clear();
            foreach (string i in DbUtils.RefList("Code","kitbox"))
            {
                ComboBox1.Items.Add(i);
            }
            ComboBox2.Items.Clear();
            ComboBox2.Items.Add("Month");
            ComboBox2.Items.Add("Year");
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox3.Items.Clear();
            ComboBox3.Text = "";
            ComboBox senderComboBox = (ComboBox)sender;
            if (senderComboBox.SelectedItem.ToString().Length >= 0)
            {
                if (ComboBox2.SelectedItem.ToString() == "year")
                {
                    foreach (string year in _columnYear)
                    {
                        ComboBox3.Items.Add(year);
                    }
                }

                if (ComboBox2.SelectedItem.ToString() == "month")
                {
                    foreach (string month in _columnMonth)
                    {
                        ComboBox3.Items.Add(month);
                    }
                }

                if (ComboBox2.SelectedItem.ToString() == "day")
                {
                    foreach (string day in _columnDay)
                    {
                        ComboBox3.Items.Add(day);
                    }
                }
            }
        }
        */

        public class StockPart
        {
            public string Code { get; set; }
            public string MinimumStock { get; set; }
            public string Instock { get; set; }
            public string Avaibility { get; set; }

            public List<Records> Records { get; set; }
            public List<Records> Records1 { get; set; }
            public List<Records> Records2 { get; set; }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);
            NotificationToast.SimpleNotification("Updating the stock minimum value...");
            List<string> code = DbUtils.RefList("Code", "kitbox");
            foreach (string i in code)
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
                int all = 0;
                try
                {
                    all = graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 2]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 3]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 4]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 5]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 6]] +
                          graphMonthIncStock[monthsIncStock[monthsIncStock.Count - 7]];
                }
                catch
                {

                }
                int average = all / 12;
                string x = "";
                x = DbUtils.UpdateDb("kitbox", "MinimumStock", "Code = \"" + i + "\"", average.ToString());
            }
            FillDataGrid(DbUtils.RefreshDb("kitbox"), DataGrid1);
            DataGrid1.Columns[DataGrid1.Columns.Count - 1].CellStyle = (Style)DataGrid1.Resources["Test"];
            NotificationToast.SimpleNotification("Update completed");
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
    }
}
