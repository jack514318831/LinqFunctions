using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
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
    /// Interaktionslogik für Kind.xaml
    /// </summary>
    public partial class Kind : Window, ISendmassege
    {
       
        public Kind()
        {
            InitializeComponent();
        }

        public string s { get; set; }
       
        public void SetText(string m)
        {
            if (!Dispatcher.CheckAccess())
            {
                tb_info.Dispatcher.Invoke(() =>
                {
                    tb_info.Text = m;
                });
                return;
            }
        }

        public void SetTextAbont(string str)
        {
            if (!Dispatcher.CheckAccess())
            {
                tb_info.Dispatcher.Invoke(() =>
                {
                    tb_info.Text = str;
                });

                return;
            }
        }

        public void SetTextFromEvent(object sender,EventArgs e)
        {
            string info = (e as MyEventArgs).Text;
            if (!Dispatcher.CheckAccess())
            {
                tb_info.Dispatcher.Invoke(()=> {
                    tb_info.Text = info;
                });
            }
        }

        private void btn_trans_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
