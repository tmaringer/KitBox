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
    public sealed partial class DatabaseManagement : Page
    {
        private ObservableCollection<string> code;
        private ObservableCollection<string> columns;
        public DatabaseManagement()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);
            columns = new ObservableCollection<string>();
            code = new ObservableCollection<string>();
            FillComboBox(DbUtils.RefList("Code", "kitbox"), code);
            FillDataGrid(DbUtils.RefreshDb("kitbox"), DataGridView1, columns);
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
        public static void FillDataGrid(DataTable table, DataGrid grid, ObservableCollection<string> column)
        {
            grid.Columns.Clear();
            column.Clear();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                column.Add(table.Columns[i].ColumnName);
                grid.Columns.Add(new DataGridTextColumn()
                {
                    Header = table.Columns[i].ColumnName,
                    Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
                });
            }

            var collection = new ObservableCollection<object>();
            foreach (DataRow row in table.Rows)
            {
                collection.Add(row.ItemArray);
            }
            grid.AutoGenerateColumns = false;
            grid.ItemsSource = collection;
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

        private void StackPanelDatabaseManagement1Button1_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);
            string code = ComboBox1.SelectedItem.ToString();
            string value = TextBox1.Text.ToString();
            string column = ComboBox2.SelectedItem.ToString();
            TextBlock1.Text = DbUtils.UpdateDb("kitbox", column, "Code = \"" + code + "\"", value);
            FillDataGrid(DbUtils.RefreshDb("kitbox"), DataGridView1, columns);
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
    }
}
