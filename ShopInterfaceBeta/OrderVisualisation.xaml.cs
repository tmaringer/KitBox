using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace ShopInterfaceBeta
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class OrderVisualisation : Page
    {
        private ObservableCollection<string> customers;
        private ObservableCollection<string> orderIdCustomer;
        private ObservableCollection<string> cupboardIds;
        private ObservableCollection<string> boxIds;
        private List<string> heightList;
        private List<string> widthList;
        private List<string> depthList;
        private string boxId;
        private string cupId;
        private List<string> part;
        public OrderVisualisation()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 1);
            cupboardIds = new ObservableCollection<string>();
            customers = new ObservableCollection<string>();
            orderIdCustomer = new ObservableCollection<string>();
            boxIds = new ObservableCollection<string>();
            part = new List<string>();
            ComboBox3.Items.Clear();
            ComboBox3.Items.Add("Width");
            ComboBox3.Items.Add("Depth");
            ComboBox7.Items.Clear();
            ComboDoor.Items.Clear();
            ComboDoor.Items.Add("0");
            ComboDoor.Items.Add("1");
            ComboDoor.Items.Add("2");
            heightList = new List<string>();
            widthList = new List<string>();
            depthList = new List<string>();
            foreach (string i in DbUtils.RefListNd("Height", "kitbox where Ref = \"Cleat\""))
            {
                int height = Convert.ToInt32(i) + 4;
                ComboBox7.Items.Add(height.ToString());
                heightList.Add(height.ToString());
            }
            foreach (string i in DbUtils.RefListNd("Width", "kitbox where Ref = \"Panel B\""))
            {
                widthList.Add(i);
            }
            foreach (string i in DbUtils.RefListNd("Depth", "kitbox where Ref = \"Panel LR\""))
            {
                depthList.Add(i);
            }
            FillComboBox(DbUtils.RefListNd("CustomerName", "customers natural join orders"), customers);
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }

        public static void FillDataGridCup(DataTable table, DataGrid grid)
        {
            List<Cupboard> cupboards = new List<Cupboard>();
            foreach (DataRow row in table.Rows)
            {
                cupboards.Add(new Cupboard()
                {
                    CupboardId = row["CupboardId"].ToString(),
                    OrderId = row["OrderId"].ToString(),
                    Height = row["Height"].ToString(),
                    Width = row["Width"].ToString(),
                    Depth = row["Depth"].ToString()
                });
            }
            grid.AutoGenerateColumns = false;
            grid.ItemsSource = cupboards;
        }

        public static void FillDataGridBox(DataTable table, DataGrid grid)
        {
            List<Box> boxes = new List<Box>();
            foreach (DataRow row in table.Rows)
            {
                boxes.Add(new Box()
                {
                    CupboardId = row["CupboardId"].ToString(),
                    Height = row["Height"].ToString(),
                    BoxId = row["BoxId"].ToString()
                });
            }
            grid.AutoGenerateColumns = false;
            grid.ItemsSource = boxes;
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

        private void ComboBox0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox0.SelectedItem.ToString() != "")
            {
                FillComboBox(DbUtils.RefList("OrderId", "customers natural join orders where CustomerName = \"" + ComboBox0.SelectedItem + "\""), orderIdCustomer);
            }

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.SelectedItem.ToString() != "")
            {
                FillDataGridCup(DbUtils.RefreshDb("cupboards where OrderId = \"" + ComboBox1.SelectedItem.ToString() + "\""), DataGrid1);
                FillComboBox(DbUtils.RefList("CupboardId", "cupboards where OrderId = \"" + ComboBox1.SelectedItem.ToString() + "\""), cupboardIds);
                FlyoutInitialise.Hide();
            }
        }

        private void DataGrid1_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Door.IsEnabled = false;
            Edit1.IsEnabled = false;
            ModifyPart.IsEnabled = false;
            Modify.IsEnabled = false;
            Infos.IsEnabled = false;
            string columnValue = DataGrid1.CurrentColumn.Header.ToString();
            if (columnValue == "CupboardId")
            {
                Modify.IsEnabled = true;
                cupId = ((Cupboard)((sender as DataGrid).SelectedItem)).CupboardId;
                FillDataGridBox(DbUtils.RefreshDb("boxes where CupboardId = \"" + cupId + "\""), DataGrid2);
                Sandbox.Angles(cupId, DataGrid3);
                DataGrid3.Columns[3].CellStyle = (Style)DataGrid3.Resources["Test"];
                FillComboBox(DbUtils.RefList("BoxId", "boxes where CupboardId = \"" + cupId + "\""), boxIds);
            }
        }

        private void DataGrid2_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Door.IsEnabled = false;
            Edit1.IsEnabled = false;
            ModifyPart.IsEnabled = false;
            Modify.IsEnabled = false;
            Infos.IsEnabled = false;
            string columnValue = DataGrid2.CurrentColumn.Header.ToString();
            if (columnValue == "BoxId")
            {
                boxId = ((Box)((sender as DataGrid).SelectedItem)).BoxId;
                string cupboardId = DbUtils.RefList("CupboardId", "boxes where BoxId = \"" + boxId + "\"")[0];
                if (Convert.ToInt32(DbUtils.RefList("Width", "cupboards where CupboardId = \"" + cupboardId + "\"")[0]) > 60)
                {
                    Door.IsEnabled = true;
                }

                Edit1.IsEnabled = true;
                Sandbox.ElementList(boxId, DataGrid3);
                DataGrid3.Columns[3].CellStyle = (Style)DataGrid3.Resources["Test"];
            }
        }

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox4.Items.Clear();
            if (ComboBox3.SelectedItem.ToString() == "Width")
            {
                foreach (string i in DbUtils.RefListNd("Width", "kitbox where Ref = \"Panel B\""))
                {
                    ComboBox4.Items.Add(i);
                }
            }
            else if (ComboBox3.SelectedItem.ToString() == "Depth")
            {
                foreach (string i in DbUtils.RefListNd("Depth", "kitbox where Ref = \"Panel LR\""))
                {
                    ComboBox4.Items.Add(i);
                }
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string cupboardId = cupId;
            string orientation = ComboBox3.SelectedItem.ToString();
            string value = ComboBox4.SelectedItem.ToString();
            if (orientation == "Width")
            {
                Sandbox.Width(cupboardId, Convert.ToInt32(value));
            }
            else if (orientation == "Depth")
            {
                Sandbox.Depth(cupboardId, Convert.ToInt32(value));
            }
            string OrderId = DbUtils.RefList("OrderId", "cupboards where CupboardId = \"" + cupboardId + "\"")[0];
            FillDataGridCup(DbUtils.RefreshDb("cupboards where OrderId = \"" + OrderId + "\""), DataGrid1);
            Modify.IsEnabled = false;
            FlyoutModify.Hide();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            string CupboardId = cupId;
            string BoxId = boxId;
            Sandbox.Height(BoxId, Convert.ToInt32(ComboBox7.SelectedItem.ToString()));
            Sandbox.Angles(CupboardId, DataGrid3);
            string OrderId = DbUtils.RefList("OrderId", "cupboards where CupboardId = \"" + CupboardId + "\"")[0];
            FillDataGridCup(DbUtils.RefreshDb("cupboards where OrderId = \"" + OrderId + "\""), DataGrid1);
            DataGrid3.Columns[3].CellStyle = (Style)DataGrid3.Resources["Test"];
            FillDataGridBox(DbUtils.RefreshDb("boxes where CupboardId = \"" + CupboardId + "\""), DataGrid2);
            Edit1.IsEnabled = false;
            FlyoutEdit1.Hide();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            string w = "";
            DataTable doors = Sandbox.Doors(boxId);
            string numberDoor = ComboDoor.SelectedItem.ToString();
            while (doors.Rows.Count - Convert.ToInt32(numberDoor) != 0)
            {
                if (doors.Rows.Count < Convert.ToInt32(numberDoor))
                {
                    string height = DbUtils.RefList("Height",
                        "boxes where BoxId = \"" + boxId + "\"")[0];
                    string width = DbUtils.RefList("Width",
                        "cupboards where CupboardId = \"" + cupId + "\"")[0];
                    string code = "DOO" + (Convert.ToInt32(height) - 4) + (Convert.ToInt32(width) / 10 * 5 + 2) +
                                  "WH";
                    w = DbUtils.InsertDb("doors", "BoxId,Code",
                        "\"" + boxId + "\", \"" + code + "\"");
                    doors = Sandbox.Doors(boxId);
                }
                else if (doors.Rows.Count > Convert.ToInt32(numberDoor))
                {
                    List<string> id = DbUtils.RefList("DoorId",
                        "doors where BoxId = \"" + boxId + "\"");
                    w = DbUtils.DeleteRow("doors", "DoorId = \"" + id[id.Count - 1] + "\"");
                    doors = Sandbox.Doors(boxId);
                }
            }
            DbUtils.Arrange("doors", "DoorId");
            Sandbox.ElementList(boxId, DataGrid3);
            DataGrid3.Columns[3].CellStyle = (Style)DataGrid3.Resources["Test"];
            DoorManagement.Hide();
        }

        private void DataGrid3_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (part != null)
            {
                part.Clear();
            }
            Edit1.IsEnabled = false;
            ModifyPart.IsEnabled = false;
            Modify.IsEnabled = false;
            Infos.IsEnabled = false;
            if (DataGrid3.CurrentColumn.Header.ToString() == "Code")
            {
                object[] row = (object[])DataGrid3.SelectedItem;
                string code = row[1].ToString();
                string reference = DbUtils.RefList("Ref", "kitbox where Code = \"" + code + "\"")[0];
                string colour = DbUtils.RefList("Colour", "kitbox where Code = \"" + code + "\"")[0];
                string infos = DbUtils.RefList("Dimensions", "kitbox where Code = \"" + code + "\"")[0];
                InfosCode.Text = code;
                InfosColour.Text = colour;
                InfosRef.Text = reference;
                InfosInfos.Text = infos;
                if (reference == @"AngleBracket")
                {
                    if (colour == @"White")
                    {
                        InfosImage.Source = new BitmapImage(new Uri("Assets/Pictures/Corniere_blanc.png"));
                    }
                    else if (colour == @"Brown")
                    {
                        InfosImage.Source = new BitmapImage(new Uri("Assets/Pictures/Corniere_brown.png"));
                    }
                    else if (colour == @"Galvanised")
                    {
                        InfosImage.Source = new BitmapImage(new Uri("Assets/Pictures/Corniere_galv.png"));
                    }
                    else if (colour == @"Black")
                    {
                        InfosImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Pictures/Corniere_black.png"));
                    }
                }
                else if (reference == @"Panel LR" || reference == @"Panel HL" || reference == @"Panel B")
                {
                    if (colour == @"White")
                    {
                        InfosImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Pictures/panel_white.png"));
                    }
                    else if (colour == @"Brown")
                    {
                        InfosImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Pictures/panel_brown.png"));
                    }
                }
                else if (reference == @"Crossbar LR" || reference == @"Crossbar B")
                {
                    InfosImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Pictures/traverse.png"));
                }
                else if (reference == @"Crossbar F")
                {
                    InfosImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Pictures/traverse_av.png"));
                }
                else if (reference == @"Cleat")
                {
                    InfosImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Pictures/Tasseau.png"));
                }
                else if (reference == @"Cup")
                {
                    InfosImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Pictures/coupelle.png"));
                }
                else if (reference == @"Door")
                {
                    if (colour == @"White")
                    {
                        InfosImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Pictures/porte_blanc.png"));
                    }
                    else if (colour == @"Brown")
                    {
                        InfosImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Pictures/porte_brown.png"));
                    }
                    else if (colour == @"Glass")
                    {
                        InfosImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/Pictures/porte_verre.png"));
                    }
                }
                Infos.IsEnabled = true;

            }
            if (DataGrid3.CurrentColumn.Header.ToString() == "Id")
            {
                object[] row = (object[])DataGrid3.SelectedItem;
                string code = row[1].ToString();
                part.Add(code);
                part.Add(row[2].ToString());
                part.Add(boxId);
                part.Add(cupId);
                string reference = DbUtils.RefList("Ref", "kitbox where Code = \"" + code + "\"")[0];
                part.Add(reference);
                List<string> colors = DbUtils.RefListNd("Colour", "kitbox where Ref = \"" + reference + "\"");
                if (colors.Count > 1)
                {
                    ModifyPart.IsEnabled = true;
                }
                ComboCol.Items.Clear();
                foreach (string i in colors)
                {
                    ComboCol.Items.Add(i);
                }
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            string code = part[0];
            string pos = part[1];
            string boxId = part[2];
            string cupId = part[3];
            string reff = part[4];
            string height = DbUtils.RefList("Height", "kitbox where Code = \"" + code + "\"")[0];
            string width = DbUtils.RefList("Width", "kitbox where Code = \"" + code + "\"")[0];
            string depth = DbUtils.RefList("Depth", "kitbox where Code = \"" + code + "\"")[0];
            string colour = ComboCol.SelectedItem.ToString();
            string w = "";
            string new_code = DbUtils.RefList("Code", "kitbox where Ref = \"" + reff + "\" and Height = \"" + height + "\" and Width = \"" + width + "\" and Depth = \"" + depth + "\" and Colour = \"" + colour + "\"")[0];
            if (reff == "Panel B" || reff == "Panel LR" || reff == "Panel HL")
            {
                //panel
                List<string> Id = DbUtils.RefList("PanelId", "panels where Position = \"" + pos + "\" and Code = \"" + code + "\" and BoxId = \"" + boxId + "\"");
                w = DbUtils.UpdateDb("panels", "Code", "PanelId = \"" + Id[0] + "\"", new_code);
                Sandbox.ElementList(boxId, DataGrid3);
            }
            else if (reff == "Door")
            {
                List<string> Id = DbUtils.RefList("DoorId", "doors where Code = \"" + code + "\" and BoxId = \"" + boxId + "\"");
                w = DbUtils.UpdateDb("doors", "Code", "DoorId = \"" + Id[0] + "\"", new_code);
                Sandbox.ElementList(boxId, DataGrid3);
            }
            else if (reff == "AngleBracket")
            {
                List<string> Id = DbUtils.RefList("AngleId", "angles where Code = \"" + code + "\" and CupboardId = \"" + cupId + "\"");
                w = DbUtils.UpdateDb("angles", "Code", "AngleId = \"" + Id[0] + "\"", new_code);
                Sandbox.Angles(cupId, DataGrid3);
            }
            DataGrid3.Columns[3].CellStyle = (Style)DataGrid3.Resources["Test"];
            ModifyPart.IsEnabled = false;
            ModifyPartFlyout.Hide();
        }

        private void Edit1_Click(object sender, RoutedEventArgs e)
        {

        }

        public class Cupboard
        {
            public string CupboardId { get; set; }
            public string OrderId { get; set; }
            public string Height { get; set; }
            public string Width { get; set; }
            public string Depth { get; set; }
        }

        public class Box
        {
            public string BoxId { get; set; }
            public string CupboardId { get; set; }
            public string Height { get; set; }
        }
        public class Item
        {

        }

        private async void DataGrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string CupboardId = ((Cupboard)((sender as DataGrid).SelectedItem)).CupboardId;
            string original = "";
            string value = "";
            string setting = "";
            if ((sender as DataGrid).CurrentColumn.Header.ToString() == "Width")
            {
                original = DbUtils.RefList("Width", "cupboards where CupboardId = \"" + CupboardId + "\"")[0];
                value = ((Cupboard)((sender as DataGrid).SelectedItem)).Width;
                setting = "Width";
            }
            else if ((sender as DataGrid).CurrentColumn.Header.ToString() == "Depth")
            {
                original = DbUtils.RefList("Depth", "cupboards where CupboardId = \"" + CupboardId + "\"")[0];
                value = ((Cupboard)((sender as DataGrid).SelectedItem)).Depth;
                setting = "Depth";
            }
            ContentDialog ModifyCupboard = new ContentDialog()
            {
                Title = "Cupboard modification",
                Content = "Do you want to change the " + setting.ToLower() + " of cupboard n°" + CupboardId + " from \"" + original + "\" to \"" + value + "\" ?",
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "I'm not sure",
                DefaultButton = ContentDialogButton.Secondary
            };
            ContentDialogResult result = await ModifyCupboard.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                string i = "";
                i = DbUtils.UpdateDb("cupboards", setting, "CupboardId = \"" + CupboardId + "\"", value);
                if (setting == "Width")
                {
                    Sandbox.Width(CupboardId, Convert.ToInt32(value));
                }
                else if (setting == "Depth")
                {
                    Sandbox.Depth(CupboardId, Convert.ToInt32(value));
                }
            }
            FillDataGridCup(DbUtils.RefreshDb("cupboards where OrderId = \"" + DbUtils.RefList("OrderId", "cupboards where CupboardId = \"" + CupboardId + "\"")[0] + "\""), DataGrid1);
        }
    }
}