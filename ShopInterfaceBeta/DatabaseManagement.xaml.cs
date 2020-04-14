using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
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
    public sealed partial class DatabaseManagement : Page
    {
        private ObservableCollection<string> code;
        private ObservableCollection<string> columns;
        private static ObservableCollection<Item> _items;
        private static CollectionViewSource groupedItems;
        private string OriginalCode;
        private string OriginalValue;
        private SolidColorBrush fore;
        private List<string> _nameList;
        private string ActualCode;
        public DatabaseManagement()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);
            columns = new ObservableCollection<string>();
            code = new ObservableCollection<string>();
            FillComboBox(DbUtils.RefList("Code", "kitbox"), code);
            DataTable data = DbUtils.RefreshDb("kitbox");
            FillDataGrid(data, DataGridView1);
        }

        public void FillDataGrid(DataTable dataTable, DataGrid dataGrid)
        {
            _nameList = new List<string>();
            _items = new ObservableCollection<Item>();
            List<Item> parts = new List<Item>();
            foreach (DataRow row in dataTable.Rows)
            {
                Item part = new Item()
                {
                    Ref = row["Ref"].ToString(),
                    Code = row["Code"].ToString(),
                    Height = row["Height"].ToString(),
                    Width = row["Width"].ToString(),
                    Depth = row["Depth"].ToString(),
                    Colour = row["Colour"].ToString(),
                    Instock = row["Instock"].ToString(),
                    MinimumStock = row["MinimumStock"].ToString(),
                    CustPrice = row["CustPrice"].ToString(),
                    NbPartsBox = Convert.ToInt32(row["NbPartsBox"].ToString())
                };
                parts.Add(part);
                _items.Add(part);
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (_nameList.Contains(row[column].ToString()) == false && column.ColumnName != "Dimensions")
                    {
                        _nameList.Add(row[column].ToString());
                    }
                }
            }
            dataGrid.ItemsSource = parts;
            dataGrid.AutoGenerateColumns = false;
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        private static void FillComboBox(List<string> list, ObservableCollection<string> code)
        {
            code.Clear();
            foreach (string i in list)
            {
                char[] charArr = i.ToCharArray();
                code.Add(new string(charArr));
            }
        }

        public class GroupInfoCollection<T> : ObservableCollection<T>
        {
            public object Key { get; set; }

            public new IEnumerator<T> GetEnumerator()
            {
                return (IEnumerator<T>)base.GetEnumerator();
            }
        }

        public class Item
        {
            public string Code { get; set; }
            public string Instock { get; set; }
            public string MinimumStock { get; set; }

            public string CustPrice { get; set; }
            public int NbPartsBox { get; set; }

            public string Width { get; set; }

            public string Height { get; set; }

            public string Depth { get; set; }

            public string Ref { get; set; }

            public string Colour { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create grouping for collection
            ObservableCollection<GroupInfoCollection<Item>> parts = new ObservableCollection<GroupInfoCollection<Item>>();

            //Implement grouping through LINQ queries
            var query = from item in _items
                        group item by item.Ref into g
                        select new { GroupName = g.Key, Items = g };

            //Populate Mountains grouped collection with results of the query
            foreach (var g in query)
            {
                GroupInfoCollection<Item> info = new GroupInfoCollection<Item>();
                info.Key = g.GroupName;
                foreach (var item in g.Items)
                {
                    info.Add(item);
                }
                parts.Add(info);
            }
            groupedItems = new CollectionViewSource();
            groupedItems.IsSourceGrouped = true;
            groupedItems.Source = parts;
            DataGridView1.RowGroupHeaderPropertyNameAlternative = "Ref";
            DataGridView1.ItemsSource = groupedItems.View;
            Sort.IsEnabled = false;
        }

        private void DataGridView1_LoadingRowGroup(object sender, DataGridRowGroupHeaderEventArgs e)
        {

            ICollectionViewGroup group = e.RowGroupHeader.CollectionViewGroup;
            Item item = group.GroupItems[0] as Item;
            e.RowGroupHeader.PropertyValue = item.Ref;
        }

        private void dg_Editing(object sender, DataGridBeginningEditEventArgs e)
        {
            try
            {
                string column = (sender as DataGrid).CurrentColumn.Header.ToString();
                OriginalCode = ((Item)((sender as DataGrid).SelectedItem)).Code.ToString();
                int index = (sender as DataGrid).Columns.IndexOf((sender as DataGrid).CurrentColumn);
                OriginalValue = DbUtils.RefList(column, "kitbox where Code = \"" + OriginalCode + "\"")[0];
            }
            catch
            {

            }
        }

        private async void dg_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                if (e.EditAction == DataGridEditAction.Commit)
                {
                    string value = (e.EditingElement as TextBox).Text.ToString();
                    string column = (sender as DataGrid).CurrentColumn.Header.ToString();
                    ContentDialog ConfirmEdit = new ContentDialog()
                    {
                        Title = "Update a part",
                        Content = "Do you really want to modify \"" + OriginalValue + "\" to \"" + value + "\" ?",
                        PrimaryButtonText = "Yes",
                        SecondaryButtonText = "I'm not sure",
                        DefaultButton = ContentDialogButton.Secondary
                    };

                    ContentDialogResult result = await ConfirmEdit.ShowAsync();
                    if (result == ContentDialogResult.Primary)
                    {
                        string i = "";
                        i = DbUtils.UpdateDb("kitbox", column, "Code = \"" + OriginalCode + "\"", value);
                    }
                }
            }
            catch
            {

            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridView1.IsReadOnly == false)
            {
                DataGridView1.IsReadOnly = true;
                Edit.Foreground = fore;
                Edit.Label = "Enable edit mode";
            }
            else
            {
                DataGridView1.IsReadOnly = false;
                fore = (SolidColorBrush)Edit.Foreground;
                Edit.Foreground = new SolidColorBrush(Colors.Red);
                Edit.Label = "Disable edit mode";
            }
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            string i = DbUtils.InsertDb("kitbox", "Ref,Code,Height,Width,Depth,Colour,Instock,MinimumStock,Custprice,NbPartsBox", "\"DEFAULT\",\"NEW\",\"0\",\"0\",\"0\",\"DEFAULT\",\"0\",\"0\",\"0\",\"0\"");
            FillDataGrid(DbUtils.RefreshDb("kitbox"), DataGridView1);
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<string> _listSuggestion = _nameList.Where(x => x.ToLower().StartsWith(sender.Text.ToLower())).ToList();
                sender.ItemsSource = _listSuggestion;
            }
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                AutoSuggestBox.Text = args.ChosenSuggestion.ToString();
                string value = AutoSuggestBox.Text.ToString();
                List<Item> parts = new List<Item>();
                DataTable result = new DataTable();
                result = DbUtils.RefreshDb("kitbox");
                result.Columns.Remove("Dimensions");
                result.Rows.Clear();
                foreach (DataRow dataRow in DbUtils.RefreshDb("kitbox").Rows)
                {
                    List<string> row = dataRow.ItemArray.Select(i => i.ToString()).ToList();
                    if (row.Contains(value))
                    {
                        result.Rows.Add(row);
                        parts.Add(new Item()
                        {
                            Ref = dataRow["Ref"].ToString(),
                            Code = dataRow["Code"].ToString(),
                            Height = dataRow["Height"].ToString(),
                            Width = dataRow["Width"].ToString(),
                            Depth = dataRow["Depth"].ToString(),
                            Colour = dataRow["Colour"].ToString(),
                            Instock = dataRow["Instock"].ToString(),
                            MinimumStock = dataRow["MinimumStock"].ToString(),
                            CustPrice = dataRow["CustPrice"].ToString(),
                            NbPartsBox = Convert.ToInt32(dataRow["NbPartsBox"].ToString())
                        });
                    }
                    DataGridView1.ItemsSource = parts;
                    DataGridView1.AutoGenerateColumns = false;
                }
            }
            else
            {
                FillDataGrid(DbUtils.RefreshDb("kitbox"), DataGridView1);
            }
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var selectedItem = args.SelectedItem.ToString();
            sender.Text = selectedItem;
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            FillDataGrid(DbUtils.RefreshDb("kitbox"), DataGridView1);
            Sort.IsEnabled = true;
        }

        private void DataGridView1_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if ((sender as DataGrid).CurrentColumn.Header.ToString() == "Code")
            {
                ActualCode = ((Item)((sender as DataGrid).SelectedItem)).Code;
                Delete.IsEnabled = true;
            }
            else
            {
                Delete.IsEnabled = false;
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog ConfirmEdit = new ContentDialog()
            {
                Title = "Delete an item",
                Content = "Do you really want to delete \"" + ActualCode + "\" from the database ?",
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "I'm not sure",
                DefaultButton = ContentDialogButton.Secondary
            };
            ContentDialogResult result = await ConfirmEdit.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                string i = DbUtils.DeleteRow("kitbox", "Code = \"" + ActualCode + "\"");
            }
            FillDataGrid(DbUtils.RefreshDb("kitbox"), DataGridView1);
            Delete.IsEnabled = false;
        }
    }
}
