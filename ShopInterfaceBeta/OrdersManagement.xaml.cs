using Microsoft.Toolkit.Uwp.Helpers;
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
using Windows.Graphics.Printing;
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
    public sealed partial class OrdersManagement : Page
    {
        List<string> _listSuggestion = null;
        public OrdersManagement()
        {
            this.InitializeComponent();
            ComboBox1.Items.Clear();
            foreach (string i in DbUtils.RefList("OrderId", "orders where Status != \"pending\""))
            {
                ComboBox1.Items.Add(i);
            }
            FillDataGrid1(SetColumnsOrder(DbUtils.RefreshDb("orders natural join customers")), DataGrid1);
        }

        public static DataTable SetColumnsOrder(DataTable table)
        {
            table.Columns.Remove("CustomerPhone");
            table.Columns.Remove("CustomerId");
            table.Columns["OrderId"].SetOrdinal(0);
            table.Columns["CustomerName"].SetOrdinal(1);
            table.Columns["Status"].SetOrdinal(2);
            return table;
        }

        public static void FillDataGrid1(DataTable table, DataGrid grid)
        {
            List<Order> orders = new List<Order>();
            foreach (DataRow row in table.Rows)
            {
                orders.Add(new Order()
                {
                    CustomerName = row["CustomerName"].ToString(),
                    OrderId = row["OrderId"].ToString(),
                    Status = row["Status"].ToString()
                });
            }
            grid.AutoGenerateColumns = false;
            grid.ItemsSource = orders;
        }

        public static void FillDataGrid2(DataTable table, DataGrid grid)
        {
            List<Item> items = new List<Item>();
            foreach (DataRow row in table.Rows)
            {
                items.Add(new Item()
                {
                    OrderId = row["OrderId"].ToString(),
                    Code = row["Code"].ToString(),
                    Quantity = row["Quantity"].ToString(),
                    Disponibility = row["Disponibility"].ToString()
                });
            }
            grid.AutoGenerateColumns = false;
            grid.ItemsSource = items;
        }

        private void AddToPendingSuppliers(string code, string quantity)
        {
            if (DbUtils.RefList("Code", "supplierspending").Contains(code))
            {
                string valueadd = (Convert.ToInt32(quantity) + Convert.ToInt32(DbUtils.RefList("Quantity",
                    "supplierspending where Code = \"" + code + "\"")[0])).ToString();
                string i = "";
                i = DbUtils.UpdateDb("supplierspending", "Quantity", "Code = \"" + code + "\"", valueadd);
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

        private void DataGrid1_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (DataGrid1.CurrentColumn.Header.ToString() == "OrderId")
            {
                var orderId = ((Order)((sender as DataGrid).SelectedItem)).OrderId;
                Validate.IsEnabled = false;
                Delete.IsEnabled = false;
                Test.IsEnabled = false;
                Partial.IsEnabled = false;
                Close.IsEnabled = false;
                Validate.Tag = "";
                Delete.Tag = "";
                Test.Tag = "";
                Partial.Tag = "";
                Close.Tag = "";
                string status = DbUtils.RefList("Status", "orders where OrderId = \"" + orderId + "\"")[0];
                if (status == "pending")
                {
                    Validate.IsEnabled = true;
                    Validate.Tag = orderId;
                    Delete.IsEnabled = true;
                    Delete.Tag = orderId;
                }
                else if (status == "validate")
                {
                    Test.IsEnabled = true;
                    Test.Tag = orderId;
                }
                else if (status == "completed")
                {
                    Print.IsEnabled = true;
                    Print.Tag = orderId;
                }
                else if (status.Length > 11)
                {
                    if (status.Substring(0, 11) == "uncompleted")
                    {
                        Test.IsEnabled = true;
                        Test.Tag = orderId;
                    }
                    else if (status == "awaiting for removal")
                    {
                        Close.IsEnabled = true;
                        Close.Tag = orderId;
                    }
                }
                else if (status == "not ready")
                {
                    Partial.IsEnabled = true;
                    Partial.Tag = orderId;
                    Test.IsEnabled = true;
                    Test.Tag = orderId;
                }
            }
        }

        private async void OnElementClicked(object sender, RoutedEventArgs e)
        {
            string action = (sender as AppBarButton).Name.ToString();
            string orderId = (sender as AppBarButton).Tag.ToString();
            string z = "";
            if (action == "Validate")
            {
                Sandbox.SandBox(orderId);
                List<string> codeList = DbUtils.RefList("Code", "listsitems where OrderId = \"" + orderId + "\"");
                foreach (string i in codeList)
                {

                    z = DbUtils.UpdateDb("listsitems", "Disponibility",
                        "OrderId = \"" + orderId + "\" and Code = \"" + i + "\"", "never tested");
                }

                z = DbUtils.UpdateDb("orders", "Status", "OrderId = \"" + orderId + "\"", "validate");
            }
            else if (action == "Print")
            {
                // Create a new PrintHelperOptions instance
                var defaultPrintHelperOptions = new PrintHelperOptions();

                // Configure options that you want to be displayed on the print dialog
                defaultPrintHelperOptions.AddDisplayOption(StandardPrintTaskOptions.Orientation);
                defaultPrintHelperOptions.Orientation = PrintOrientation.Portrait;

                // Create a new PrintHelper instance
                // "container" is a XAML panel that will be used to host printable control. 
                // It needs to be in your visual tree but can be hidden with Opacity = 0

                // Add controls that you want to print
                FillDataGrid2(DbUtils.RefreshDb("listsitems where OrderId = \"" + orderId + "\""), printData);
                var printHelper = new PrintHelper(container, defaultPrintHelperOptions);
                await printHelper.ShowPrintUIAsync("Order");
            }
            else if (action == "Test")
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
                            z = DbUtils.UpdateDb("listsitems", "Disponibility",
                                "OrderId = \"" + orderId + "\" and Code = \"" + i + "\"", "true");
                        }
                        else
                        {
                            z= DbUtils.UpdateDb("listsitems", "Disponibility",
                                "OrderId = \"" + orderId + "\" and Code = \"" + i + "\"", "false");
                        }

                        all += 1;
                    }
                }

                if (isalltrue == all)
                {
                    z = DbUtils.UpdateDb("orders", "Status", "OrderId = \"" + orderId + "\"",
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
                            z = DbUtils.UpdateDb("kitbox", "Instock", "Code =\"" + i + "\"",
                                stockNow.ToString());
                            z = DbUtils.UpdateDb("listsitems", "Disponibility",
                                "OrderId = \"" + orderId + "\" and Code = \"" + i + "\"", "completed");
                        }
                    }
                }
                else
                {
                    z = DbUtils.UpdateDb("orders", "Status", "OrderId = \"" + orderId + "\"",
                        "not ready");
                }
            }
            else if (action == "Close")
            {
                z = DbUtils.UpdateDb("orders", "Status", "OrderId = \"" + orderId + "\"", "completed");
            }
            else if (action == "Partial")
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
                            z = DbUtils.UpdateDb("kibox", "Instock", "Code =\"" + i + "\"",
                                stockNow.ToString());
                            z = DbUtils.UpdateDb("listsitems", "Disponibility",
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
                                z = DbUtils.UpdateDb("listsitems", "Disponibility",
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
                int procentint = (int)procent;
                z = DbUtils.UpdateDb("orders", "Status", "OrderId = \"" + orderId + "\"",
                    "uncompleted, " + procentint + "%");
            }
            else if (action == "Delete")
            {
                z = DbUtils.DeleteRow("orders", "OrderId = \"" + orderId + "\"");
            }
            
            FillDataGrid2(DbUtils.RefreshDb("listsitems where OrderId = \"" + orderId + "\""), DataGrid2);
            FillDataGrid1(SetColumnsOrder(DbUtils.RefreshDb("orders natural join customers")), DataGrid1);
            Validate.IsEnabled = false;
            Delete.IsEnabled = false;
            Test.IsEnabled = false;
            Partial.IsEnabled = false;
            Close.IsEnabled = false;
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<string> _idList = DbUtils.RefListNd("CustomerId","orders");
                List<string> _nameList = new List<string>();
                foreach (string i in _idList)
                {
                    string name = DbUtils.RefList("CustomerName", "customers where CustomerId = \"" + i + "\"")[0];
                    _nameList.Add(name);
                }
                _listSuggestion = _nameList.Where(x => x.ToLower().StartsWith(sender.Text.ToLower())).ToList();
                sender.ItemsSource = _listSuggestion;
            }
        }
        
        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var selectedItem = args.SelectedItem.ToString();
            sender.Text = selectedItem;
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                AutoSuggestBox1.Text = args.ChosenSuggestion.ToString();
                DataTable dataTable = DbUtils.RefreshDb("listsitems natural join orders natural join customers where CustomerName = \"" + AutoSuggestBox1.Text + "\"");
                dataTable.Columns.Remove("CustomerName");
                dataTable.Columns.Remove("CustomerPhone");
                dataTable.Columns.Remove("CustomerId");
                dataTable.Columns.Remove("Status");
                FillDataGrid2(dataTable, DataGrid2);
                
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string orderId = ComboBox1.SelectedItem.ToString();
            if (orderId != "")
            {
                FillDataGrid2(DbUtils.RefreshDb("listsitems where OrderId =\"" + orderId + "\""), DataGrid2);
            }
        }

        public class Order
        {
            public string CustomerName { get; set; }
            public string OrderId { get; set; }
            public string Status { get; set; }

        }
        public class Item
        {
            public string OrderId { get; set; }
            public string Code { get; set; }
            public string Quantity { get; set; }
            public string Disponibility { get; set; }

        }
    }
}
