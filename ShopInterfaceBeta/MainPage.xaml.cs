using GalaSoft.MvvmLight.Views;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; // Notifications library
using Microsoft.QueryStringDotNET; // QueryString.NET
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using MySql.Data.MySqlClient;
using MySql.Data;
using Windows.ApplicationModel.Core;
using ShopInterface;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ShopInterfaceBeta
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void DisplayNoConnectionDialog()
        {
            ContentDialog noConnectionDialog = new ContentDialog
            {
                Title = "Database connection failed",
                Content = "Please contact your administrator.",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await noConnectionDialog.ShowAsync();
            CoreApplication.Exit();
        }

        private static async void LoginDialog()
        {
            StackPanel stackPanel = new StackPanel();
            TextBox textBox1 = new TextBox
            {
                Header = "Login"
            };
            PasswordBox textBox2 = new PasswordBox
            {
                Header = "Password"
            };
            stackPanel.Children.Add(textBox1);
            stackPanel.Children.Add(textBox2);
            ContentDialog LoginDialog = new ContentDialog
            {
                Title = "Please log in",
                Content = stackPanel,
                PrimaryButtonText = "Log in",
                SecondaryButtonText = "Close",
                DefaultButton = ContentDialogButton.Primary
            };
            await CheckAsync(LoginDialog);
        }
        public static async System.Threading.Tasks.Task CheckAsync(ContentDialog LoginDialog)
        {
            var result = await LoginDialog.ShowAsync();
            if (result.ToString() == "Secondary")
            {
                CoreApplication.Exit();
            }
            else if (result.ToString() == "Primary")
            {
                StackPanel stack = (StackPanel)LoginDialog.Content;
                TextBox textBox = (TextBox)stack.Children[0];
                PasswordBox passwordBox = (PasswordBox)stack.Children[1];
                string password = passwordBox.Password;
                string login = textBox.Text;
                int response = DbUtils.CheckAccess(login, password);
                if (response == 1)
                {
                    MainPage.LoginDialog();
                }
                else
                {
                }
            }
        }
        public void CheckConnection()
        {
            MySqlConnection conn = new MySqlConnection(DbUtils.MyConString);
            try
            {
                conn.Open();
                conn.Close();
                IconConnectivity.Glyph = "\uE701";
                ConText.Text = "Database connected";
                LoginDialog();
                NotificationToast.SimpleNotification("Database connected");
            }
            catch
            {
                IconConnectivity.Glyph = "\uEB5E";
                ConText.Text = "Database not connected";
                DisplayNoConnectionDialog();
                string title = "Database connection failed";
                NotificationToast.SimpleNotification(title);
            }
        }
        private void NavigationTouched(object sender, TappedRoutedEventArgs e)
        {
            NavigationViewItem ItemSelected = NavigationBar.SelectedItem as NavigationViewItem;
            if (ItemSelected != null)
            {
                Header.Text = ItemSelected.Tag.ToString();
                switch (ItemSelected.Tag)
                {
                    case @"Welcome page":
                        break;
                    case @"Order visualisation":
                        ContentFrame.Navigate(typeof(OrderVisualisation));
                        break;
                    case @"Orders management":
                        ContentFrame.Navigate(typeof(OrdersManagement));
                        break;
                    case @"Database management":
                        ContentFrame.Navigate(typeof(DatabaseManagement));
                        break;
                    case @"Stock management":
                        ContentFrame.Navigate(typeof(StockManagement));
                        break;
                    case @"Suppliers orders":
                        ContentFrame.Navigate(typeof(SuppliersOrders));
                        break;
                    case @"Suppliers update":
                        ContentFrame.Navigate(typeof(SuppliersUpdate));
                        break;


                }
                NavigationBar.SelectedItem = null;
            }
        }
        private void NavigationBar_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationBar.IsPaneOpen = false;
            CheckConnection();
        }
    }
}
