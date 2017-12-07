using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LinqFunctions.WPFClass
{
    /// <summary>
    /// Interaktionslogik für Keydown.xaml
    /// </summary>
    public partial class Keydown : Window
    {
        public Keydown()
        {
            InitializeComponent();
        }

        private void tb_input_KeyDown(object sender, KeyEventArgs e)
        {
            #region Solution
            //tb_output.Text = string.Format("Event:{0} Key:{1}", e.RoutedEvent, e.Key); 
            #endregion
            tb_output.Text = string.Format("{0} {1}", e.RoutedEvent, e.Key);
        }

        private void btnGeneration_Click(object sender, RoutedEventArgs e)
        {
            #region Solution
            //WriteableBitmap writeableBitmap = new WriteableBitmap((int)img.Width, (int)img.Height, 96, 96, PixelFormats.Bgra32, null);

            //byte blue = 100;
            //byte green = 50;
            //byte red = 50;
            //byte arpha = 255;
            //Random rand = new Random();
            //byte[] colordata = new byte[4 * 1000 * 1000];
            //int stride = writeableBitmap.PixelWidth * writeableBitmap.Format.BitsPerPixel / 8;

            //for (int x = 0; x < 1000; x++)
            //{
            //    for (int y = 0; y < 1000; y++)
            //    {
            //        int offset = y + y * x;
            //        colordata[offset] = (byte)rand.Next(100, 255);
            //        colordata[offset + 1] = (byte)rand.Next(100, 255);
            //        colordata[offset + 2] = (byte)rand.Next(100, 255);
            //        colordata[offset + 3] = 255;
            //    }
            //}
            //Int32Rect rect = new Int32Rect(10, 10, 100, 100);
            //writeableBitmap.WritePixels(rect, colordata, stride, 0);
            //img.Source = writeableBitmap;
            #endregion
            WriteableBitmap writeableBitmap = new WriteableBitmap((int)img.Width, (int)img.Height, 96, 96, PixelFormats.Bgra32, null);

            byte blue = 100;
            byte green = 50;
            byte red = 50;
            byte arpha = 255;
            Random rand = new Random();
            byte[] colordata = new byte[4*1000*1000];
            int stride = writeableBitmap.PixelWidth * writeableBitmap.Format.BitsPerPixel / 8;

            for (int x =0; x<1000; x++)
            {
                for(int y =0; y<1000; y++)
                {
                    int offset = y + y*x;
                    colordata[offset] = (byte)rand.Next(100,255);
                    colordata[offset + 1] = (byte)rand.Next(100, 255);
                    colordata[offset + 2] = (byte)rand.Next(100, 255);
                    colordata[offset + 3] = 255;
                }
            }
            Int32Rect rect = new Int32Rect(10, 10, 100, 100);
            writeableBitmap.WritePixels(rect, colordata, stride, 0);
            img.Source = writeableBitmap;
        }
    }
}
