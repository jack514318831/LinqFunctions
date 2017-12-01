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
    /// Interaktionslogik für Resource.xaml
    /// </summary>
    public partial class Resource : Window
    {
        public Resource()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            #region Solution
            // this.SPanel.Resources["solidbrush"] = new SolidColorBrush(Colors.Blue); 
            #endregion
            this.SPanel.Resources["solidbrush"] = new SolidColorBrush(Colors.Gold);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            #region Solution
            //ResourceDictionary rd = new ResourceDictionary();
            //rd.Source = new Uri("LibreryName: component/aaa.xaml", UriKind.Relative);
            //this.btn1.Background = (Brush)rd["BrushName"]; 
            #endregion
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("LibreryName: component/windows.xaml", UriKind.Relative);
            this.btn1.Background = (Brush)rd["BrushName"];
        }

        private void mouseenter(object sender,  MouseEventArgs e)
        {
            if(sender is TextBlock)
            ((TextBlock)sender).Background = new SolidColorBrush(Colors.LightYellow);
        }

        private void mouseleave(object sender, MouseEventArgs e)
        {
            if(sender is TextBlock)
            ((TextBlock)sender).Background = new SolidColorBrush(Colors.White);
        }
    }
}
