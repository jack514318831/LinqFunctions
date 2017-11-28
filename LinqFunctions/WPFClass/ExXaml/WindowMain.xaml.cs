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
using System.IO;
using System.Windows.Markup;
using Microsoft.Win32;

namespace LinqFunctions.WPFClass.ExXaml
{
    /// <summary>
    /// Interaktionslogik für WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        public WindowMain()
        {
            InitializeComponent1();
        }

        #region Solution
        //private Button button1;
        //private void InitializeComponent1()
        //{
        //    this.Width = this.Height = this.Top = this.Left = 300;
        //    this.Title = "Ex Code";

        //    OpenFileDialog open = new OpenFileDialog();
        //    if (open.ShowDialog() == false)
        //    { return; }

        //    DependencyObject rootObject = new DependencyObject();

        //    using (FileStream fs = new FileStream(open.FileName, FileMode.Open))
        //    {
        //        rootObject = (DependencyObject) XamlReader.Load(fs);
        //    }

        //    button1 = (Button) LogicalTreeHelper.FindLogicalNode(rootObject, "MyButton");

        //    this.Content = rootObject;
        //} 
        #endregion

        private Button button1;
        private void InitializeComponent1()
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == false) return;
            DependencyObject rootObject = new DependencyObject();
            using (FileStream fs = new FileStream(open.FileName, FileMode.Open))
            {
                 rootObject = XamlReader.Load(fs) as DependencyObject;
            }
            button1 = LogicalTreeHelper.FindLogicalNode(rootObject, "MyButton") as Button;

            this.Content = rootObject;
        }
    }
}
