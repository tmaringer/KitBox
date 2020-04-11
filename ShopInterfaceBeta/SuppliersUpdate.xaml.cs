using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using muxc = Microsoft.UI.Xaml.Controls;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Globalization.NumberFormatting;
using Microsoft.UI.Xaml.Controls;
using MySql.Data.MySqlClient;
using ShopInterface;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace ShopInterfaceBeta
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class SuppliersUpdate : Page
    {
        private string actualSupplierId;
        public SuppliersUpdate()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);
            ComboBox1.Items.Clear();
            SetNumberBoxNumberFormatter(0.01, 2, addSuppPrice);
            SetNumberBoxNumberFormatter(1, 0, addSuppDelay);
            foreach (string i in DbUtils.RefList("SupplierId","suppliers"))
            {
                ComboBox1.Items.Add(i);
            }
            //FillDataGridHeader(DbUtils.RefreshDb("supplierslistprices"), DataGrid1);
            //FillDataGridHeader(DbUtils.RefreshDb("supplierslistprices"), DataGrid2);
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        public static void FillDataGrid(DataTable table, DataGrid grid)
        {
            List<SuppliersItem> suppliersItems = new List<SuppliersItem>();
            foreach (DataRow row in table.Rows)
            {
                suppliersItems.Add(new SuppliersItem()
                {
                    SupplierId = row["SupplierId"].ToString(),
                    Code = row["Code"].ToString(),
                    SuppDelay = row["SuppDelay"].ToString(),
                    SuppPrice = row["SuppPrice"].ToString()
                });
            }
            grid.AutoGenerateColumns = false;
            grid.ItemsSource = suppliersItems;
        }

        public static void FillDataGridHeader(DataTable table, DataGrid grid)
        {
            grid.Columns.Clear();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                grid.Columns.Add(new DataGridTextColumn()
                {
                    Header = table.Columns[i].ColumnName,
                    Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
                });
            }
        }

        public class SuppliersItem
        {
            public string SupplierId { get; set; }
            public string Code { get; set; }
            public string SuppPrice { get; set; }
            public string SuppDelay { get; set; }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            NotificationToast.SimpleNotification("Start updating suppliers' prices");
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);
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
            }

            FillDataGrid(supplier1, DataGrid2);
            MySqlConnection connection = new MySqlConnection(DbUtils.MyConString);
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
            }
            NotificationToast.SimpleNotification("Update completed");
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string supplierId = actualSupplierId;
            string code = addCode.Text;
            double suppPrice = addSuppPrice.Value;
            string price = suppPrice.ToString().Replace(',', '.');
            string suppDelay = addSuppDelay.Text;
            string columns = "SupplierId,Code,SuppPrice,SuppDelay";
            string values = "\"" + supplierId + "\", \"" + code + "\", \"" + price + "\", \"" + suppDelay + "\"";
            addCode.Text = DbUtils.InsertDb("supplierslistprices", columns, values);
            addCode.Text = "";
            addSuppPrice.Text = "";
            addSuppDelay.Text = "";
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string SupplierId = ComboBox1.SelectedItem.ToString();
            actualSupplierId = SupplierId;
            modifyCode.Items.Clear();
            foreach (string i in DbUtils.RefList("Code", "supplierslistprices where SupplierId = \"" + actualSupplierId + "\""))
            {
                modifyCode.Items.Add(i);
            }
            modifyRow.Items.Clear();
            DataTable supplierCatalogue = DbUtils.RefreshDb("supplierslistprices where SupplierId = \"" + SupplierId + "\"");
            foreach (DataColumn i in supplierCatalogue.Columns)
            {
                string header = i.ColumnName;
            }
            modifyRow.Items.Add("SuppPrice");
            modifyRow.Items.Add("SuppDelay");
            FillDataGrid(supplierCatalogue, DataGrid1);
            FlyoutCreate.Hide();
            Add.IsEnabled = true;
            Delete.IsEnabled = true;
            Modify.IsEnabled = true;
            FillDataGrid(DbUtils.RefreshDb("supplierslistprices where SupplierId = \"" + actualSupplierId + "\""), DataGrid1);
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            string code = modifyCode.SelectedItem.ToString();
            string row = modifyRow.SelectedItem.ToString();
            double value1 = modifyValue.Value;
            string value;
            if (row == "SuppPrice")
            {
                value = value1.ToString().Replace(',', '.');
            }
            else
            {
                value = value1.ToString();
            }
            modifyValue.Text = DbUtils.UpdateDb("supplierslistprices", row, "SupplierId = \"" + actualSupplierId + "\" and Code = \"" + code + "\"", value);
            modifyValue.Text = "";
            modifyCode.SelectedItem = "";
            modifyRow.SelectedItem = "";
            FillDataGrid(DbUtils.RefreshDb("supplierslistprices where SupplierId = \"" + actualSupplierId + "\""), DataGrid1);
            FlyoutModify.Hide();
        }

        private void SetNumberBoxNumberFormatter(double x, int decimals, NumberBox numberBox)
        {
            IncrementNumberRounder rounder = new IncrementNumberRounder();
            rounder.Increment = x;
            rounder.RoundingAlgorithm = RoundingAlgorithm.RoundUp;

            DecimalFormatter formatter = new DecimalFormatter();
            formatter.NumberRounder = rounder;
            formatter.FractionDigits = decimals;
            numberBox.NumberFormatter = formatter;
        }

        private void modifyRow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
            {
                if ((sender as ComboBox).SelectedItem.ToString() == "SuppPrice")
                {
                    SetNumberBoxNumberFormatter(0.01, 2, modifyValue);
                }
                else if ((sender as ComboBox).SelectedItem.ToString() == "SuppDelay")
                {
                    SetNumberBoxNumberFormatter(1, 0, modifyValue);
                }
            }
        }
    }
}
