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
    /// Interaktionslogik für MouseOverWindow.xaml
    /// </summary>
    public partial class MouseOverWindow : Window
    {
        public MouseOverWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition(this);
            tb_output.Text = string.Format("X:{0}  Y:{1}",pt.X, pt.Y);
        }

        //Mouse Capture
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Mouse.Capture(rect);
            btn.Content = "Mouse Captured";
        }

        private void lb_quelle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label lb = (Label)sender;
            DragDrop.DoDragDrop(lb, lb.Content, DragDropEffects.Copy);
        }

        private void lb_target_Drop(object sender, DragEventArgs e)
        {
            lb_target.Content = e.Data.GetData(DataFormats.Text);
        }

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            btn.Background = new SolidColorBrush(Color.FromRgb(123, 53, 82));
        }
    }
}
