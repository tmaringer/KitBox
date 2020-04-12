using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace ShopInterfaceBeta
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class SuppliersOrders : Page
    {
        private static DataTable DataTable = new DataTable();
        public SuppliersOrders()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);
            FirstThings();
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        public void FirstThings()
        {
            FillDataGrid(DbUtils.RefreshDb("suppliersorders"), DataGrid1);
            ComboBox4.Items.Clear();
            foreach (string i in DbUtils.RefList("Code", "kitbox"))
            {
                ComboBox4.Items.Add(i);
            }
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(string));
            dataTable.Columns.Add("Code", typeof(string));
            dataTable.Columns.Add("Quantity", typeof(Int32));
            DataGrid1.Columns[DataGrid1.Columns.Count - 1].CellStyle = (Style)DataGrid1.Resources["Test"];
            ComboBox1.Items.Clear();
            ComboBox2.Items.Clear();
            ComboBox3.Items.Clear();
            foreach (string i in DbUtils.RefList("SupplierId", "suppliers"))
            {
                ComboBox3.Items.Add(i);
            }
            foreach (string i in DbUtils.RefList("SupplierOrderId", "suppliersorders where Status = \"sent\""))
            {
                ComboBox2.Items.Add(i);
            }
            foreach (string i in DbUtils.RefList("SupplierOrderId", "suppliersorders"))
            {
                ComboBox1.Items.Add(i);
            }
        }
        public static void FillDataGrid(DataTable table, DataGrid grid)
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

            var collection = new ObservableCollection<object>();
            foreach (DataRow row in table.Rows)
            {
                try
                {
                    if (row["Status"].ToString() == "received")
                    {
                        row["Status"] = "\xE8FB";
                    }
                    else
                    {
                        row["Status"] = "\xE724";
                    }
                }
                catch
                {

                }

                collection.Add(row.ItemArray);
            }
            grid.AutoGenerateColumns = false;
            grid.ItemsSource = collection;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            DataGrid2.Columns.Clear();
            string supplierOrderId = ComboBox1.SelectedItem.ToString();
            DataTable items = DbUtils.RefreshDb("supplierslistsitems where SupplierOrderId = \"" + supplierOrderId + "\"");
            for (int i = 0; i < items.Columns.Count; i++)
            {
                DataGrid2.Columns.Add(new DataGridTextColumn()
                {
                    Header = items.Columns[i].ColumnName,
                    Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
                });
            }

            var collection = new ObservableCollection<object>();
            foreach (DataRow row in items.Rows)
            {
                collection.Add(row.ItemArray);
            }
            DataGrid2.AutoGenerateColumns = false;
            DataGrid2.ItemsSource = collection;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
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
                if (supplierId == ComboBox3.SelectedItem.ToString())
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
            DataTable = elements;
            FillDataGrid(DataTable, DataGrid3);
            amountLabel.Text = @"Amount: " + amount + @"€";
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            string columns = "SupplierId,Amount,Date,Status";
            string amount = amountLabel.Text.Split(' ')[1];
            string amount1 = amount.Split('€')[0];
            string realamount = amount1.Replace(',', '.');
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");
            string values = "\"" + ComboBox3.SelectedItem.ToString() + "\", \"" + realamount + "\", \"" + sqlFormattedDate + "\", \"" +
                            "sent" + "\"";
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

            string supplierOrderId = (x).ToString();
            foreach (DataRow row in DataTable.Rows)
            {
                string code = row["Code"].ToString();
                string quantity = row["Quantity"].ToString();
                string col = "SupplierOrderId,Code,Quantity";
                string val = "\"" + supplierOrderId + "\", \"" + code + "\", \"" + quantity + "\"";
                DbUtils.InsertDb("supplierslistsitems", col, val);
                amountLabel.Text = DbUtils.DeleteRow("supplierspending",
                    "Code = \"" + code + "\"and Quantity = \"" + quantity + "\"");
            }

            amountLabel.Text = @"Amount: 0€";
            Button4.IsEnabled = false;
            DataGrid3.Columns.Clear();
            ComboBox3.Text = "";
            FirstThings();
        }

        private void AddToPendingSuppliers(string code, string quantity)
        {
            if (DbUtils.RefList("Code", "supplierspending").Contains(code))
            {
                string valueadd = (Convert.ToInt32(quantity) + Convert.ToInt32(DbUtils.RefList("Quantity",
                    "supplierspending where Code = \"" + code + "\"")[0])).ToString();
                TexBox4.Text = DbUtils.UpdateDb("supplierspending", "Quantity", "Code = \"" + code + "\"", valueadd);
            }
            else
            {
                DbUtils.InsertDb("supplierspending", "code, quantity", "\"" + code + "\", \"" + quantity + "\"");
            }

            if (DbUtils.RefList("Quantity", "supplierspending").Contains("0"))
            {
                DbUtils.DeleteRow("supplierspending", "Quantity = \"0\"");
            }
            TexBox4.Text = "";

        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            string code = ComboBox4.SelectedItem.ToString();
            string quantity = TexBox4.Text;
            AddToPendingSuppliers(code, quantity);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            foreach (string i in DbUtils.RefList("Code",
                    "supplierslistsitems where SupplierOrderId = \"" + ComboBox2.SelectedItem + "\""))
            {
                string quantity = DbUtils.RefList("Quantity",
                    "supplierslistsitems where SupplierOrderId = \"" + ComboBox2.SelectedItem + "\"and Code = \"" +
                    i + "\"")[0];
                string instock = DbUtils.RefList("Instock", "kitbox where Code = \"" + i + "\"")[0];
                int newquantity = Convert.ToInt32(quantity) + Convert.ToInt32(instock);
                TextBlock2.Text = DbUtils.UpdateDb("kitbox", "Instock", "Code = \"" + i + "\"",
                    newquantity.ToString());
                TextBlock2.Text = DbUtils.UpdateDb("suppliersorders", "Status",
                    "SupplierOrderId = \"" + ComboBox2.SelectedItem + "\"", "received");
                ComboBox2.Text = "";
                FirstThings();
            }
        }

        public class SupplierOrder
        {
            public string SupplierOrderId { get; set; }
            public string SupplierId { get; set; }
            public string Amount { get; set; }
            public string Date { get; set; }
            public string Status { get; set; }
        }

        public class SupplierOrderPart
        {
            public string ItemId { get; set; }
            public string SupplierOrderId { get; set; }
            public string Code { get; set; }
            public string Quantity { get; set; }
        }

        public class SupplierPendingPart
        {
            public string Id { get; set; }
            public string Code { get; set; }
            public string Quantity { get; set; }
        }
    }
}
