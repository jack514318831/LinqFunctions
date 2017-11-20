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

namespace LinqFunctions.WPFClass.ExXaml
{
    /// <summary>
    /// Interaktionslogik für WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        public WindowMain()
        {
            InitializeComponent();
        }

        private Button MyButton;
        public WindowMain(string str)
        {
            this.Width = this.Height = 300;
            this.Top = this.Left = 100;
            this.Title = "Extretion";

            DependencyObject rootObject = new DependencyObject();
            using (FileStream fs = new FileStream(str, FileMode.Open))
            {
                rootObject = (DependencyObject) XamlReader.Load(fs);
            }

            MyButton = LogicalTreeHelper.FindLogicalNode(rootObject, "MyButton") as Button;

            this.Content = rootObject;
        }
    }
}
