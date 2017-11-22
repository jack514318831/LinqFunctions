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
            //Mouse over Show Point
            #region Solution
            //Point pt = e.GetPosition(this);
            //tb_output.Text = string.Format("X:{0}  Y:{1}",pt.X, pt.Y); 
            #endregion
            Point pt = e.GetPosition(this);
            tb_output.Text = string.Format("X:{0}  Y:{1}", pt.X,pt.Y);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //Mouse captured by a element
            #region Solution
            //Mouse.Capture(rect);
            //btn.Content = "Mouse Captured"; 
            #endregion
            Mouse.Capture(rect);
            btn.Content = "Captured";
        }

        private void lb_quelle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            #region Solution
            //    Label lb = (Label)sender;
            //    DragDrop.DoDragDrop(lb, lb.Content, DragDropEffects.Copy); 
            #endregion
            Label lb = sender as Label;
            DragDrop.DoDragDrop(lb, lb.Content, DragDropEffects.Copy);
        }

        private void lb_target_Drop(object sender, DragEventArgs e)
        {
            #region Solution
            //lb_target.Content = e.Data.GetData(DataFormats.Text); 
            #endregion
            lb_target.Content = e.Data.GetData(DataFormats.Text);
        }

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            #region Solution
            //btn.Background = new SolidColorBrush(Color.FromRgb(123, 53, 82)); 
            #endregion
            btn.Background = new SolidColorBrush(Color.FromRgb(192, 132, 161));
        }
    }
}
