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
    /// Interaktionslogik für AreaElement.xaml
    /// </summary>
    public partial class AreaElement : Window
    {
        public AreaElement()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(Window w in Application.Current.Windows)
            {
                MessageBox.Show(w.Title);
            }
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            //Data Binding in Code
            #region Solution
            //Binding binding = new Binding();
            //binding.Source = this.SliderFont;
            //binding.Path = new PropertyPath("Value");
            //binding.Mode = BindingMode.TwoWay;
            //this.tbZiel.SetBinding(TextBlock.FontSizeProperty, binding); 
            #endregion

            Binding binding = new Binding();
            binding.Source = this.SliderFont;
            binding.Path = new PropertyPath("Value");
            binding.Mode = BindingMode.TwoWay;
            this.tbZiel.SetBinding(TextBlock.FontSizeProperty, binding);

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            #region Solution
            //BindingOperations.ClearAllBindings(this.tbZiel); 
            #endregion

            BindingOperations.ClearAllBindings(this.tbZiel);

        }
    }
}
