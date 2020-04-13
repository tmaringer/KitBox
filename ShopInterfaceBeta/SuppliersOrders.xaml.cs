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
        private string SupplierOrderId;
        private string Amount;
        private string SupplierId;
        public SuppliersOrders()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);
            FirstThings();
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        public void FirstThings()
        {
            FillDataGrid1(DbUtils.RefreshDb("suppliersorders"), DataGrid1);
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
            ComboBox3.Items.Clear();
            foreach (string i in DbUtils.RefList("SupplierId", "suppliers"))
            {
                ComboBox3.Items.Add(i);
            }
        }

        public static void FillDataGrid1(DataTable table, DataGrid grid)
        {
            List<SupplierOrder> supplierOrders = new List<SupplierOrder>();
            foreach (DataRow row in table.Rows)
            {
                if (row["Status"].ToString() == "received")
                {
                    row["Status"] = "\xE8FB";
                }
                else
                {
                    row["Status"] = "\xE724";
                }
                supplierOrders.Add(new SupplierOrder()
                {
                    SupplierOrderId = row["SupplierOrderId"].ToString(),
                    SupplierId = row["SupplierId"].ToString(),
                    Amount = row["Amount"].ToString() + "€",
                    Date = row["Date"].ToString(),
                    Status = row["Status"].ToString()
                }); 
            }
            grid.ItemsSource = supplierOrders;
            grid.AutoGenerateColumns = false;
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
                SupplierId = ComboBox3.SelectedItem.ToString();
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
            List<SupplierPendingPart> supplierPendingParts = new List<SupplierPendingPart>();
            foreach (DataRow row in elements.Rows)
            {
                supplierPendingParts.Add(new SupplierPendingPart()
                {
                    Id = row["Id"].ToString(),
                    Code = row["Code"].ToString(),
                    Quantity = row["Quantity"].ToString()
                });
            }
            DataGrid3.ItemsSource = supplierPendingParts;
            DataGrid3.AutoGenerateColumns = false;
            DataTable = elements;
            Amount = amount.ToString();
            Add.IsEnabled = true;
            ShowFlyout.Hide();
            if (supplierPendingParts.Count != 0)
            {
                Order.IsEnabled = true;
            }
            else
            {
                Order.IsEnabled = false;
            }
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
            AddFlyout.Hide();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string z;
            foreach (string i in DbUtils.RefList("Code",
                    "supplierslistsitems where SupplierOrderId = \"" + SupplierOrderId + "\""))
            {
                string quantity = DbUtils.RefList("Quantity",
                    "supplierslistsitems where SupplierOrderId = \"" + SupplierOrderId + "\"and Code = \"" +
                    i + "\"")[0];
                string instock = DbUtils.RefList("Instock", "kitbox where Code = \"" + i + "\"")[0];
                int newquantity = Convert.ToInt32(quantity) + Convert.ToInt32(instock);
                z = DbUtils.UpdateDb("kitbox", "Instock", "Code = \"" + i + "\"",
                    newquantity.ToString());
                z = DbUtils.UpdateDb("suppliersorders", "Status",
                    "SupplierOrderId = \"" + SupplierOrderId + "\"", "received");
                FirstThings();
            }
            Received.IsEnabled = false;
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

        private void DataGrid1_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if((sender as DataGrid).CurrentColumn.Header.ToString() == "SupplierOrderId")
            {
                SupplierOrderId = ((SupplierOrder)((sender as DataGrid).SelectedItem)).SupplierOrderId.ToString();
                if (DbUtils.RefList("Status", "suppliersorders where SupplierOrderId = \"" + SupplierOrderId + "\"")[0] == "sent")
                {
                    Received.IsEnabled = true;
                }
                else
                {
                    Received.IsEnabled = false;
                }
                string supplierOrderId = SupplierOrderId;
                DataTable items = DbUtils.RefreshDb("supplierslistsitems where SupplierOrderId = \"" + supplierOrderId + "\"");
                List<SupplierOrderPart> supplierOrderParts = new List<SupplierOrderPart>();
                foreach (DataRow row in items.Rows)
                {
                    supplierOrderParts.Add(new SupplierOrderPart()
                    {
                        ItemId = row["ItemId"].ToString(),
                        SupplierOrderId = row["SupplierOrderId"].ToString(),
                        Code = row["Code"].ToString(),
                        Quantity = row["Quantity"].ToString()
                    });
                }
                DataGrid2.ItemsSource = supplierOrderParts;
                DataGrid2.AutoGenerateColumns = false;
            }
        }

        private async void Order_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog Order = new ContentDialog()
            {
                Title = "Order confirmation",
                Content = "Order now ?\n The amount equals " + Amount + " €.",
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "I'm not sure",
                DefaultButton = ContentDialogButton.Secondary
            };
            ContentDialogResult result = await Order.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                string columns = "SupplierId,Amount,Date,Status";
                string realamount = Amount.Replace(',','.');
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");
                string values = "\"" + SupplierId + "\", \"" + realamount + "\", \"" + sqlFormattedDate + "\", \"" +"sent" + "\"";
                string k = "";
                k = DbUtils.InsertDb("suppliersorders", columns, values);
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
                    k = DbUtils.InsertDb("supplierslistsitems", col, val);
                    k = DbUtils.DeleteRow("supplierspending", "Code = \"" + code + "\"");
                }
                Order.IsEnabled = false;
                FirstThings();
                DataGrid3.ItemsSource = null;
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
