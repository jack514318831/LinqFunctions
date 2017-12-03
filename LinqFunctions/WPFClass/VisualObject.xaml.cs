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
    /// Interaktionslogik für VisualObject.xaml
    /// </summary>
    public partial class VisualObject : Window
    {
        public VisualObject()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawingVisual dv = new DrawingVisual();
            DrawingContext dc = dv.RenderOpen();
            Brush brush = Brushes.LightGreen;
            Pen pen = new Pen(Brushes.SteelBlue, 3);
            dc.DrawRectangle(brush, pen, new Rect(new Point(10, 10),new Size(50, 25)));
            dc.DrawEllipse(brush, pen, new Point(10, 60), 50, 25);
            dc.DrawLine(pen, new Point(10, 100), new Point(80, 120));
            dc.Close();
            MyPanel.AddChild(dv);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickpoint = e.GetPosition(this.MyPanel);
            DrawingVisual dv = new DrawingVisual();
            this.drawRect(dv, clickpoint);
            MyPanel.AddChild(dv);
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickpoint = e.GetPosition(this.MyPanel);
            DrawingVisual dv = MyPanel.GetVisual(clickpoint);
            if (dv == null) return;
            MyPanel.RemoveChild(dv);
        }

        private void drawRect(DrawingVisual visual, Point pt)
        {
            DrawingContext dc = visual.RenderOpen();
            dc.DrawRectangle(Brushes.LightGreen, new Pen(Brushes.SteelBlue, 3), new Rect(pt, new Size(10, 10)));
            dc.Close();

        }
    }
}
