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
            this.tb_output.Text = string.Format("Event:{0} Key:{1}" e.RoutedEvent, e.Key);
        }
    }
}
