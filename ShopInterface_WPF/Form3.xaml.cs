using System.Windows.Forms;
using projectCS;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Drawing;
using System.IO;

namespace ShopInterface2Beta
{
    public partial class Form3 : Window
    {
        public Form3()
        {
            InitializeComponent();
            GetPicture("CLE47");
            picture1.Stretch = Stretch.Fill;
        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
        private void GetPicture(string value)
        {
            label1.Content = value;
            label5.Content = DbUtils.RefList("Ref", "kitbox where Code = \"" + value + "\"")[0];
            label6.Content = DbUtils.RefList("Dimensions", "kitbox where Code = \"" + value + "\"")[0];
            label7.Content = DbUtils.RefList("Colour", "kitbox where Code = \"" + value + "\"")[0];
            if (label5.Content.ToString() == @"AngleBracket")
            {
                if (label7.Content.ToString() == @"White")
                {
                    picture1.Source = (ImageSource)FindResource("Corniere_blanc");
                }
                else if (label7.Content.ToString() == @"Brown")
                {
                    picture1.Source = (ImageSource)FindResource("Corniere_brown");
                }
                else if (label7.Content.ToString() == @"Galvanised")
                {
                    picture1.Source = (ImageSource)FindResource("Corniere_galv");
                }
                else if (label7.Content.ToString() == @"Black")
                {
                    picture1.Source = (ImageSource)FindResource("Corniere_black");
                }
            }
            else if (label5.Content.ToString() == @"Panel LR" || label5.Content.ToString() == @"Panel HL" || label5.Content.ToString() == @"Panel B")
            {
                if (label7.Content.ToString() == @"White")
                {
                    picture1.Source = (ImageSource)FindResource("panel_white");
                }
                else if (label7.Content.ToString() == @"Brown")
                {
                    picture1.Source = (ImageSource)FindResource("Resources.panel_brown");
                }
            }
            else if (label5.Content.ToString() == @"Crossbar LR" || label5.Content.ToString() == @"Crossbar B")
            {
                picture1.Source = (ImageSource)FindResource("Resources.traverse");
            }
            else if (label5.Content.ToString() == @"Crossbar F")
            {
                picture1.Source = (ImageSource)FindResource("traverse_av");
            }
            else if (label5.Content.ToString() == @"Cleat")
            {
                picture1.Source = BitmapToImageSource(Properties.Resources.Tasseau);
            }
            else if (label5.Content.ToString() == @"Cup")
            {
                picture1.Source = (ImageSource)FindResource("coupelle");
            }
            else if (label5.Content.ToString() == @"Door")
            {
                if (label7.Content.ToString() == @"White")
                {
                    picture1.Source = (ImageSource)FindResource("porte_blanc");
                }
                else if (label7.Content.ToString() == @"Brown")
                {
                    picture1.Source = (ImageSource)FindResource("porte_brown");
                }
                else if (label7.Content.ToString() == @"Glass")
                {
                    picture1.Source = (ImageSource)FindResource("porte_verre");
                }
            }
        }
    }
}
