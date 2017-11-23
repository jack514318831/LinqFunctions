﻿using System;
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

namespace LinqFunctions.WPFClass.ContentElement
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void tbTest_SelectionChanged(object sender, RoutedEventArgs e)
        {
            #region Solution
            // if (this.tblock == null) return;
            //this.tblock.Text = "selection from" + this.tbTest.SelectionStart + "Length" + this.tbTest.SelectionLength + "Content:" + this.tbTest.SelectedText; 
            #endregion
            if (tblock == null) return;
            tblock.Text = string.Format("select from {0}, length {1}, Content {2}", tbTest.SelectionStart, tbTest.SelectionLength, tbTest.SelectedText);
        }
    }
}
