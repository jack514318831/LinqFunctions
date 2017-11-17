using System;
using System.Collections.Generic;
using System.IO;
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

namespace LinqFunctions
{
    /// <summary>
    /// Interaktionslogik für WPFFunctions.xaml
    /// </summary>
    public partial class WPFFunctions : Window
    {
        public WPFFunctions()
        {
            InitializeComponent();
            String[] args = App.Args;

            try
            {
                // Open the text file using a stream reader. 
                using (StreamReader sr = new StreamReader(args[0]))
                {
                    // Read the stream to a string, and write  
                    // the string to the text box 
                    String line = sr.ReadToEnd();
                    textBox.AppendText(line.ToString());
                    textBox.AppendText("\n");
                }
            }
            catch (Exception e)
            {
                textBox.AppendText("The file could not be read:");
                textBox.AppendText("\n");
                textBox.AppendText(e.Message);
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
             //< Button  Height = "40" Width = "175" Margin = "10" Content = "Dependency Property" Click = "Button_Click" >
             //    < Button.Style >
             //        < Style TargetType = "{x:Type Button}" >
             //             < Style.Triggers >
             //                 < Trigger Property = "IsMouseOver" Value = "True" >
             //                      < Setter Property = "Foreground" Value = "Red" />
             //                   </ Trigger >
             //               </ Style.Triggers >
             //           </ Style >
             //       </ Button.Style >
             //   </ Button >
        }


        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text = "Button is Clicked";
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            txt2.Text = "Click event is bubbled to Stack Panel";
            e.Handled = true;
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {
            txt3.Text = "Click event is bubbled to Window";
        }

        private void changeResourceButton_Click(object sender, RoutedEventArgs e)
        {
           Color c = Color.FromRgb(25, 125, 25);
           SolidColorBrush scb = new SolidColorBrush(c);
           

        }

     
    }
}
