using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace LinqFunctions.WPFClass.CodeOnly
{
    class Window1:Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        #region Solution
        //private Button button1;
        //private void InitializeComponent()
        //{
        //    this.Width = 250;
        //    this.Height = 200;
        //    this.Left = this.Top = 100;
        //    this.Title = "Code Only";

        //    DockPanel dockpanel = new DockPanel();

        //    button1 = new Button();
        //    button1.Content = "Click Me";
        //    button1.Margin = new Thickness(10);
        //    button1.Click += button1_Click;

        //    IAddChild container = dockpanel;
        //    container.AddChild(button1);

        //    container = this;
        //    container.AddChild(dockpanel);


        //}

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    button1.Content = "Hallo";
        //} 
        #endregion

        private Button button1;
        private void InitializeComponent()
        {
            this.Width = this.Height = this.Top = this.Left = 300;
            this.Title = "Code Only";

            DockPanel dockpanel = new DockPanel();
            button1 = new Button();
            button1.Margin = new Thickness(10);
            button1.Content = "Lithum";
            button1.Click += button1_Click;

            IAddChild container = dockpanel;
            container.AddChild(button1);
            container = this;
            container.AddChild(dockpanel);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.Content = "Blei";
        }
    }
}
