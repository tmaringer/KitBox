using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace ShopInterface
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class PrintPage : Page
    {
        static int _pageNumber = 0;
        Grid _printArea;
        private PageNumbering _pageNumbering;

        public PrintPage(FrameworkElement content, FrameworkElement header = null, FrameworkElement footer = null, PageNumbering pageNumbering = PageNumbering.None)
        {
            _printArea = new Grid();
            //// _printArea.Background = new SolidColorBrush(Color.FromArgb(128, 128, 128, 128)); // TEMP, just for testing
            _printArea.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            _printArea.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            _printArea.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            _printArea.Children.Add(new Canvas() { Width = 10000 }); // Horizontally stretches the Grid.

            Content = _printArea;

            PageNumbering = pageNumbering;
            AddContent(content);
            Header = header;
            Footer = footer;
        }

        public static int StartPageNumber
        { set { _pageNumber = value - 1; } }

        public void AddContent(FrameworkElement content)
        {
            Grid.SetRow(content, 1);
            _printArea.Children.Add(content);

            if (PageNumbering != PageNumbering.None)
            {
                _pageNumber += 1;
                var pageNumberText = new TextBlock() { Text = _pageNumber.ToString() };

                switch (PageNumbering)
                {
                    case PageNumbering.None:
                        break;
                    case PageNumbering.TopLeft:
                        Grid.SetRow(pageNumberText, 0);
                        pageNumberText.Margin = new Thickness(0, 0, 0, 20);
                        _printArea.Children.Add(pageNumberText);
                        break;
                    case PageNumbering.TopMiddle:
                        Grid.SetRow(pageNumberText, 0);
                        pageNumberText.Margin = new Thickness(0, 0, 0, 20);
                        pageNumberText.HorizontalAlignment = HorizontalAlignment.Stretch;
                        pageNumberText.HorizontalTextAlignment = TextAlignment.Center;
                        _printArea.Children.Add(pageNumberText);
                        break;
                    case PageNumbering.TopRight:
                        Grid.SetRow(pageNumberText, 0);
                        Grid.SetColumn(pageNumberText, 1);
                        pageNumberText.Margin = new Thickness(0, 0, 0, 20);
                        pageNumberText.HorizontalAlignment = HorizontalAlignment.Stretch;
                        pageNumberText.HorizontalTextAlignment = TextAlignment.Right;
                        _printArea.Children.Add(pageNumberText);

                        break;
                    case PageNumbering.BottomLeft:
                        Grid.SetRow(pageNumberText, 2);
                        pageNumberText.Margin = new Thickness(0, 20, 0, 0);
                        _printArea.Children.Add(pageNumberText);
                        break;
                    case PageNumbering.BottomMidle:
                        Grid.SetRow(pageNumberText, 2);
                        pageNumberText.Margin = new Thickness(0, 20, 0, 0);
                        pageNumberText.HorizontalAlignment = HorizontalAlignment.Stretch;
                        pageNumberText.HorizontalTextAlignment = TextAlignment.Center;
                        _printArea.Children.Add(pageNumberText);
                        break;
                    case PageNumbering.BottomRight:
                        Grid.SetRow(pageNumberText, 2);
                        pageNumberText.Margin = new Thickness(0, 20, 0, 0);
                        _printArea.Children.Add(pageNumberText);
                        break;
                    default:
                        break;
                }
            }
        }

        public FrameworkElement Header
        {
            set
            {
                if (value != null)
                {
                    var header = value;
                    Grid.SetRow(header, 0);
                }
            }
        }

        public FrameworkElement Footer
        {
            set
            {
                if (value != null)
                {
                    var footer = value;
                    Grid.SetRow(footer, 2);
                }
            }
        }

        public PageNumbering PageNumbering
        {
            get { return _pageNumbering; }
            set { _pageNumbering = value; }
        }
    }
}
